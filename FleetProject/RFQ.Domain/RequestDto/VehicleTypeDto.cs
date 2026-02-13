namespace RFQ.Domain.RequestDto
{
    public class VehicleTypeDto
    {
        public int VehicleTypeId { get; set; }
        public int? CompanyId { get; set; }
        public string? VehicleTypeName { get; set; }
        public int? MinimumKms { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int StatusId { get; set; }
    }
}
