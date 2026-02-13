using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.RequestDto
{
   public class UpdateUserPasswordDto
    {
        public string? LoginId { get; set; }
        public int UserId { get; set; }
        public string? Password { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
