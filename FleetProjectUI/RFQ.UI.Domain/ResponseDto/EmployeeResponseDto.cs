namespace RFQ.UI.Domain.ResponseDto
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public string? FullName { get; set; }
        public string? ContactNumber { get; set; }
        public string? AadhaarNumber { get; set; }
        public string? PanNumber { get; set; }
        public string? Salary { get; set; }
        public string? HireDate { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
