namespace RFQ.Domain.RequestDto
{
    public class CompanyStateDto
    {
        public string? Code { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }
        public string? NsdlCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
