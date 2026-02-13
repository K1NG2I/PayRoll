using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class InternalMasterRepository : IInternalMasterRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        public InternalMasterRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<InternalMaster>> GetAllInternalMaster()
        {
            return await _appDbContext.internalMaster.AsNoTracking().ToListAsync();
        }
    }
}
