using ServiceContracts;
using ServiceContracts.DTO;
using RepositoryContracts;
using Entities;
using Services.Helpers;

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

        public async Task<Message> JobAddAsync(JobCategoryAddRequest jobCategoryAddRequest)
        {
            if(jobCategoryAddRequest == null)
            {
                // throw new ArgumentNullException(nameof(jobCategoryAddRequest));
                return new Message() { Success = false, OperationMessage = "درخواست فرستاده شده نامعتبر است", Data = null};
            }

            ValidationHelper.ModelValidation(jobCategoryAddRequest);

            if(await _jobCategoryRepository.GetJobCategoryByName(jobCategoryAddRequest.CategoryName) != null)
            {
                // throw new ArgumentException("دسته بندی شغلی مشابهی با همین نام وجود دارد!");
                return new Message() { Success = false, Data = null, OperationMessage = "دسته بندی شغلی مشابهی با همین نام وجود دارد!" };
            }

            JobCategory jobCategory = jobCategoryAddRequest.ToJobCategory();
            jobCategory.Id = Guid.NewGuid();
            await _jobCategoryRepository.AddJobCategory(jobCategory);

            JobCategoryResponse jobCategoryResponse = jobCategory.ToJobCategoryResponse();
            return new Message() {Data = jobCategoryResponse, Success = true, OperationMessage = "دسته بندی شغلی با موفقیت اضافه شد" };
        }

        public Task<bool> JobDeleteAsync(Guid? jobCategoryID)
        {
            throw new NotImplementedException();
        }

        public async Task<Message> JobUpdateAsync(JobCategoryUpdateRequest jobCategoryUpdateRequest)
        {
            JobCategory? matchingJobCategory = await _jobCategoryRepository.GetJobCategoryById(jobCategoryUpdateRequest.JobCategoryId);
            if (matchingJobCategory == null) {

                // throw new ArgumentException("شناسه دسته بندی درست نمی باشد!");
                return new Message() { Data = null, Success = false, OperationMessage = "شناسه دسته بندی درست نمی باشد!" };
            
            }

            if (jobCategoryUpdateRequest.UserID != matchingJobCategory.UserID)
            {
                //throw new Exception("شما نمی توانید دسته بندی هایی که توسط اشخاص دیگر ایجاد شده اند را ویرایش کنید!");
                return new Message() { Success = false,
                    OperationMessage = "شما نمی توانید دسته بندی هایی که توسط اشخاص دیگر ایجاد شده اند را ویرایش کنید!", Data = null };
            }

                ValidationHelper.ModelValidation(jobCategoryUpdateRequest);

            

            matchingJobCategory.CategoryName = jobCategoryUpdateRequest.JobCategoryName;

           await _jobCategoryRepository.UpdateJobCategory(matchingJobCategory);

            return new Message() { Data = matchingJobCategory.ToJobCategoryResponse(), Success = true ,
                OperationMessage = "دسته بندی شغلی با موفقیت ویرایش شد" };


        }
    }
}
