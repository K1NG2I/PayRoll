using System.ComponentModel.DataAnnotations;

namespace RFQ.Domain.Models
{
    /// <summary>
    /// Entity for table com_mst_employee.
    /// </summary>
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string AadhaarNumber { get; set; }
        public string PanNumber { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
