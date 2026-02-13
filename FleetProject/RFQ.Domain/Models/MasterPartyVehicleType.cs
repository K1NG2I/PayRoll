using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_party_vehicle_type")]
    public class MasterPartyVehicleType
    {
        [Key]
        public int PartyVehicleTypeId { get; set; }
        public int PartyId { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
