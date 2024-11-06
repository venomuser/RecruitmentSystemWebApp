using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class JobCategoryUpdateRequest
    {
        [Required(ErrorMessage ="شناسه دسته بندی شغلی نمی تواند خالی باشد.")]
        public Guid JobCategoryId { get; set; }

        [Required(ErrorMessage = "نام دسته شغلی نمی تواند خالی باشد.")]
        public string? JobCategoryName { get; set; }

        [Required(ErrorMessage = "کاربر ویرایش کننده باید مشخص باشد.")]
        public Guid? UserID { get; set; }



        public JobCategory ToJobCategory()
        {
            return new()
            {
                CategoryName = this.JobCategoryName,
                UserID = this.UserID
            };
        }
    }
}
