using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.UI.Domain.RequestDto
{
    public class EmployeeUpdateRequestDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string AadhaarNumber { get; set; }
        public string PanNumber { get; set; }
        public decimal? Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
    }
}
