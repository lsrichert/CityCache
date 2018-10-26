using System;
using System.Collections.Generic;
using System.Text;
using final_capstone.Models;
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
    }
}
