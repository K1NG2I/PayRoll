using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQ.Domain.Models
{
    [Table("com_mst_party_route")]
    public class MasterPartyRoute
    {
        [Key]
        public int PartyRouteId { get; set; }

        public int PartyId { get; set; }

        public int FromCityId { get; set; }

        public int FromStateId { get; set; }

        public int ToStateId { get; set; }
    }
}
