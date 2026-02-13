using System.ComponentModel.DataAnnotations;

namespace RFQ.Domain.Models
{
    /// <summary>
    /// Entity for table com_mst_contactpersondetails.
    /// </summary>
    public class ContactPersonDetails
    {
        [Key]
        public int ContactPersonId { get; set; }
        public int EmployeeId { get; set; }
        public string Relation { get; set; }
        public string ContactPersonName { get; set; }
        public string AadhaarNumber { get; set; }
        public string PanNumber { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
