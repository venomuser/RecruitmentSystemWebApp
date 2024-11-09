using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AdvertisementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Advertisement> CreateAdvertisement(Advertisement advertisement)
        {
            //await _dbContext.SP_InsertAdvertisement(advertisement);
            await _dbContext.Advertisements.AddAsync(advertisement);
            await _dbContext.SaveChangesAsync();
            return advertisement;
        }

        public async Task<bool> DeleteAdvertisement(Guid id)
        {
            _dbContext.Advertisements.RemoveRange(_dbContext.Advertisements.Where(a => a.Id == id));
             int rowsEffected = await _dbContext.SaveChangesAsync();
            return rowsEffected > 0;
        }

        public async Task<Advertisement?> GetAdvertisementByID(Guid Id)
        {
            // return await _dbContext.SP_GetAdvertisementById(Id);


            return await _dbContext.Advertisements.Include("Company").Include("City").Include("JobCategory")
                  .Include("SalaryAmount").FirstOrDefaultAsync(temp => temp.Id == Id);
        }

        public async Task<List<Advertisement>> GetAdvertisementsByCompanyID(Guid companyID)
        {
            return await _dbContext.Advertisements.Include("Company").Include("City").Include("JobCategory")
                  .Include("SalaryAmount").Where(temp => temp.CompanyId == companyID).ToListAsync();
        }

        public async Task<List<Advertisement>> GetNotVerifiedAdvertisements()
        {
            return await _dbContext.Advertisements.Include("Company").Include("City").Include("JobCategory")
                  .Include("SalaryAmount").Where(temp => temp.IsVerified == null).ToListAsync();
        }

        public async Task<List<Advertisement>> GetVerifiedAdvertisements()
        {
            return await _dbContext.Advertisements.Include("Company").Include("City").Include("JobCategory")
                   .Include("SalaryAmount").Where(temp => temp.IsVerified == true).ToListAsync();
        }

        public async Task<Advertisement> UpdateAdvertisement(Advertisement advertisement)
        {
           Advertisement? advertisementUpdate = await _dbContext.Advertisements.FirstOrDefaultAsync(temp=>temp.Id == advertisement.Id);
            if (advertisementUpdate == null)
            {
                return advertisement;
            }

            advertisementUpdate.Title = advertisement.Title; advertisementUpdate.LeastAcademicDegree = advertisement.LeastAcademicDegree;
            advertisementUpdate.IsVerified = advertisement.IsVerified; advertisementUpdate.SalaryID = advertisement.SalaryID;
            advertisementUpdate.CityId = advertisement.CityId; advertisementUpdate.CompanyId = advertisement.CompanyId;
            advertisementUpdate.Description = advertisement.Description; advertisementUpdate.Gender = advertisement.Gender;
            advertisementUpdate.JobCategoryId = advertisement.JobCategoryId;
            advertisementUpdate.LeastYearsOfExperience = advertisement.LeastYearsOfExperience;
            advertisementUpdate.MilitaryServiceStatus = advertisement.MilitaryServiceStatus;
            advertisementUpdate.NotVerificationDescription = advertisement.NotVerificationDescription;
            advertisementUpdate.TypeOfCooperation = advertisement.TypeOfCooperation; advertisementUpdate.EditionStatus = advertisement.EditionStatus;

            int count = await _dbContext.SaveChangesAsync();
            return advertisementUpdate;
        }
    }
}
