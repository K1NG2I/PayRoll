using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_trn_rfq_final_rate")]
    public class RfqFinalRate
    {
        [Key]
        public int RfqFinalRateId { get; set; }
        public int RfqFinalId { get; set; }
        public int RfqId { get; set; }
        public int VendorId { get; set; }
        public int AvailVehicleCount { get; set; }
        public int AssignedVehicles { get; set; }
        public bool IsAssigned { get; set; }
    }
}
