using System.ComponentModel.DataAnnotations;

namespace RFQ.Domain.Models
{
    public class CompanyMasterPartyVehicleType
    {
        [Key]
        public int PartyVehicleTypeId { get; set; }
        public int PartyId { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
