using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.Enums
{
    public enum GenderOptions
    {
        [Display(Name = "مرد")]
        Male,
        [Display(Name ="زن")]
        Female,
        [Display(Name ="مهم نیست")]
        NotImportant
    }
}
