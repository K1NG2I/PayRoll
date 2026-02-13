using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.ResponseDto
{
    public class BookingInvoiceResponseDto
    {
        public int BookingInvoiceId { get; set; }
        public int BookingId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceValue { get; set; }
        public string EWayBillNo { get; set; }
        public DateTime EWayBillDate { get; set; }
        public DateTime EWayBillExpiryDate { get; set; }
    }
}
