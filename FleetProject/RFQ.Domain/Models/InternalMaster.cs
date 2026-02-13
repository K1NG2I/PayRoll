using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_internal_master")]
    public class InternalMaster
    {
        [Key]
        public int InternalMasterId { get; set; }
        public int InternalMasterTypeId { get; set; }
        public string InternalMasterName { get; set; }

    }
}
