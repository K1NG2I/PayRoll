using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyStateRepository : ICompanyStateRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public CompanyStateRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<CompanyState>> GetAllState()
        {
            return await _appDbContext.company_State.Where(x => x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }

        public Task<CompanyState> GetStateById(int id)
        {
            return _appDbContext.company_State.Where(x => x.StateId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateState(CompanyState state)
        {
            _appDbContext.company_State.Update(state);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<CompanyState> AddState(CompanyState state)
        {
            await _appDbContext.company_State.AddAsync(state);
            await _appDbContext.SaveChangesAsync();
            return state;
        }




        public async Task DeleteState(CompanyState state)
        {
            _appDbContext.company_State.Update(state);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
