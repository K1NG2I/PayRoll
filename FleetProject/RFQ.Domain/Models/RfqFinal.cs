using RFQ.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_trn_rfq_final")]
    public class RfqFinal
    {
        [Key]
        public int RfqFinalIdId { get; set; }
        public string RfqId { get; set; }
        public int RfqStatusId { get; set; }
        public int ReasonId { get; set; }
        public int BillingRate { get; set; }
        public int DetentionPerDay { get; set; }
        public int DetentionFreeDays { get; set; }
        public int MarginAmount { get; set; }
        public string? Remarks { get; set; }
        public int LinkId { get; set; }
        public int StatusId { get; set; } 
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
