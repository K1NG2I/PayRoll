namespace RFQ.Domain.RequestDto
{
    public class MasterMessageTemplateDto
    {
        public int CompanyId { get; set; }

        public int EventTypeId { get; set; }

        public string? EmailTemplate { get; set; }

        public string? SmsTemplate { get; set; }

        public string? WhatsAppTemplate { get; set; }
    }
}
