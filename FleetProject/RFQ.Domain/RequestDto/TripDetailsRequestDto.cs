using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.RequestDto
{
    public class TripDetailsRequestDto
    {
        public string? EWayBillExpiryDate { get; set; }
        public int? CompanyId { get; set; }
    }
}
