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
    public class AdvertisementAdminUpdateDTO
    {
        
        public Guid AdvertisementID { get; }
       
        public long? CityID { get; }

        
        public GenderOptions? Gender { get;  }

        public string? MilitaryServiceStatus { get;  }

        
        public int? LeastYearsOfExperience { get; }

       
        public AcademicDegrees? AcademicDegree { get; }

        
        public string? Description { get; }

        
        public string? Title { get;}

       
        public Guid? JobCategoryID { get; }

        
        public Guid? CompanyID { get; }

        
        public CooperationTypeOptions? CooperationType { get; }

        
        public int? SalaryAmountID { get;}

        [Required(ErrorMessage ="وضعیت انتشار آگهی باید مشخص شود")]
        public bool? IsVerified { get; set; }

        public string? NoVerificationDescription {  get; set; }


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
                Gender = Gender.Value.ToString(),
                IsVerified = IsVerified.Value,
                NotVerificationDescription = NoVerificationDescription
            };
        }
    }
}
