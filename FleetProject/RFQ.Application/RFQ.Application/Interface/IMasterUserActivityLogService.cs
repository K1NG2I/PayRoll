using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IMasterUserActivityLogService
    {
        Task<MasterUserActivityLog> GetMasterUserActivityLogById(int id);
        //Task<IEnumerable<MasterUserActivityLog>> GetAllMasterUserActivityLog();
        Task<PageList<MasterUserActivityLogResponseDto>> GetAllMasterUserActivityLogList(PagingParam pagingParam);
        Task<MasterUserActivityLog> AddMasterUserActivityLog(MasterUserActivityLog masterUser);
        Task UpdateMasterUserActivityLog(MasterUserActivityLog masterUser);
        Task<int> DeleteMasterUserActivityLog(int id);
    }
}
