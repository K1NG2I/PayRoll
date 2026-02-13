using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyMasterPackingTypeRepository : ICompanyMasterPackingTypeRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public CompanyMasterPackingTypeRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CompanyMasterPackingType> AddMasterPackingType(CompanyMasterPackingType masterPackingType)
        {
            await _appDbContext.companyMasterPackingType.AddAsync(masterPackingType);
            await _appDbContext.SaveChangesAsync();
            return masterPackingType;
        }

        public async Task DeletemasterPackingType(CompanyMasterPackingType masterPackingType)
        {
            _appDbContext.companyMasterPackingType.Update(masterPackingType);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<CompanyMasterPackingType>> GetAllMasterPackingType()
        {
            return await _appDbContext.companyMasterPackingType.AsNoTracking().ToListAsync();
        }

        public async Task<CompanyMasterPackingType> GetMasterPackingTypeById(int id)
        {
            return await _appDbContext.companyMasterPackingType.Where(x => x.PackingId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdatemasterPackingType(CompanyMasterPackingType masterPackingType)
        {
            _appDbContext.companyMasterPackingType.Update(masterPackingType);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
