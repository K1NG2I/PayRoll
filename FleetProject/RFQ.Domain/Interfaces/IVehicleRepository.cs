using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleById(int id);
        Task<PageList<VehicleResponseDto>> GetAllVehicles(PagingParam pagingParam);
        Task<Vehicle> AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicle(Vehicle vehicle);
        Task DeleteVehicle(Vehicle vehicle);
        Task<List<VehicleType>> GetAllVehicleType(int companyId);
        Task<IEnumerable<InternalMaster>> GetAllVehicleCategory();
        Task<IEnumerable<MasterParty>> GetAllOwnerOrVendor(int companyId);
        Task<IEnumerable<Vehicle>> GetVehicleNumber();
        Task<Vehicle?> GetVehicleByVehicleNo(string vehicleNo);
        Task<Vehicle?> GetExistingVehicleById(int id);
    }
}
