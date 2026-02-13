using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IMasterPartyRouteRepository
    {
        Task<MasterPartyRoute> GetMasterPartyRouteById(int id);
        Task<IEnumerable<MasterPartyRoute>> GetAllMasterPartyRoute();
        Task AddMasterPartyRoute(List<MasterPartyRoute> partyRoutes);
        Task UpdateMasterPartyRoute(List<MasterPartyRoute> partyRoute);
        Task DeleteMasterPartyRoute(MasterPartyRoute partyRoute);
        Task DeleteMasterPartyRouteByPartyId(int id);
        Task<IEnumerable<MasterPartyRouteResponseDto>> GetMasterPartyRouteByPartyId(int id);
    }
}

