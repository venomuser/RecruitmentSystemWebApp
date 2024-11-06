using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityEntities
{
    public class SiteAdministrator : ApplicationUser
    {
        [StringLength(50)]
        public string? AdminName { get; set; }
    }
}
