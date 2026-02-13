using Microsoft.AspNetCore.Components.Web;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public LocationService(ILocationRepository masterLocationRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _locationRepository = masterLocationRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<bool> AddLocation(MasterLocation location)
        {
            try
            {
                var res = await _locationRepository.AddLocation(location);
                if (res != null)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteLocation(int id)
        {
            var result = await _locationRepository.GetLocationyId(id);
            if (result != null)
            {
                if (result.StatusId == (int)EStatus.IsActive)
                    result.StatusId = (int)EStatus.Deleted;
                else
                    result.StatusId = (int)EStatus.IsActive;
                await _locationRepository.DeleteLocation(result);
                return 1;
            }
            return 0;
        }

        public async Task<PageList<LocationResponseDto>> GetAllLocation(PagingParam pagingParam)
        {
            var result = await _locationRepository.GetAllLocation(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.Location.ToString());
            return result;
        }

        public async Task<MasterLocation> GetLocationyId(int id)
        {
            return await _locationRepository.GetLocationyId(id);
        }

        public async Task UpdateLocation(MasterLocation location)
        {
            await _locationRepository.UpdateLocation(location);
        }
        public async Task<List<LocationResponseDto>> GetAllLocationList(int companyId)
        {
            return await _locationRepository.GetAllLocationList(companyId);
        }
    }
}
