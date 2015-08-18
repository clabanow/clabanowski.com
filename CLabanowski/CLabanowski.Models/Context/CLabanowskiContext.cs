using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLabanowski.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CLabanowski.Models.Context
{
    public class CLabanowskiContext : DbContext
    {
        public CLabanowskiContext()
            : base("ClabanowskiContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<PortfolioProject> PortfolioProjects { get; set; }
    }
}
