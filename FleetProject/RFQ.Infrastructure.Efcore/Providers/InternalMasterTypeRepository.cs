using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class InternalMasterTypeRepository : IInternalMasterTypeRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public InternalMasterTypeRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<InternalMasterType> AddInternalMasterType(InternalMasterType masterType)
        {
            _appDbContext.Add(masterType);
            await _appDbContext.SaveChangesAsync();
            return masterType;

        }

        public async Task DeleteInternalMasterType(InternalMasterType masterType)
        {
            _appDbContext.Update(masterType);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<InternalMasterType>> GetAllInternalMasterType()
        {
            return await _appDbContext.internalMasterTypes.AsNoTracking().ToListAsync();
        }

        public async Task<InternalMasterType> GetInternalMasterTypeId(int id)
        {
            return await _appDbContext.internalMasterTypes.Where(x => x.MasterTypeId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateInternalMasterType(InternalMasterType masterType)
        {
            _appDbContext.internalMasterTypes.Update(masterType);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
