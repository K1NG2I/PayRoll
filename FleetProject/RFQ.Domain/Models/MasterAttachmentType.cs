using System.ComponentModel.DataAnnotations;

namespace RFQ.Domain.Models
{
    public class MasterAttachmentType
    {
        [Key]
        public int AttachmentTypeId { get; set; }

        public string? AttachmentTypeName { get; set; }

        public int LinId { get; set; }
    }
}
