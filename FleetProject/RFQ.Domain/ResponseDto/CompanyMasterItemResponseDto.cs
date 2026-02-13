namespace RFQ.Domain.ResponseDto
{
    public class CompanyMasterItemResponseDto
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string? IsActive { get; set; }
    }
}
