namespace RFQ.Domain.Helper
{
    public class RfqVendorDetailsParam
    {
        public string OriginFrom { get; set; }
        public string ToDestination { get; set; }
        public int VehicleTypeId { get; set; }
        public int RfqId { get; set; }
    }
}
