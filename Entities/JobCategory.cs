using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
