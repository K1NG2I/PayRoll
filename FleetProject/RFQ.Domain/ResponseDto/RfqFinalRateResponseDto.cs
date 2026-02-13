namespace RFQ.Domain.ResponseDto
{
    public class RfqFinalRateResponseDto
    {
        public int RfqFinalRateId { get; set; }
        public int RfqFinalId { get; set; }
        public int RfqId { get; set; }
        public int VendorId { get; set; }
        public string? PANNo { get; set; }
        public string? VendorName { get; set; }
        public string? MobNo { get; set; }
        public string? WhatsAppNo { get; set; }
        public string? Email { get; set; }
        public int VehicleCount { get; set; }
        public int TotalHireCost { get; set; }
        public int DetentionPerDay { get; set; }
        public int DetentionFreeDays { get; set; }
        public int AvailVehicleCount { get; set; }
        public int AssignedVehicles { get; set; }
        public bool IsAssigned { get; set; }
    }
}
