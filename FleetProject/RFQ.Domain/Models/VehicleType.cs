using RFQ.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_vehicle_type")]
    public class VehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public int? CompanyId { get; set; }
        public string? VehicleTypeName { get; set; }
        public int? MinimumKms { get; set; }
        public int StatusId { get; set; } 
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

    }
}
