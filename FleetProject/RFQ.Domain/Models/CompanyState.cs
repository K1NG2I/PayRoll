using RFQ.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_state")]
    public class CompanyState
    {
        [Key]
        public int StateId { get; set; }
        public string Code { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public string NsdlCode { get; set; }
        public int StatusId { get; set; } = (int)EStatus.IsActive;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
