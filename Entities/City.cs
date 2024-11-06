using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class City
    {
        [Key]
        public long? Id { get; set; }

        [StringLength(50)]
        public string? CityName { get; set; }
        public Guid? ProvinceId { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        public Province? Province { get; set; }
    }
}
