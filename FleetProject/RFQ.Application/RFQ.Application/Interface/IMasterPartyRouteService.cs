using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IMasterPartyRouteService
    {
        Task<MasterPartyRoute> GetMasterPartyRouteById(int id);
        Task<IEnumerable<MasterPartyRoute>> GetAllMasterPartyRoute();
        Task AddMasterPartyRoute(List<MasterPartyRoute> partyRoutes);
        Task UpdateMasterPartyRoute(List<MasterPartyRoute> partyRoute);
        Task<int> DeleteMasterPartyRoute(int id);
        Task<IEnumerable<MasterPartyRouteResponseDto>> GetMasterPartyRouteByPartyId(int id);
    }
}
