using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyProfileRepository : ICompanyProfileRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        public CompanyProfileRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task UpdateProfile(CompanyProfile profile)
        {
            _appDbContext.company_profile.Update(profile);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<CompanyProfile> AddProfile(CompanyProfile profile)
        {
            await _appDbContext.company_profile.AddAsync(profile);
            await _appDbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<IEnumerable<CompanyProfile>> GetAllProfile()
        {
            return await _appDbContext.company_profile.ToListAsync();
        }

        public Task<CompanyProfile> GetProfileById(int id)
        {
            return _appDbContext.company_profile.Where(x => x.ProfileId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task DeleteProfile(CompanyProfile profile)
        {
            _appDbContext.company_profile.Update(profile);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
