using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyCountryRepository : ICompanyCountryRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public CompanyCountryRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<CompanyCountry>> GetAllCountry()
        {
            return await _appDbContext.company_country.Where(x => x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }

        public Task<CompanyCountry> GetCountryById(int id)
        {
            return _appDbContext.company_country.Where(x => x.CountryId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateCountry(CompanyCountry country)
        {
            _appDbContext.company_country.Update(country);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<CompanyCountry> AddCountry(CompanyCountry country)
        {
            await _appDbContext.company_country.AddAsync(country);
            await _appDbContext.SaveChangesAsync();
            return country;
        }

        public async Task DeleteCountry(CompanyCountry country)
        {
            _appDbContext.company_country.Update(country);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<LocationData>> GetStatesAndCitiesByCountry()
        {
            var locationData = await (from country in _appDbContext.company_country
                                join state in _appDbContext.company_State on country.CountryId equals state.CountryId
                                join city in _appDbContext.company_city on state.StateId equals city.StateId
                                where country.StatusId == (int)EStatus.IsActive && state.StatusId == (int)EStatus.IsActive && city.StatusId == (int)EStatus.IsActive
                                      select new LocationData
                                {
                                    CountryId = country.CountryId,
                                    CountryName = country.CountryName,
                                    StateId = state.StateId,
                                    StateName = state.StateName,
                                    CityId = city.CityId,
                                    CityName = city.CityName
                                }).ToListAsync();

            return locationData;
        }

    }
}
