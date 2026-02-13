using RFQ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Models
{
    [Table("com_trn_placement")]
    public class VehiclePlacement
    {
        [Key]
        public int PlacementId { get; set; }
        public string PlacementNo { get; set; }
        public int CompanyId { get; set; }
        public int LocationId { get; set; }
        public DateTime PlacementDate { get; set; }
        public int IndentId { get; set; }
        public int VehicleId { get; set; }
        public int TrackingTypeId { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string MobileNo { get; set; }
        public int? OwnerVendorId { get; set; }
        public int? BrokerVendorId { get; set; }
        public int? TotalHireAmount { get; set; }
        public int? AdvancePayable { get; set; }
        public int LinkId { get; set; }
        public int StatusId { get; set; } = (int)EStatus.IsActive;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
