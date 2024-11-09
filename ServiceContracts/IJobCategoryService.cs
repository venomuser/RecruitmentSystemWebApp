using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IJobCategoryService
    {
        Task<Message> JobAddAsync(JobCategoryAddRequest jobCategoryAddRequest);
        Task<Message> JobUpdateAsync(JobCategoryUpdateRequest jobCategoryUpdateRequest);
        Task<bool> JobDeleteAsync(Guid? jobCategoryID);
        Task<List<JobCategoryResponse?>> GetAllJobsAsync();
        Task<List<JobCategoryResponse?>> GetJobCategoryByCompanyId(Guid? companyID);
    }
}
