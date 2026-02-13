using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class MasterPartyVehicleTypeService : IMasterPartyVehicleTypeService
    {
        private readonly IMasterPartyVehicleTypeRepository _masterPartyVehicleTypeRepository;
        public MasterPartyVehicleTypeService(IMasterPartyVehicleTypeRepository masterPartyVehicleTypeRepository)
        {
            _masterPartyVehicleTypeRepository = masterPartyVehicleTypeRepository;
        }

        public async Task<int> DeleteMasterPartyVehicleType(int id)
        {
            var result = await _masterPartyVehicleTypeRepository.GetMasterPartyVehicleTypeById(id);
            if (result != null)
            {
                await _masterPartyVehicleTypeRepository.DeleteMasterPartyVehicleType(result);
                return 1;
            }
            return 0;
        }

        public Task<MasterPartyVehicleType> GetMasterPartyVehicleTypeById(int id)
        {
            return _masterPartyVehicleTypeRepository.GetMasterPartyVehicleTypeById(id);
        }
        public Task<IEnumerable<MasterPartyVehicleTypeResponseDto>> GetMasterPartyVehicleTypeByPartyId(int id)
        {
            return _masterPartyVehicleTypeRepository.GetMasterPartyVehicleTypeByPartyId(id);
        }
    }
}
