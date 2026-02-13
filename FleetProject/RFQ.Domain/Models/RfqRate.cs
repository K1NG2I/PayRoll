using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_trn_rfq_rate")]
    public class RfqRate
    {
        [Key]
        public int RfqRateId { get; set; }
        public int RfqId { get; set; }
        public int VendorId { get; set; }
        public int AvailVehicleCount { get; set; }
        public int TotalHireCost { get; set; }
        public int DetentionPerDay { get; set; }
        public int DetentionFreeDays { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
