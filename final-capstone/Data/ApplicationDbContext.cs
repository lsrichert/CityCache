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

            modelBuilder.Entity<Neighborhood>().HasData(
                new Neighborhood()
                {
                    NeighborhoodId = 1,
                    Name = "Ravenswood",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 2,
                    Name = "Lincoln Park",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 3,
                    Name = "Andersonville",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 4,
                    Name = "Wrigleyville",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 5,
                    Name = "River North",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 6,
                    Name = "Logan Square",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 7,
                    Name = "Roscoe Village",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 8,
                    Name = "Southport Corridor",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 9,
                    Name = "North Center",
                },

                new Neighborhood()
                {
                    NeighborhoodId = 10,
                    Name = "Wicker Park"
                },

                new Neighborhood()
                {
                    NeighborhoodId = 11,
                    Name = "Old Town"
                },

                new Neighborhood()
                {
                    NeighborhoodId = 12,
                    Name = "West Loop"
                },

                new Neighborhood()
                {
                    NeighborhoodId = 13,
                    Name = "Lincoln Square"
                },

                new Neighborhood()
                {
                    NeighborhoodId = 14,
                    Name = "Other"
                }
                );

            modelBuilder.Entity<RecommendationType>().HasData(
                new RecommendationType()
                {
                    RecommendationTypeId = 1,
                    Name = "Food & Drink",
                },

                new RecommendationType()
                {
                    RecommendationTypeId = 2,
                    Name = "Entertainment"
                },

                new RecommendationType()
                {
                    RecommendationTypeId = 3,
                    Name = "Other"
                }
                );

            modelBuilder.Entity<Recommendation>().HasData(
                new Recommendation()
                {
                    RecommendationId = 1,
                    Name = "Over Easy",
                    Description = "Breakfast",
                    StreetAddress = "4943 N. Damen Ave.",
                    WebsiteURL = "overeasycafechicago.com",
                    ApplicationUserId = 1,
                    NeighborhoodId = 1,
                    RecommendationTypeId = 1

                },

                new Recommendation()
                {
                    RecommendationId = 2,
                    Name = "Hub 51",
                    Description = "Contemporary-American",
                    StreetAddress = "51 W. Hubbard St.",
                    WebsiteURL = "hub51chicago.com",
                    ApplicationUserId = 1,
                    NeighborhoodId = 5,
                    RecommendationTypeId = 1

                },

                new Recommendation()
                {
                    RecommendationId = 3,
                    Name = "The Second City",
                    Description = "Comedy Club",
                    StreetAddress = "1616 N. Wells St.",
                    WebsiteURL = "secondcity.com",
                    ApplicationUserId = 1,
                    NeighborhoodId = 11,
                    RecommendationTypeId = 2

                },

                new Recommendation()
                {
                    RecommendationId = 4,
                    Name = "Crosby's Kitchen",
                    Description = "American Comfort",
                    StreetAddress = "3455 N. Southport Ave.",
                    WebsiteURL = "crosbyschicago.com",
                    ApplicationUserId = 1,
                    NeighborhoodId = 8,
                    RecommendationTypeId = 1

                },

                new Recommendation()
                {
                    RecommendationId = 5,
                    Name = "HopLeaf",
                    Description = "Bar",
                    StreetAddress = "5148 N. Clark St.",
                    WebsiteURL = "hopleafbar.com",
                    ApplicationUserId = 1,
                    NeighborhoodId = 3,
                    RecommendationTypeId = 1

                });

            

        }
    }
}
