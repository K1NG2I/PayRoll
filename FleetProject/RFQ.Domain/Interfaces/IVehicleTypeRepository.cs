using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IVehicleTypeRepository
    {
        Task<VehicleType?> GetVehicleTypeById(int id);
        Task<PageList<VehicleTypeResponseDto>> GetAllVehicleType(PagingParam pagingParam);
        Task<IEnumerable<VehicleType>> GetVehicleList();
        Task<CommanResponseDto> AddVehicleType(VehicleType vehicleType);
        Task UpdateVehicleType(VehicleType vehicleType);
        Task DeleteVehicleType(VehicleType vehicleType);
        Task<IEnumerable<InternalMaster>> GetAllVehicleCategory();
        Task<IEnumerable<MasterParty>> GetAllOwnerOrVendor();
        Task<VehicleType?> GetExistingVehicleTypeById(int id);
    }
}
