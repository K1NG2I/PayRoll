using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Collections.Generic;

namespace RFQ.Application.Provider
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _masterVehicleTypeRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public VehicleTypeService(IVehicleTypeRepository masterVehicleTypeRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _masterVehicleTypeRepository = masterVehicleTypeRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<CommanResponseDto> AddVehicleType(VehicleType vehicleType)
        {
            return await _masterVehicleTypeRepository.AddVehicleType(vehicleType);
        }

        public async Task<int> DeleteVehicleType(int id)
        {
            var result = await _masterVehicleTypeRepository.GetExistingVehicleTypeById(id);
            if (result != null)
            {
                if (result.StatusId == (int)EStatus.IsActive)
                    result.StatusId = (int)EStatus.Deleted;
                else
                    result.StatusId = (int)EStatus.IsActive;
                await _masterVehicleTypeRepository.DeleteVehicleType(result);
                return 1;
            }
            return 0;
        }

        public async Task<PageList<VehicleTypeResponseDto>> GetAllVehicleType(PagingParam pagingParam)
        {
            var result = await _masterVehicleTypeRepository.GetAllVehicleType(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.VehicleType.ToString());
            return result;
        }

        public async Task<VehicleType> GetVehicleTypeById(int id)
        {
            return await _masterVehicleTypeRepository.GetVehicleTypeById(id);
        }

        public async Task UpdateVehicleType(VehicleType vehicleType)
        {
            await _masterVehicleTypeRepository.UpdateVehicleType(vehicleType);
        }

        public async Task<IEnumerable<InternalMaster>> GetAllVehicleCategory()
        {
            return await _masterVehicleTypeRepository.GetAllVehicleCategory();
        }

        public async Task<IEnumerable<MasterParty>> GetAllOwnerOrVendor()
        {
            return await _masterVehicleTypeRepository.GetAllOwnerOrVendor();
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypeList()
        {
            return await _masterVehicleTypeRepository.GetVehicleList();
        }
    }
}
