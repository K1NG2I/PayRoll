using RFQ.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_country")]
    public class CompanyCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string CountryName { get; set; }
        public int StatusId { get; set; } = (int)EStatus.IsActive;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
