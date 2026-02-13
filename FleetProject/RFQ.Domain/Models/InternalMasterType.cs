using Microsoft.EntityFrameworkCore;

namespace RFQ.Domain.Models
{
    [Keyless]
    public class InternalMasterType
    {
        public int MasterTypeId { get; set; }
        public string MasterTypeName { get; set; }
    }
}
