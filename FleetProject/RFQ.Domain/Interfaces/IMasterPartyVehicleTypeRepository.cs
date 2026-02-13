using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IMasterPartyVehicleTypeRepository
    {
        Task<MasterPartyVehicleType> GetMasterPartyVehicleTypeById(int id);
        Task AddMasterPartyVehicleType(List<MasterPartyVehicleType> masterPartyVehicleTypes);
        Task DeleteMasterVehicleTypeByPartyId(int id);
        Task<IEnumerable<MasterPartyVehicleTypeResponseDto>> GetMasterPartyVehicleTypeByPartyId(int id);
        Task UpdateMasterPartyVehicleType(List<MasterPartyVehicleType> masterPartyVehicleTypes);
        Task DeleteMasterPartyVehicleType(MasterPartyVehicleType masterPartyVehicleType);
    }
}
