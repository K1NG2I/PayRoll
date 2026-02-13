namespace RFQ.Domain.ResponseDto
{
    public class VehicleTypeResponseDto
    {
        public int VehicleTypeId { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? VehicleTypeName { get; set; }
        public int? MinimumKms { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int StatusId { get; set; }
        public string? IsActive { get; set; }
    }
}
