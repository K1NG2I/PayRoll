using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_user_activity_log")]
    public class MasterUserActivityLog
    {
        [Key]
        public int UserActivityLogId { get; set; }

        public int LogUid { get; set; }

        public int LogLinkId { get; set; }

        public int LogTypeId { get; set; }

        public int UserId { get; set; }

        public DateTime? LogDateTime { get; set; } = DateTime.Now;

        public string? Description { get; set; }





    }
}
