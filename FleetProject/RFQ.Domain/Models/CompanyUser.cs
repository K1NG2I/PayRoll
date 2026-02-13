using Microsoft.AspNetCore.Authorization;
using RFQ.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_user")]
    public class CompanyUser
    {
        [Key]
        public int UserId { get; set; }
        public int? CompanyId { get; set; }
        public int? LocationId { get; set; }
        public int? ProfileId { get; set; }
        public string? PersonName { get; set; } = string.Empty;
        public string? LoginId { get; set; }
        public string? Password { get; set; }
        public string? EmailId { get; set; } = string.Empty;
        public string? MobileNo { get; set; }
        public int? StatusId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
    }
}

