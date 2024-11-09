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
    public class AdvertisementResponse
    {
       
        public Guid AdvertisementID { get; set; }
        
        public long? CityID { get; set; }

      
        public string? Gender { get; set; }

        public string? MilitaryServiceStatus { get; set; }

        
        public int? LeastYearsOfExperience { get; set; }

        
        public string? AcademicDegree { get; set; }

        
        public string? Description { get; set; }

       
        public string? Title { get; set; }

     
        public Guid? JobCategoryID { get; set; }

     
        public Guid? CompanyID { get; set; }

        
        public string? CooperationType { get; set; }

      
        public int? SalaryAmountID { get; set; }
        public bool? IsVerified { get; set; }
        public string? NotVerifiedDescription { get; set; }
        public string? AvatarAddress { get; set; }
        public string? CompanyName { get; set; }
        public string? Salary {  get; set; }
        public string? JobCategoryName { get; set; }
        public string? CityName { get; set; }
        public Guid? EditionStatus {  get; set; }


        public AdvertisementCompanyUpdateDTO ToCompanyUpdateDTO()
        {
            return new AdvertisementCompanyUpdateDTO()
            {
                SalaryAmountID = SalaryAmountID,
                MilitaryServiceStatus = MilitaryServiceStatus,
                AcademicDegree = (AcademicDegrees) Enum.Parse(typeof(AcademicDegrees), AcademicDegree, true),
                Description = Description,
                Title = Title,
                JobCategoryID = JobCategoryID,
                CompanyID = CompanyID,
                AdvertisementID = AdvertisementID,
                CityID = CityID,
                CooperationType = (CooperationTypeOptions) Enum.Parse(typeof(CooperationTypeOptions), CooperationType, true),
                Gender = (GenderOptions) Enum.Parse(typeof(GenderOptions), Gender, true),
                LeastYearsOfExperience = LeastYearsOfExperience,
                EditionStatus = EditionStatus
            };
            
           
        }

        public AdvertisementAdminUpdateDTO ToAdminUpdateDTO()
        {
            return new AdvertisementAdminUpdateDTO()
            {
                AdvertisementID = AdvertisementID,
                IsVerified = IsVerified,
                NoVerificationDescription = NotVerifiedDescription,
                EditionStatus = EditionStatus
            };
         
        }
    }

    public static class AdvertisementExtensions
    {
        public static AdvertisementResponse ToAdvertisementResponse(this Advertisement advertisement)
        {
            return new AdvertisementResponse
            {
                AcademicDegree = advertisement.LeastAcademicDegree,
                AdvertisementID = advertisement.Id,
                CityID = advertisement.CityId,
                CompanyID = advertisement.CompanyId,
                CooperationType = advertisement.TypeOfCooperation,
                Description = advertisement.Description,
                Title = advertisement.Title,
                Gender = advertisement.Gender,
                IsVerified = advertisement.IsVerified,
                JobCategoryID = advertisement.JobCategoryId,
                LeastYearsOfExperience = advertisement.LeastYearsOfExperience,
                MilitaryServiceStatus = advertisement.MilitaryServiceStatus,
                NotVerifiedDescription = advertisement.NotVerificationDescription,
                SalaryAmountID = advertisement.SalaryID,
                CompanyName = advertisement.Company?.CompanyName,
                AvatarAddress = advertisement.Company?.AvatarAddress,
                Salary = advertisement.SalaryAmount?.SalaryExplanation,
                JobCategoryName = advertisement.JobCategory?.CategoryName,
                CityName = advertisement.City?.CityName,
                EditionStatus = advertisement.EditionStatus
            };
        }   
    }
}
