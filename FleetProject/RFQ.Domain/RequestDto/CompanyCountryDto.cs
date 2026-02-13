namespace RFQ.Domain.RequestDto
{
    public class CompanyCountryDto
    {
        public string? Code { get; set; }
        public string? CountryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
