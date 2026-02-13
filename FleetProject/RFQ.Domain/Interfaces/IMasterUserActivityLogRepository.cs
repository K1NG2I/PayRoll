using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IMasterUserActivityLogRepository
    {
        Task<MasterUserActivityLog> GetMasterUserActivityLogById(int id);
        //Task<IEnumerable<MasterUserActivityLog>> GetAllMasterUserActivityLog();
        Task<PageList<MasterUserActivityLogResponseDto>> GetAllMasterUserActivityLogList(PagingParam pagingParam);
        Task<MasterUserActivityLog> AddMasterUserActivityLog(MasterUserActivityLog masterUser);
        Task UpdateMasterUserActivityLog(MasterUserActivityLog masterUser);
        Task DeleteMasterUserActivityLog(MasterUserActivityLog masterUser);
    }
}
