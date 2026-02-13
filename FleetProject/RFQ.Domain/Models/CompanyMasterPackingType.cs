using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_packing_type")]
    public class CompanyMasterPackingType
    {
        [Key]
        public int PackingId { get; set; }
        public string? PackingName { get; set; }
        public string? Description { get; set; }

    }
}
