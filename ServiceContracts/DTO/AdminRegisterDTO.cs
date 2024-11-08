using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class AdminRegisterDTO
    {
        [Required(ErrorMessage = "نام مدیر نمی تواند خالی باشد")]
        public string? AdminActualName { get; set; }

        [Required(ErrorMessage = "آدرس ایمیل مدیر نمی تواند خالی باشد")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل باید در فرمت یک ایمیل معتبر باشد")]
        [Remote(action: "IsEmailValid", controller: "Account", ErrorMessage = "این ایمیل قبلاً در این سایت ثبت نام شده است")]
        [DataType(DataType.EmailAddress)]
        public string? AdminEmail { get; set; }

        [Required(ErrorMessage = "رمز عبور نمی تواند خالی باشد")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "تکرار رمز عبور نمی تواند خالی باشد")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار رمز عبور یکی نیستند")]
        public string? ConfirmPassword { get; set; }
    }
}
