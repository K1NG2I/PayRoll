using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyCityRepository : ICompanyCityRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public CompanyCityRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CompanyCity> GetCityById(int id)
        {
            return await _appDbContext.company_city.Where(x => x.CityId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CompanyCity>> GetAllCity()
        {
            return await _appDbContext.company_city.Where(x => x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<CompanyCity> AddCity(CompanyCity city)
        {
            await _appDbContext.company_city.AddAsync(city);
            await _appDbContext.SaveChangesAsync();
            return city;
        }

        public async Task UpdateCity(CompanyCity city)
        {
            _appDbContext.company_city.Update(city);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCity(CompanyCity city)
        {
            _appDbContext.company_city.Update(city);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
