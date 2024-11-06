using Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<SiteAdministrator> Admins { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<JobCategory> JobCategories { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Configure inheritance and discriminator
            builder.Entity<ApplicationUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Company>("Company")
                .HasValue<SiteAdministrator>("SiteAdministrator");

            builder.Entity<Province>().ToTable("Provinces");
            builder.Entity<City>().ToTable("Cities");
            builder.Entity<JobCategory>().ToTable("JobCategories");
            builder.Entity<Advertisement>().ToTable("Advertisements");


            List<Province> ProvincesSeedData = JsonSerializer.Deserialize<List<Province>>(File.ReadAllText("Provinces.json"));
            foreach(var province in ProvincesSeedData)
            {
                builder.Entity<Province>().HasData(province);
            }

            List<City> CitiesSeedData = JsonSerializer.Deserialize<List<City>>(File.ReadAllText("Cities.json"));
            foreach(var city in CitiesSeedData)
            {
                builder.Entity<City>().HasData(city);
            }
        }
    }
}
