using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class MasterPartyService : IMasterPartyService
    {
        private readonly IMasterPartyRepository _masterPartyRepository;
        private readonly IMasterPartyRouteRepository _masterPartyRouteRepository;
        private readonly IMasterPartyVehicleTypeRepository _masterPartyVehicleTypeRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public MasterPartyService(IMasterPartyRepository masterPartyRepository, IMasterPartyRouteRepository masterPartyRouteRepository, IMasterPartyVehicleTypeRepository masterPartyVehicleTypeRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _masterPartyRepository = masterPartyRepository;
            _masterPartyRouteRepository = masterPartyRouteRepository;
            _masterPartyVehicleTypeRepository = masterPartyVehicleTypeRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<MasterParty> AddMasterParty(MasterParty party, List<MasterPartyVehicleType> masterPartyVehicleType, List<MasterPartyRoute> masterPartyRoute)
        {
            try
            {
                if (masterPartyRoute == null || masterPartyVehicleType == null)
                {
                    return await _masterPartyRepository.AddMasterParty(party);
                }
                var partyResult = await _masterPartyRepository.AddMasterParty(party);
                if (partyResult != null)
                {
                    masterPartyVehicleType.ForEach(x => x.PartyId = partyResult.PartyId);
                    masterPartyRoute.ForEach(x => x.PartyId = partyResult.PartyId);
                    await _masterPartyVehicleTypeRepository.AddMasterPartyVehicleType(masterPartyVehicleType);
                    await _masterPartyRouteRepository.AddMasterPartyRoute(masterPartyRoute);
                    return partyResult;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<int> DeleteMasterParty(int id)
        {
            var result = await _masterPartyRepository.GetexistingMasterPartyById(id);
            if (result != null)
            {
                if (result.StatusId == (int)EStatus.IsActive)
                    result.StatusId = (int)EStatus.Deleted;
                else
                    result.StatusId = (int)EStatus.IsActive;

                await _masterPartyRepository.DeleteMasterParty(result);
                await _masterPartyRouteRepository.DeleteMasterPartyRouteByPartyId(id);
                await _masterPartyVehicleTypeRepository.DeleteMasterVehicleTypeByPartyId(id);
                return 1;
            }
            return 0;
        }

        public async Task<PageList<MasterPartyResponse>> GetAllCustomer(PagingParam pagingParam)
        {
            var result = await _masterPartyRepository.GetAllCustomer(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.Customer);
            return result;
        }
        public async Task<PageList<MasterPartyResponse>> GetAllVendor(PagingParam pagingParam)
        {
            var result = await _masterPartyRepository.GetAllVendor(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.Vendor);
            return result;
        }

        public async Task<MasterParty> GetMasterPartyById(int id)
        {
            return await _masterPartyRepository.GetMasterPartyById(id);
        }

        public async Task<MasterParty> UpdateMasterParty(MasterParty party, List<MasterPartyVehicleType> masterPartyVehicleType, List<MasterPartyRoute> masterPartyRoute)
        {
            if (masterPartyRoute == null || masterPartyVehicleType == null)
            {
                return await _masterPartyRepository.UpdateMasterParty(party);
            }
            var saveVehicleTypeList = new List<MasterPartyVehicleType>();
            var updateVehicleTypeList = new List<MasterPartyVehicleType>();
            var saveRouteList = new List<MasterPartyRoute>();
            var updateRouteList = new List<MasterPartyRoute>();
            foreach (var vehicleType in masterPartyVehicleType)
            {
                if (vehicleType.PartyVehicleTypeId != 0)
                {
                    updateVehicleTypeList.Add(vehicleType);
                }
                else
                {
                    saveVehicleTypeList.Add(vehicleType);
                }
            }
            foreach (var route in masterPartyRoute)
            {
                if (route.PartyRouteId != 0)
                {
                    updateRouteList.Add(route);
                }
                else
                {
                    saveRouteList.Add(route);
                }
            }
            var partyResult = await _masterPartyRepository.UpdateMasterParty(party);
            if (partyResult != null)
            {
                saveVehicleTypeList.ForEach(x => x.PartyId = partyResult.PartyId);
                saveRouteList.ForEach(x => x.PartyId = partyResult.PartyId);
                await _masterPartyVehicleTypeRepository.AddMasterPartyVehicleType(saveVehicleTypeList);
                await _masterPartyRouteRepository.AddMasterPartyRoute(saveRouteList);
                await _masterPartyVehicleTypeRepository.UpdateMasterPartyVehicleType(updateVehicleTypeList);
                await _masterPartyRouteRepository.UpdateMasterPartyRoute(updateRouteList);
                return partyResult;
            }
            return null;
        }

        public async Task<IEnumerable<MasterParty>> GetDrpCustomerList(int companyId)
        {
            return await _masterPartyRepository.GetDrpCustomerList(companyId);
        }
        public async Task<List<VendorListResponseDto>> GetAllVendorList(int companyId)
        {
            return await _masterPartyRepository.GetAllVendorList(companyId);
        }
        public async Task<string> GetAutoCustomerCode(int UserId)
        {
            return await _masterPartyRepository.GetAutoCustomerCode(UserId);
        }
    }
}
