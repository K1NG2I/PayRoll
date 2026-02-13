namespace RFQ.Domain.ResponseDto
{
    public class RfqPreviousQuotesList
    {
        public string? PartyName { get; set; }
        public string? PANNo { get; set; }
        public string? VendorRating { get; set; }
        public string? RfqDate { get; set; }
        public int? TotalHireCost { get; set; }
    }
}
