using KindnessAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace KindnessAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Act> Acts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Act>().HasData(

                new Act
                {
                    Id = 1,
                    Action = "Hold the door open for someone",
                    Difficulty = "Simple",
                    TimeRequired = "Quick",
                    LocationType = "Local",
                    ImpactType = "Personal",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
        new Act
        {
            Id = 2,
            Action = "Donate to a local charity",
            Difficulty = "Moderate",
            TimeRequired = "Medium",
            LocationType = "Local",
            ImpactType = "Community",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new Act
        {
            Id = 3,
            Action = "Plant a tree",
            Difficulty = "Challenging",
            TimeRequired = "Long",
            LocationType = "Local",
            ImpactType = "Environmental",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new Act
        {
            Id = 4,
            Action = "Leave a positive review for a local business",
            Difficulty = "Simple",
            TimeRequired = "Quick",
            LocationType = "Virtual",
            ImpactType = "Community",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new Act
        {
            Id = 5,
            Action = "Send a thank you note to a friend",
            Difficulty = "Simple",
            TimeRequired = "Quick",
            LocationType = "Virtual",
            ImpactType = "Personal",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        }


                );


            var adminRoleId = "3206214c-93fb-4b5a-8f8e-119f04ffa4b8";
            var customerRoleId = "BC48D86B-C73B-4DF1-BDFF-02A85520BC1B";
 

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name= "Admin",
                    NormalizedName = "ADMIN",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    Id = customerRoleId,
                    ConcurrencyStamp = customerRoleId
                },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
