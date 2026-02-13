using RFQ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Models
{
    [Table("com_trn_delivery")]
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        public string DeliveryNo { get; set; }
        public int? CompanyId { get; set; }
        public int LocationId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int BookingId { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime UnloadDateTime { get; set; }
        public int? DeliveredPackets { get; set; }
        public int? DeliveredWeight { get; set; }
        public string? Signature { get; set; }
        public int LinkId { get; set; }
        public int StatusId { get; set; } = (int)EStatus.IsActive;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

    }
}
