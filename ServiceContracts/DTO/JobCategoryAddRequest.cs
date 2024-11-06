using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class JobCategoryAddRequest
    {
        [Required(ErrorMessage ="وارد کردن نام دسته بندی شغلی الزامی است.")]
        //[Remote(????)]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage ="کاربر ایجاد کننده باید مشخص باشد.")]
        public Guid? UserID { get; set; }

        public JobCategory ToJobCategory()
        {
            return new()
            {
                CategoryName = this.CategoryName
                , UserID = this.UserID
            };
        }
    }
}
