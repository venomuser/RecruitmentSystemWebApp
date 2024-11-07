using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class JobCategoryRepository : IJobCategoryRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public JobCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JobCategory> AddJobCategory(JobCategory jobCategory)
        {
            _dbContext.JobCategories.Add(jobCategory);
             await _dbContext.SaveChangesAsync();
            return jobCategory;
        }

        public async Task<bool> DeleteJobCategoryById(Guid jobCategoryID)
        {
            _dbContext.RemoveRange(_dbContext.JobCategories.Where(temp=>temp.Id == jobCategoryID));
            int rowsEffected = await _dbContext.SaveChangesAsync();
            return rowsEffected > 0;
        }

        public async Task<List<JobCategory>> GetAllJobCategories()
        {
           return await _dbContext.JobCategories.ToListAsync();
        }

        public async Task<List<JobCategory?>> GetJobCategoryByUserId(Guid userID)
        {
            return await _dbContext.JobCategories.Where(temp=> temp.UserID == userID).ToListAsync();
        }

        public async Task<JobCategory?> GetJobCategoryById(Guid jobCategoryID)
        {
            return await _dbContext.JobCategories.FirstOrDefaultAsync(temp => temp.Id == jobCategoryID);
        }

        public async Task<JobCategory?> GetJobCategoryByName(string name)
        {
            return await _dbContext.JobCategories.FirstOrDefaultAsync(temp => temp.CategoryName == name);
        }

        public async Task<JobCategory> UpdateJobCategory(JobCategory jobCategory)
        {
           JobCategory? category = await _dbContext.JobCategories.FirstOrDefaultAsync(temp=>temp.Id == jobCategory.Id);
            if (category == null) {

                return jobCategory;
            }

            category.CategoryName = jobCategory.CategoryName;
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
