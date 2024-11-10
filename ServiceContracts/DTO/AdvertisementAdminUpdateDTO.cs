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

       

        public Guid? AdvertisementID { get; set; }


        //[Required(ErrorMessage = "وضعیت انتشار آگهی باید مشخص شود")]
        public bool? IsVerified { get; set; }

        public string? NoVerificationDescription { get; set; }

        public Guid? EditionStatus {  get; set; }

        
    }
}
