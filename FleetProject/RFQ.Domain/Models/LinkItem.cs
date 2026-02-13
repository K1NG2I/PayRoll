using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{

    [Table("com_mst_link_item")]
    public class LinkItem
    {
        [Key]
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        public string ListingQuery { get; set; }
        public int LinkGroupId { get; set; }
        public string LinkIcon { get; set; }
        public int SequenceNo { get; set; }
        public string LinkUrl { get; set; }
        public string AddUrl { get; set; }
        public string EditUrl { get; set; }
        public string CancelUrl { get; set; }
        public int StatusId { get; set; }
    }
}
