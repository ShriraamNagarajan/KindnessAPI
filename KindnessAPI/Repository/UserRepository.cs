using AutoMapper;
using KindnessAPI.Data;
using KindnessAPI.Models;
using KindnessAPI.Models.Dto;
using KindnessAPI.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KindnessAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext db, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == username);
            if (user != null)
            {
                return false;
            }
            return true;
        }

        public async Task<TokenDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.Username.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new TokenDto()
                {
                    AccessToken = ""
                };
            }
            //if user was found generate JWT Token

            var jwtTokenId = $"JTI{Guid.NewGuid()}";

            var accessToken = await GetAccessToken(user, jwtTokenId);
            var refereshToken = await CreateNewRefreshToken(user.Id, jwtTokenId);
            TokenDto tokenDto = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refereshToken
            };

            return tokenDto;

        }

        public async Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequestDto.Username,
                Email = registrationRequestDto.Username,
                NormalizedEmail = registrationRequestDto.Username.ToUpper(),
                Name = registrationRequestDto.Name

            };
            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    if (registrationRequestDto.Role.ToLower() == "admin")
                    {
                        await _userManager.AddToRoleAsync(user, "admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "customer");
                    }
         
                    
                    var userToReturn = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == registrationRequestDto.Username);
                    return _mapper.Map<UserDto>(userToReturn);
                }

            }
            catch (Exception ex)
            {

            }
            return new UserDto();
        }

        private async Task<string> GetAccessToken(ApplicationUser user, string jwtTokenId)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
        new Claim(ClaimTypes.Name, user.UserName.ToString()),
        new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
        new Claim(JwtRegisteredClaimNames.Jti, jwtTokenId),
        new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<TokenDto> RefreshAccessToken(TokenDto tokenDto)
        {
            // Find an existing refresh token
            var existingRefreshToken = await _db.RefreshTokens.FirstOrDefaultAsync(u => u.Refresh_Token == tokenDto.RefreshToken);
            if (existingRefreshToken == null)
            {
                return new TokenDto();
            }

            // Compare data from existing refresh and access token provided and if there is any mismatch then consider it as a fraud attempt
            var isTokenValid = GetAccessTokenData(tokenDto.AccessToken, existingRefreshToken.UserId, existingRefreshToken.JwtTokenId);
            if (!isTokenValid)
            {
                existingRefreshToken.IsValid = false;
                _db.SaveChanges();
                return new TokenDto();
            }

            // When someone tries to use not valid refresh token, fraud possible
            if (!existingRefreshToken.IsValid)
            {
                var chainRecords = await _db.RefreshTokens.Where(u => u.UserId == existingRefreshToken.UserId && u.JwtTokenId == existingRefreshToken.JwtTokenId).ExecuteUpdateAsync(u => u.SetProperty(refreshToken => refreshToken.IsValid, false));

                return new TokenDto();
            }

            // If just expired then mark as invalid and return empty
            if (existingRefreshToken.ExpiresAt < DateTime.UtcNow)
            {
                existingRefreshToken.IsValid = false;
                _db.SaveChanges();
                return new TokenDto();
            }

            // Replace old refresh with a new one with updated expire date
            var newRefreshToken = await CreateNewRefreshToken(existingRefreshToken.UserId, existingRefreshToken.JwtTokenId);

            // Revoke existing refresh token
            existingRefreshToken.IsValid = false;
            _db.SaveChanges();

            // Generate new access token
            var applicationUser = _db.ApplicationUsers.FirstOrDefault(u => u.Id == existingRefreshToken.UserId);
            if (applicationUser == null)
            {
                return new TokenDto();
            }

            var newAccessToken = await GetAccessToken(applicationUser, existingRefreshToken.JwtTokenId);

            return new TokenDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            };
        }

        public async Task RevokeRefreshToken(TokenDto tokenDto)
        {
            var existingRefreshToken = await _db.RefreshTokens.FirstOrDefaultAsync(u => u.Refresh_Token == tokenDto.RefreshToken);
            if (existingRefreshToken == null) { return; }

            //compare data from existing refresh and access token provided and
            //if there is any mismatch then we should do nothing with the refresh token
            var isTokenValid = GetAccessTokenData(tokenDto.AccessToken, existingRefreshToken.UserId, existingRefreshToken.JwtTokenId);
            if (!isTokenValid)
            {
                return;
            }
            await _db.RefreshTokens.Where(u => u.UserId == existingRefreshToken.UserId && u.JwtTokenId == existingRefreshToken.JwtTokenId).ExecuteUpdateAsync(u => u.SetProperty(refreshToken => refreshToken.IsValid, false));

        }

        private async Task<string> CreateNewRefreshToken(string userId, string tokenId)
        {
            RefreshToken refreshToken = new()
            {
                IsValid = true,
                UserId = userId,
                JwtTokenId = tokenId,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60),
                Refresh_Token = Guid.NewGuid() + "-" + Guid.NewGuid(),
            };
            await _db.RefreshTokens.AddAsync(refreshToken);
            await _db.SaveChangesAsync();
            return refreshToken.Refresh_Token;
        }

        private bool GetAccessTokenData(string accessToken, string expectedUserId, string expectedTokenId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.ReadJwtToken(accessToken);
                var jwtTokenId = jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Jti).Value;
                var userId = jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value;
                return userId == expectedUserId && jwtTokenId == expectedTokenId;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
