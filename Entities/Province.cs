using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Province
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? ProvinceName { get; set; }
    }
}
