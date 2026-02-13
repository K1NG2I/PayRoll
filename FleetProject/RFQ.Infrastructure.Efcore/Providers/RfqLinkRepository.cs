using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class RfqLinkRepository : IRfqLinkRepository
    {
        private readonly FleetLynkDbContext _fleetLynkDbContext;
        public RfqLinkRepository(FleetLynkDbContext fleetLynkDbContext)
        {
            _fleetLynkDbContext = fleetLynkDbContext;
        }
        public async Task<IEnumerable<RfqLink>> AddRfqLink(List<RfqLink> rfqLinks)
        {
            await _fleetLynkDbContext.rfqLinks.AddRangeAsync(rfqLinks);
            await _fleetLynkDbContext.SaveChangesAsync();
            return rfqLinks;
        }
    }
}
