using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityEntities
{
    public class Company : ApplicationUser
    {
        [StringLength(50)]
        public string? CompanyName { get; set; }
        public string? AvatarAddress { get; set; }

        [StringLength(500)]
        public string? CompanyAddress {  get; set; }

        [StringLength(1000)]
        public string? CompanyDescription { get; set; }
    }
}
