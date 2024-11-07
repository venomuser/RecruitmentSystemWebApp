using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.Enums
{
    public enum CooperationTypeOptions
    {
        [Display(Name ="تمام وقت")]
        FullTime,
        [Display(Name ="پاره وقت")]
        PartTime,
        [Display(Name = "دورکاری")]
        Remote
    }
}
