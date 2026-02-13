using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IMasterPartyVehicleTypeService
    {
        Task<IEnumerable<MasterPartyVehicleTypeResponseDto>> GetMasterPartyVehicleTypeByPartyId(int id);
        Task<int> DeleteMasterPartyVehicleType(int id);
        Task<MasterPartyVehicleType> GetMasterPartyVehicleTypeById(int id);
    }
}
