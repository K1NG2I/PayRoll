using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface ILocationService

    {
        Task<MasterLocation> GetLocationyId(int id);
        Task<PageList<LocationResponseDto>> GetAllLocation(PagingParam pagingParam);
        Task<bool> AddLocation(MasterLocation location);
        Task UpdateLocation(MasterLocation location);
        Task<int> DeleteLocation(int id);
        Task<List<LocationResponseDto>> GetAllLocationList(int companyId);
    }
}
