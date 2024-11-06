using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class JobCategoryResponse
    {
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public Guid? UserID { get; set; }
        
    }

    public static class JobCategoryExtensions
    {
        public static JobCategoryResponse ToJobCategoryResponse(this JobCategory jobCategory)
        {
            return new JobCategoryResponse
            {

                CategoryId = jobCategory.Id,
                CategoryName = jobCategory.CategoryName,
                UserID = jobCategory.UserID
            };
        }
    }
}
