using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class CompanyEditDTO
    {
        [Required(ErrorMessage ="وجود شناسه کاربر الزامی است")]
        public Guid? UserId { get; set; }
        [Required(ErrorMessage = "نام مؤسسه یا شرکت نمی تواند خالی باشد")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "آدرس ایمیل مؤسسه نمی تواند خالی باشد")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل باید در فرمت یک ایمیل معتبر باشد")]
        //[Remote(action: "IsEmailValid", controller: "Account", ErrorMessage = "این ایمیل قبلاً در این سایت ثبت نام شده است")]
        [DataType(DataType.EmailAddress)]
        public string? CompanyEmail { get; set; }

        [Required(ErrorMessage = "شماره تلفن شرکت نمی تواند خالی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone should contain only numeric values")]
        [DataType(DataType.PhoneNumber)]
        public string? CompanyPhone { get; set; }

        public string? CompanyAddress { get; set; }
        public string? CompanyDescription { get; set; }
        public string? AvatarAddress { get; set; }
    }
}
