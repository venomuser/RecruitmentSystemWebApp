using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class ForgotPasswordDTO
    {
        [Required(ErrorMessage = "آدرس ایمیل مدیر نمی تواند خالی باشد")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل باید در فرمت یک ایمیل معتبر باشد")]
        public string? Email { get; set; }
    }
}
