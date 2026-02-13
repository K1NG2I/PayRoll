using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Provider
{
    public class VehiclePlacementService : IVehiclePlacementService
    {
        private IVehiclePlacementRepository _vehiclePlacementRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;
        public VehiclePlacementService(IVehiclePlacementRepository vehiclePlacementRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _vehiclePlacementRepository = vehiclePlacementRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<VehiclePlacement> AddVehiclePlacement(VehiclePlacement vehiclePlacement)
        {
            return await _vehiclePlacementRepository.AddVehiclePlacement(vehiclePlacement);
        }

        public Task<IEnumerable<AutoFetchIndentResponseDto>> AutoFetchPlacement(int id)
        {
            return _vehiclePlacementRepository.AutoFetchPlacement(id);
        }

        public async Task<int> DeleteVehiclePlacement(int id)
        {
            var vehiclePlacement = await _vehiclePlacementRepository.GetVehiclePlacementtById(id);
            if (vehiclePlacement != null)
            {
                vehiclePlacement.StatusId = (int)EStatus.Deleted;
                await _vehiclePlacementRepository.DeleteVehiclePlacement(vehiclePlacement);
                return 1;
            }
            return 0;
        }

        public async Task<string> GeneratePlacementNo()
        {
            return await _vehiclePlacementRepository.GeneratePlacementNo();
        }

        public async Task<PageList<VehiclePlacementResponseDto>> GetAllVehiclePlacement(PagingParam pagingParam)
        {
            var result = await _vehiclePlacementRepository.GetAllVehiclePlacement(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.VehiclePlacement);
            return result;
        }
        public async Task<VehiclePlacement> GetVehiclePlacementtById(int id)
        {
            return await _vehiclePlacementRepository.GetVehiclePlacementtById(id);
        }

        public async Task UpdateVehiclePlacement(VehiclePlacement vehiclePlacement)
        {
            await _vehiclePlacementRepository.UpdateVehiclePlacement(vehiclePlacement);
        }
        public async Task<IEnumerable<VehiclePlacement>> GetAllVehiclePlacementNo(int companyId)
        {
            return await _vehiclePlacementRepository.GetAllVehiclePlacementNo(companyId);
        }
        public async Task<bool> CheckVehicleAndIndentUnique(int vehicleId, int indentId)
        {
            return await _vehiclePlacementRepository.CheckVehicleAndIndentUnique(vehicleId, indentId);
        }

        public async Task<IEnumerable<AwardedIndentListResponseDto>> GetAwardedIndentList(int companyId)
        {
            return await _vehiclePlacementRepository.GetAwardedIndentList(companyId);
        }
        public async Task<int> GetVehiclePlacementCountByIndentNo(int indentId)
        {
            return await _vehiclePlacementRepository.GetVehiclePlacementCountByIndentNo(indentId);
        }
        public async Task<bool> CheckAwardedVendor(CheckAwardedVendorRequestDto requestDto)
        {
            return await _vehiclePlacementRepository.CheckAwardedVendor(requestDto);
        }
    }
}
