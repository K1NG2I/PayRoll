using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IVehicleIndentRepository
    {
        Task<bool> AddVehicleIndent(VehicleIndent vehicleIndent);
        Task<string> GenerateVehicleIndent();
        Task<IEnumerable<VehicleIndent>> GetAllVehicleIndentList(int companyId);
        Task<PageList<VehicleIndentResponseDto>> GetAllVehicleIndent(PagingParam pagingParam);
        Task<VehicleIndent> GetVehicleIndentById(int id);
        Task UpdateVehicleIndent(VehicleIndent vehicleIndent);
        Task<bool> DeleteVehicleIndent(VehicleIndent vehicleIndent);
        Task<bool> IndentReferenceCheckInRfqAsync(int indentId);
    }
}
