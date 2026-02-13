using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class MasterPartyRouteService : IMasterPartyRouteService
    {
        private readonly IMasterPartyRouteRepository _MasterPartyRouteRepository;

        public MasterPartyRouteService(IMasterPartyRouteRepository MasterPartyRouteRepository)
        {
            _MasterPartyRouteRepository = MasterPartyRouteRepository;
        }

        public  Task AddMasterPartyRoute(List<MasterPartyRoute> partyRoutes)
        {
            return _MasterPartyRouteRepository.AddMasterPartyRoute(partyRoutes);
        }

        public async Task<int> DeleteMasterPartyRoute(int id)
        {
            var result = await _MasterPartyRouteRepository.GetMasterPartyRouteById(id);
            if (result != null)
            {
                await _MasterPartyRouteRepository.DeleteMasterPartyRoute(result);
                return 1;
            }
            return 0;

        }

        public async Task<IEnumerable<MasterPartyRoute>> GetAllMasterPartyRoute()
        {
            return await _MasterPartyRouteRepository.GetAllMasterPartyRoute();
        }

        public async Task<MasterPartyRoute> GetMasterPartyRouteById(int id)
        {
            return await _MasterPartyRouteRepository.GetMasterPartyRouteById(id);
        }

        public async Task<IEnumerable<MasterPartyRouteResponseDto>> GetMasterPartyRouteByPartyId(int id)
        {
            return await _MasterPartyRouteRepository.GetMasterPartyRouteByPartyId(id);
        }

        public async Task UpdateMasterPartyRoute(List<MasterPartyRoute> partyRoute)
        {
            await _MasterPartyRouteRepository.UpdateMasterPartyRoute(partyRoute);
        }
    }
}
