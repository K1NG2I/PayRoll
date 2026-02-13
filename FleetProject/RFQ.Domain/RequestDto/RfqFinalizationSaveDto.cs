namespace RFQ.Domain.RequestDto
{
    public class RfqFinalizationSaveDto
    {
        public RfqFinalDto? RfqFinalDto { get; set; }
        public List<RfqFinalRateDto>? RfqFinalRateDtos { get; set; }
    }
}
