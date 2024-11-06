using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class JobCategoryService : IJobCategoryService
    {
        public Task<List<JobCategoryResponse?>> GetAllJobsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<JobCategoryResponse?>> GetJobCategoryByCompanyId(Guid? companyID)
        {
            throw new NotImplementedException();
        }

        public Task<JobCategoryResponse> JobAddAsync(JobCategoryAddRequest jobCategoryAddRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> JobDeleteAsync(Guid? jobCategoryID)
        {
            throw new NotImplementedException();
        }

        public Task<JobCategoryResponse> JobUpdateAsync(JobCategoryUpdateRequest jobCategoryUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
