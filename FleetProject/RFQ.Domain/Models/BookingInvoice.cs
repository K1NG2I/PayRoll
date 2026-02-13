using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Models
{
    [Table("com_trn_booking_invoice")]
    public class BookingInvoice
    {
        [Key]
        public int BookingInvoiceId { get; set; }
        public int? BookingId { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? InvoiceValue { get; set; }
        public string? EWayBillNo { get; set; }
        public DateTime? EWayBillDate { get; set; }
        public DateTime? EWayBillExpiryDate { get; set; }
    }
}
