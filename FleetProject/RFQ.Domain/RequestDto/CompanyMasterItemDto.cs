namespace RFQ.Domain.RequestDto
{
    public class CompanyMasterItemDto
    {
        public string? ItemName { get; set; }
        public int? CompanyId { get; set; }
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
