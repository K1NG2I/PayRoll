using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Models
{
    [Table("com_trn_rfq_link")]
    public class RfqLink
    {
        [Key]
        public int RfqRateLinkId { get; set; }
        public int RfqId { get; set; }
        public int VendorId { get; set; }
        public string SharedLink { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
