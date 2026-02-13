using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class MasterPartyRouteRepository : IMasterPartyRouteRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public MasterPartyRouteRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddMasterPartyRoute(List<MasterPartyRoute> partyRoutes)
        {
            await _appDbContext.masterPartyRoute.AddRangeAsync(partyRoutes);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteMasterPartyRoute(MasterPartyRoute partyRoute)
        {
            _appDbContext.masterPartyRoute.Remove(partyRoute);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteMasterPartyRouteByPartyId(int id)
        {
            var partyRoutes = await _appDbContext.masterPartyRoute.Where(x => x.PartyId == id).ToListAsync();
            if (partyRoutes.Any())
            {
                _appDbContext.masterPartyRoute.RemoveRange(partyRoutes);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MasterPartyRoute>> GetAllMasterPartyRoute()
        {
            return await _appDbContext.masterPartyRoute.AsNoTracking().ToListAsync();
        }

        public async Task<MasterPartyRoute> GetMasterPartyRouteById(int id)
        {
            return await _appDbContext.masterPartyRoute.Where(x => x.PartyRouteId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MasterPartyRouteResponseDto>> GetMasterPartyRouteByPartyId(int id)
        {
            var query = from m in _appDbContext.masterPartyRoute.AsNoTracking()
                        join c in _appDbContext.company_city.AsNoTracking() on m.FromCityId equals c.CityId
                        join fs in _appDbContext.company_State.AsNoTracking() on m.FromStateId equals fs.StateId
                        join ts in _appDbContext.company_State.AsNoTracking() on m.ToStateId equals ts.StateId 
                        where m.PartyId == id
                        select new MasterPartyRouteResponseDto
                        {
                            PartyRouteId = m.PartyRouteId,
                            PartyId = m.PartyId,
                            FromCityId = m.FromCityId,
                            FromCityName = c.CityName,
                            FromStateId = m.FromStateId,
                            FromStateName = fs.StateName,
                            ToStateId = m.ToStateId,
                            ToStateName = ts.StateName
                        };
            return await query.ToListAsync();
        }

        public async Task UpdateMasterPartyRoute(List<MasterPartyRoute> partyRoute)
        {
            _appDbContext.masterPartyRoute.UpdateRange(partyRoute);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
