using Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class JobCategory
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string? CategoryName { get; set; }
        public Guid? UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser? User { get; set; }
    }
}
