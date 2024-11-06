using Entities;

namespace RepositoryContracts
{
    public interface IJobCategoryRepository
    {
        Task<JobCategory> AddJobCategory(JobCategory jobCategory);
        Task<JobCategory> UpdateJobCategory(JobCategory jobCategory);
        Task<bool> DeleteJobCategoryById(Guid jobCategoryID);
        Task<List<JobCategory>> GetAllJobCategories();
        Task<List<JobCategory?>> GetJobCategoryByUserId(Guid userID);
        Task<JobCategory?> GetJobCategoryById(Guid jobCategoryID);
        Task<JobCategory?> GetJobCategoryByName(string name);
    }
}
