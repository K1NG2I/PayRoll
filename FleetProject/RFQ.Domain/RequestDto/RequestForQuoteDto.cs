namespace RFQ.Domain.RequestDto
{
    public class RequestForQuoteDto
    {
        public RfqDto RfqRequestDto { get; set; }
        public List<RfqRecipientRequestDto> RfqRecipients { get; set; } = new List<RfqRecipientRequestDto>();
    }
}
