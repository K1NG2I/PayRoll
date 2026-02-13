using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IVehicleTypeService
    {
        Task<VehicleType> GetVehicleTypeById(int id);
        Task<PageList<VehicleTypeResponseDto>> GetAllVehicleType(PagingParam pagingParam);
        Task<IEnumerable<VehicleType>> GetVehicleTypeList();
        Task<CommanResponseDto> AddVehicleType(VehicleType vehicleType);
        Task UpdateVehicleType(VehicleType vehicleType);
        Task<int> DeleteVehicleType(int id);
        Task<IEnumerable<InternalMaster>> GetAllVehicleCategory();
        Task<IEnumerable<MasterParty>> GetAllOwnerOrVendor();
    }
}
