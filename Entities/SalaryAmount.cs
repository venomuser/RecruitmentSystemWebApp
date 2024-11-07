using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SalaryAmount
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string? SalaryExplanation { get; set; }
    }
}
