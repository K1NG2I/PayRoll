using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public VehicleService(IVehicleRepository vehicleRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _vehicleRepository = vehicleRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<bool> AddVehicle(Vehicle vehicle)
        {
            var existingList = await _vehicleRepository.GetVehicleByVehicleNo(vehicle.VehicleNo);
            if (existingList != null && existingList.CreatedBy == vehicle.CreatedBy)
                return false;
            var result = await _vehicleRepository.AddVehicleAsync(vehicle);
            if (result != null && result.VehicleId > 0)
                return true;
            else
                return false;
        }

        public async Task<int> DeleteVehicle(int id)
        {
            var result = await _vehicleRepository.GetExistingVehicleById(id);
            if (result != null)
            {
                if (result.StatusId == (int)EStatus.IsActive)
                    result.StatusId = (int)EStatus.Deleted;
                else
                    result.StatusId = (int)EStatus.IsActive;

                await _vehicleRepository.DeleteVehicle(result);
                return 1;
            }
            return 0;
        }

        public async Task<PageList<VehicleResponseDto>> GetAllVehicles(PagingParam pagingParam)
        {
            var result = await _vehicleRepository.GetAllVehicles(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.Vehicle);
            return result;
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            return await _vehicleRepository.GetVehicleById(id);
        }

        public async Task UpdateVehicle(Vehicle vehicle)
        {
            await _vehicleRepository.UpdateVehicle(vehicle);
        }

        public async Task<IEnumerable<InternalMaster>> GetAllVehicleCategory()
        {
            return await _vehicleRepository.GetAllVehicleCategory();
        }

        public async Task<List<VehicleType>> GetAllVehicleType(int companyId)
        {
            return await _vehicleRepository.GetAllVehicleType(companyId);
        }

        public async Task<IEnumerable<MasterParty>> GetAllOwnerOrVendor(int companyId)
        {
            return await _vehicleRepository.GetAllOwnerOrVendor(companyId);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicleNumber()
        {
            return await _vehicleRepository.GetVehicleNumber();
        }
    }
}
