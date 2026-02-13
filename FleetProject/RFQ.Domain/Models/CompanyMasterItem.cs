using RFQ.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_item")]
    public class CompanyMasterItem
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? CompanyId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
