using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "آدرس ایمیل نمی تواند خالی باشد")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل باید در فرمت یک ایمیل معتبر باشد")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "رمز عبور نمی تواند خالی باشد")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
