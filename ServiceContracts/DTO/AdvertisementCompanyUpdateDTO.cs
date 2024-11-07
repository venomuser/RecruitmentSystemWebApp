using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class AdvertisementCompanyUpdateDTO
    {
        [Required(ErrorMessage ="شناسه آگهی استخدام باید مشخص باشد")]
        public Guid AdvertisementID { get; set; }
        [Required(ErrorMessage = "فیلد شهر نمی تواند خالی باشد")]
        public long? CityID { get; set; }

        [Required(ErrorMessage = "فیلد جنسیت نمی تواند خالی باشد")]
        public GenderOptions? Gender { get; set; }

        public string? MilitaryServiceStatus { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "تعداد سال های حداقل سابقه باید عددی باشد")]
        public int? LeastYearsOfExperience { get; set; }

        [Required(ErrorMessage = "حداقل مدرک تحصیلی باید مشخص شود")]
        public AcademicDegrees? AcademicDegree { get; set; }

        [Required(ErrorMessage = "شرح موقعیت شغلی نمی تواند خالی باشد")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "عنوان آگهی نمی تواند خالی باشد")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "دسته بندی شغلی این آگهی باید مشخص باشد")]
        public Guid? JobCategoryID { get; set; }

        [Required(ErrorMessage = "شرکت ثبت کننده آگهی باید مشخص باشد")]
        public Guid? CompanyID { get; set; }

        [Required(ErrorMessage = "نوع همکاری باید مشخص باشد")]
        public CooperationTypeOptions? CooperationType { get; set; }

        [Required(ErrorMessage = "میزان حقوق باید مشخص باشد")]
        public int? SalaryAmountID { get; set; }


        public Advertisement ToAdvertisement()
        {
            return new()
            {
                Id = AdvertisementID,
                CityId = CityID,
                CompanyId = CompanyID,
                Description = Description,
                SalaryID = SalaryAmountID,
                JobCategoryId = JobCategoryID,
                LeastAcademicDegree = AcademicDegree.Value.ToString(),
                LeastYearsOfExperience = LeastYearsOfExperience,
                MilitaryServiceStatus = MilitaryServiceStatus,
                Title = Title,
                TypeOfCooperation = CooperationType.Value.ToString(),
                Gender = Gender.Value.ToString()

            };
        }
    }
}
