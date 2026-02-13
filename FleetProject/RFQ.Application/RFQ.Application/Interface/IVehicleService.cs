using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IVehicleService
    {
        Task<Vehicle> GetVehicleById(int id);
        Task<PageList<VehicleResponseDto>> GetAllVehicles(PagingParam pagingParam);
        Task<bool> AddVehicle(Vehicle vehicle);
        Task UpdateVehicle(Vehicle vehicle);
        Task<int> DeleteVehicle(int id);
        Task<List<VehicleType>> GetAllVehicleType(int companyId);
        Task<IEnumerable<InternalMaster>> GetAllVehicleCategory();
        Task<IEnumerable<MasterParty>> GetAllOwnerOrVendor(int companyId);
        Task<IEnumerable<Vehicle>> GetVehicleNumber();
    }
}
