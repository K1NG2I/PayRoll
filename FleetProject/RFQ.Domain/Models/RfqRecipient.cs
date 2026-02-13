using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_trn_rfq_recipient")]
    public class RfqRecipient
    {
        [Key]
        public int RfqRecipientId { get; set; }
        public int RfqId { get; set; }
        public int VendorId { get; set; }
        public string PanNo { get; set; }
        public int VendorRating { get; set; }
        public string MobNo { get; set; }
        public string WhatsAppNo { get; set; }
        public string EmailId { get; set; }
    }
}
