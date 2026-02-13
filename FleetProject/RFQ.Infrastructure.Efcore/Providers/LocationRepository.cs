using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class LocationRepository : ILocationRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly ICommonRepositroy _commonRepositroy;

        public LocationRepository(FleetLynkDbContext appDbContext, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _commonRepositroy = commonRepositroy;
        }

        public async Task<MasterLocation> AddLocation(MasterLocation location)
        {
            await _appDbContext.masterLocation.AddAsync(location);
            await _appDbContext.SaveChangesAsync();
            return location;

        }

        public async Task DeleteLocation(MasterLocation location)
        {
            _appDbContext.masterLocation.Update(location);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<PageList<LocationResponseDto>> GetAllLocation(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<LocationResponseDto>(StoredProcedureHelper.sp_GetLocationList, pagingParam);
        }

        public async Task<List<LocationResponseDto>> GetAllLocationList(int companyId)
        {
            var query = from location in _appDbContext.masterLocation
                        join city in _appDbContext.company_city
                        on location.CityId equals city.CityId
                        where location.StatusId == (int)EStatus.IsActive && location.CompanyId == companyId
                        select new LocationResponseDto
                        {
                            LocationId = location.LocationId,
                            CompanyId = location.CompanyId ?? 0,
                            LocationName = location.LocationName,
                            AddressLine = location.AddressLine,
                            CityId = location.CityId,
                            City = city.CityName,
                            PinCode = location.PinCode,
                            ContactPerson = location.ContactPerson,
                            ContactNo = location.ContactNo,
                            MobNo = location.MobNo,
                            WhatsAppNo = location.WhatsAppNo,
                            Email = location.Email,
                            LinkId = location.LinkId,
                            StatusId = location.StatusId,
                            CreatedBy = location.CreatedBy,
                            CreatedOn = location.CreatedOn,
                            UpdatedBy = location.UpdatedBy,
                            UpdatedOn = location.UpdatedOn,
                        };
            return await query.OrderByDescending(x => x.UpdatedOn).ToListAsync();
        }

        public async Task<MasterLocation?> GetLocationyId(int id)
        {
            return await _appDbContext.masterLocation.Where(x => x.LocationId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateLocation(MasterLocation location)
        {
            try
            {
                var masterLocation = await GetLocationyId(location.LocationId);
                if (masterLocation != null)
                {
                    location.CreatedOn = masterLocation.CreatedOn;
                    location.UpdatedOn = DateTime.Now;
                    location.StatusId = masterLocation.StatusId;
                    _appDbContext.masterLocation.Update(location);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MasterLocation?>> GetTableLocationList(int companyId)
        {
            return await _appDbContext.masterLocation.Where(x => x.CompanyId == companyId).ToListAsync();
        }
    }
}
