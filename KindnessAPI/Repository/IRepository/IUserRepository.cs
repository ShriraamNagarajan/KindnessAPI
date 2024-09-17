using KindnessAPI.Models.Dto;

namespace KindnessAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<TokenDto> Login(LoginRequestDto loginRequestDto);
        Task<UserDto> Register(RegistrationRequestDto registerRequestDto);
        Task<TokenDto> RefreshAccessToken(TokenDto tokenDto);
        Task RevokeRefreshToken(TokenDto tokenDto); 
    }
}
