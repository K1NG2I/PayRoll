using RFQ.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_city")]
    public class CompanyCity
    {
        [Key]
        public int CityId { get; set; }
        public string Code { get; set; }
        public string CityName { get; set; }
        public int StatusId { get; set; } = (int)EStatus.IsActive;
        public int StateId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
