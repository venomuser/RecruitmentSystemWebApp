using Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Entities
{
    public class Advertisement
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City? City { get; set; }

        [StringLength(40)]
        public string? Gender { get; set; }

        [StringLength(50)]
        public string? MilitaryServiceStatus { get; set; }
        public int? LeastYearsOfExperience { get; set; }

        [StringLength(50)]
        public string? LeastAcademicDegree { get; set; }

        [StringLength(700)]
        public string? Description { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }
        public Guid? JobCategoryId { get; set; }

        [ForeignKey(nameof(JobCategoryId))]
        public JobCategory? JobCategory { get; set; }
        public bool? IsVerified { get; set; }
        public Guid? CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
    }
}
