using System.ComponentModel.DataAnnotations;

namespace RFQ.Domain.Models
{
    public class MasterMessageTemplate
    {
        [Key]
        public int TemplateId { get; set; }

        public int CompanyId { get; set; }

        public int EventTypeId { get; set; }

        public string? EmailTemplate { get; set; }

        public string? SmsTemplate { get; set; }

        public string? WhatsAppTemplate { get; set; }
    }
}
