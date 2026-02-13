using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Interfaces
{
    public interface IVehiclePlacementRepository
    {
        Task<string> GeneratePlacementNo();
        Task<VehiclePlacement> AddVehiclePlacement(VehiclePlacement vehiclePlacement);
        Task<IEnumerable<AutoFetchIndentResponseDto>> AutoFetchPlacement(int id);
        Task<PageList<VehiclePlacementResponseDto>> GetAllVehiclePlacement(PagingParam pagingParam);
        Task<VehiclePlacement> GetVehiclePlacementtById(int id);
        Task UpdateVehiclePlacement(VehiclePlacement vehiclePlacement);
        Task DeleteVehiclePlacement(VehiclePlacement vehiclePlacement);
        Task<IEnumerable<VehiclePlacement>> GetAllVehiclePlacementNo(int companyId);
        Task<bool> CheckVehicleAndIndentUnique(int vehicleId, int indentId);
        Task<IEnumerable<AwardedIndentListResponseDto>> GetAwardedIndentList(int companyId);
        Task<int> GetVehiclePlacementCountByIndentNo(int indentId);
        Task<bool> CheckAwardedVendor(CheckAwardedVendorRequestDto requestDto);
    }
}
