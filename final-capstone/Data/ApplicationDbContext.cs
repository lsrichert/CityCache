using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using final_capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace final_capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Neighborhood> Neighborhood { get; set; }
        public DbSet<Recommendation> Recommendation { get; set; }
        public DbSet<RecommendationType> RecommendationType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplicationUser user = new ApplicationUser
            {
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser user1 = new ApplicationUser
            {
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash1 = new PasswordHasher<ApplicationUser>();
            user1.PasswordHash = passwordHash1.HashPassword(user1, "Test1*");
            modelBuilder.Entity<ApplicationUser>().HasData(user1);

            modelBuilder.Entity<RecommendationType>().HasData(
                new RecommendationType()
                {
                    RecommendationTypeId = 1,
                    Name = "Restaurant",
                },

                new RecommendationType()
                {
                    RecommendationTypeId = 2,
                    Name = "Coffee"
                },

                new RecommendationType()
                {
                    RecommendationTypeId = 3,
                    Name = "Music"
                },

                new RecommendationType()
                {
                    RecommendationTypeId = 4,
                    Name = "Comedy"
                },

                new RecommendationType()
                {
                    RecommendationTypeId = 5,
                    Name = "Shop"
                },

                new RecommendationType()
                {
                    RecommendationTypeId = 6,
                    Name = "Other"
                }
                );

            modelBuilder.Entity<Recommendation>().HasData(
                new Recommendation()
                {
                    RecommendationId = 1,
                    Name = "",
                    Description = "",
                    StreetAddress = "",
                    WebsiteURL = "",

                },

        }
    }
}
