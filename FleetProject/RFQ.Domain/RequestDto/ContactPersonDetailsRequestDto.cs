using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.UI.Domain.RequestDto
{
    public class ContactPersonDetailsRequestDto
    {
        public int ContactPersonDetailId { get; set; }   // 0 for Add

        public int EmployeeId { get; set; }

        public string Relation { get; set; }

        public string ContactPersonName { get; set; }

        public string AadhaarNumber { get; set; }

        public string PanNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
