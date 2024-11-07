using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Enums
{
    public enum AcademicDegrees
    {
        [Display(Name ="مهم نیست")]
        مهم_نیست,
        [Display(Name = "زیر دیپلم")]
        زیر_دیپلم,
        [Display(Name = "دیپلم")]
        دیپلم,
        [Display(Name = "فوق دیپلم")]
        فوق_دیپلم,
        [Display(Name = "لیسانس")]
        لیسانس,
        [Display(Name = "فوق لیسانس")]
        فوق_لیسانس,
        [Display(Name = "دکترا و بالاتر")]
        دکترا
    }
}
