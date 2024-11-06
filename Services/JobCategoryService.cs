using ServiceContracts;
using ServiceContracts.DTO;
using RepositoryContracts;
using Entities;

namespace Services
{
    public class JobCategoryService : IJobCategoryService
    {

        private readonly IJobCategoryRepository _jobCategoryRepository;

        public JobCategoryService(IJobCategoryRepository jobCategoryRepository) { 
        
          _jobCategoryRepository = jobCategoryRepository;
        }


        public async Task<List<JobCategoryResponse?>> GetAllJobsAsync()
        {
            return (await _jobCategoryRepository.GetAllJobCategories()).Select(category=>category?.ToJobCategoryResponse()).ToList();
        }

        public async Task<List<JobCategoryResponse?>> GetJobCategoryByCompanyId(Guid? companyID)
        {
            if (companyID == null)
            {
                return new List<JobCategoryResponse?>();
            }

            List<JobCategory?> jobCategory = await _jobCategoryRepository.GetJobCategoryByUserId(companyID.Value);
            if (jobCategory.Count <=0)
            {
                return new List<JobCategoryResponse?>();
            }
            return jobCategory.Select(temp => temp?.ToJobCategoryResponse()).ToList();
        }

        public async Task<JobCategoryResponse> JobAddAsync(JobCategoryAddRequest jobCategoryAddRequest)
        {
            if(jobCategoryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(jobCategoryAddRequest));
            }

            if(jobCategoryAddRequest.CategoryName == null)
            {
                throw new ArgumentException(nameof(jobCategoryAddRequest.CategoryName));
            }

            if(await _jobCategoryRepository.GetJobCategoryByName(jobCategoryAddRequest.CategoryName) != null)
            {
                throw new ArgumentException("دسته بندی شغلی مشابهی با همین نام وجود دارد!");
            }

            JobCategory jobCategory = jobCategoryAddRequest.ToJobCategory();
            jobCategory.Id = Guid.NewGuid();
            await _jobCategoryRepository.AddJobCategory(jobCategory);

            JobCategoryResponse jobCategoryResponse = jobCategory.ToJobCategoryResponse();
            return jobCategoryResponse;
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
