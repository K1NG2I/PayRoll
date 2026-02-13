using RFQ.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RFQ.Domain.Models
{
    public class MasterLocation
    {
        [Key]
        public int LocationId { get; set; }
        public int? CompanyId { get; set; }
        public string? LocationName { get; set; }
        public string? AddressLine { get; set; }
        public int CityId { get; set; }
        public string? PinCode { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactNo { get; set; }
        public string? MobNo { get; set; }
        public string? WhatsAppNo { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Code { get; set; }
        public int LinkId { get; set; }
        public int StatusId { get; set; } 
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
