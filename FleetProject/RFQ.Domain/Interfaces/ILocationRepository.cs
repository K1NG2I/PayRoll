using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<MasterLocation?> GetLocationyId(int id);
        Task<PageList<LocationResponseDto>> GetAllLocation(PagingParam pagingParam);
        Task<MasterLocation> AddLocation(MasterLocation location);
        Task UpdateLocation(MasterLocation location);
        Task DeleteLocation(MasterLocation location);
        Task<List<LocationResponseDto>> GetAllLocationList(int companyId);
        Task<List<MasterLocation?>> GetTableLocationList(int companyId);
    }
}
