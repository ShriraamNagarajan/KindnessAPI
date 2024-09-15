using KindnessAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace KindnessAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
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
                    CreatedAt = DateTime.UtcNow
                },
        new Act
        {
            Id = 2,
            Action = "Donate to a local charity",
            Difficulty = "Moderate",
            TimeRequired = "Medium",
            LocationType = "Local",
            ImpactType = "Community",
            CreatedAt = DateTime.UtcNow
        },
        new Act
        {
            Id = 3,
            Action = "Plant a tree",
            Difficulty = "Challenging",
            TimeRequired = "Long",
            LocationType = "Local",
            ImpactType = "Environmental",
            CreatedAt = DateTime.UtcNow
        },
        new Act
        {
            Id = 4,
            Action = "Leave a positive review for a local business",
            Difficulty = "Simple",
            TimeRequired = "Quick",
            LocationType = "Virtual",
            ImpactType = "Community",
            CreatedAt = DateTime.UtcNow
        },
        new Act
        {
            Id = 5,
            Action = "Send a thank you note to a friend",
            Difficulty = "Simple",
            TimeRequired = "Quick",
            LocationType = "Virtual",
            ImpactType = "Personal",
            CreatedAt = DateTime.UtcNow
        }


                );

        }
    }
}
