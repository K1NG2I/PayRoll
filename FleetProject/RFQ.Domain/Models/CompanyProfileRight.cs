using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_profile_right")]
    public class CompanyProfileRight
    {
        [Key]
        public int UserProfileRightId { get; set; }
        public int ProfileId { get; set; }
        public int LinkId { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsView { get; set; }
        public bool IsCancel { get; set; }
    }
}
