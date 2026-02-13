using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_link_group")]
    public class LinkGroup
    {
        [Key]
        public int LinkGroupId { get; set; }
        public string LinkGroupName { get; set; }
        public int SequenceNo { get; set; }
        public string LinkIcon { get; set; }
    }
}
