namespace RFQ.Domain.RequestDto
{
    public class GetEmployeeByIdRequest
    {
        public int Id { get; set; }
    }

    public class GetEmployeeByPanRequest
    {
        public string PanNumber { get; set; } = string.Empty;
    }

    public class GetEmployeeByAadhaarRequest
    {
        public string AadhaarNumber { get; set; } = string.Empty;
    }
}
