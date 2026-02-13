using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_profile")]
    public class CompanyProfile
    {
        [Key]
        public int ProfileId { get; set; }
        public string? ProfileName { get; set; }
        public int CompanyTypeId { get; set; }
    }
}
