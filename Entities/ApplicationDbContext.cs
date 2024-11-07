using Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
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
        public virtual DbSet<SalaryAmount> SalaryAmounts { get; set; }


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
            builder.Entity<SalaryAmount>().ToTable("SalaryAmounts");


            List<Province> ProvincesSeedData = JsonSerializer.Deserialize<List<Province>>(File.ReadAllText("Provinces.json"));
            foreach (var province in ProvincesSeedData)
            {
                builder.Entity<Province>().HasData(province);
            }

            List<City> CitiesSeedData = JsonSerializer.Deserialize<List<City>>(File.ReadAllText("Cities.json"));
            foreach (var city in CitiesSeedData)
            {
                builder.Entity<City>().HasData(city);
            }

            List<SalaryAmount> salaryAmountsSeedData = JsonSerializer.Deserialize<List<SalaryAmount>>(File.ReadAllText("SalaryAmount.json"));
            foreach (var salary in salaryAmountsSeedData)
            {
                builder.Entity<SalaryAmount>().HasData(salary);
            }
        }

        public async Task<int> SP_InsertAdvertisement(Advertisement advertisement)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@Id",advertisement.Id),
                new SqlParameter("@CityId",advertisement.CityId),
                new SqlParameter("@Gender",advertisement.Gender),
                new SqlParameter("@MilitaryServiceStatus",advertisement.MilitaryServiceStatus),
                new SqlParameter("@LeastYearsOfExperience",advertisement.LeastYearsOfExperience),
                new SqlParameter("@LeastAcademicDegree",advertisement.LeastAcademicDegree),
                new SqlParameter("@Description",advertisement.Description),
                new SqlParameter("@Title",advertisement.Title),
                new SqlParameter("@JobCategoryId",advertisement.JobCategoryId),
                new SqlParameter("@IsVerified",advertisement.IsVerified),
                new SqlParameter("@CompanyId",advertisement.CompanyId),
                new SqlParameter("@NotVerificationDescription",advertisement.NotVerificationDescription),
                new SqlParameter("@SalaryID",advertisement.SalaryID),
                new SqlParameter("@TypeOfCooperation",advertisement.TypeOfCooperation)
            };

            return await Database.ExecuteSqlRawAsync("EXECUTE [dbo].[InsertAdvertisement] @Id, @CityId, @Gender, @MilitaryServiceStatus, @LeastYearsOfExperience, @LeastAcademicDegree, @Description, @Title, @JobCategoryId, @IsVerified, @CompanyId, @NotVerificationDescription, @SalaryID, @TypeOfCooperation");
        }

        public async Task<Advertisement> SP_GetAdvertisementById(Guid Id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {

                new SqlParameter("@Id",Id),
            };
            return await Advertisements.FromSqlRaw("EXECUTE [dbo].[GetAdvertisementById] @Id", sqlParameters).FirstOrDefaultAsync();
        }
    }
}
