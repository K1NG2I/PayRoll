namespace RFQ.Domain.RequestDto
{
    public class RfqVendorDto
    {
        public int RfqDetailsId { get; set; }
        public int VendorId { get; set; }
        public int VendorRating { get; set; }
        public string? MobNo { get; set; }
        public string? WhatsAppNo { get; set; }
        public string? Email { get; set; }
    }
}
