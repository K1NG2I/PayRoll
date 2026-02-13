namespace RFQ.Domain.RequestDto
{
    public class RfqFinalRateDto
    {
        public int RfqFinalRateId { get; set; }
        public int RfqFinalId { get; set; }
        public int RfqId { get; set; }
        public int VendorId { get; set; }
        public int AvailVehicleCount { get; set; }
        public int AssignedVehicles { get; set; }
        public bool IsAssigned { get; set; }
    }
}
