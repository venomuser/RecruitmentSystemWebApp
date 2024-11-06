using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IJobCategoryService
    {
        Task<JobCategoryResponse> JobAddAsync(JobCategoryAddRequest jobCategoryAddRequest);
        Task<JobCategoryResponse> JobUpdateAsync(JobCategoryUpdateRequest jobCategoryUpdateRequest);
        Task<bool> JobDeleteAsync(Guid? jobCategoryID);
        Task<List<JobCategoryResponse?>> GetAllJobsAsync();
        Task<List<JobCategoryResponse?>> GetJobCategoryByCompanyId(Guid? companyID);
    }
}
