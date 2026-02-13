using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IVehicleIndentService
    {
        Task<bool> AddVehicleIndent(VehicleIndent vehicleIndent);
        Task<string> GenerateVehicleIndent();
        Task<IEnumerable<VehicleIndent>> GetAllVehicleIndentList(int companyId);
        Task<PageList<VehicleIndentResponseDto>> GetAllVehicleIndent(PagingParam pagingParam);
        Task<VehicleIndent> GetVehicleIndentById(int id);
        Task UpdateVehicleIndent(VehicleIndent vehicleIndent);
        Task<bool> DeleteVehicleIndent(int id);
        Task<bool> IndentReferenceCheckInRfqAsync(int indentId);
    }
}
