using RFQ.Application.Interface;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class MasterUserActivityLogService : IMasterUserActivityLogService
    {
        private readonly IMasterUserActivityLogRepository _masterUserActivityLogRepository;

        public MasterUserActivityLogService(IMasterUserActivityLogRepository masterUserActivityLogRepository)
        {
            _masterUserActivityLogRepository = masterUserActivityLogRepository;
        }

        public async Task<MasterUserActivityLog> AddMasterUserActivityLog(MasterUserActivityLog masterUser)
        {
            return await _masterUserActivityLogRepository.AddMasterUserActivityLog(masterUser);
        }

        public async Task<int> DeleteMasterUserActivityLog(int id)
        {
            var result = await _masterUserActivityLogRepository.GetMasterUserActivityLogById(id);
            if (result != null)
            {
               await _masterUserActivityLogRepository.DeleteMasterUserActivityLog(result);
                return 1;
            }
            return 0;
        }
        
        public async Task<PageList<MasterUserActivityLogResponseDto>> GetAllMasterUserActivityLogList(PagingParam pagingParam)
        {
            var result = await _masterUserActivityLogRepository.GetAllMasterUserActivityLogList(pagingParam);
            result.DisplayColumns = "linkName as LinkName,internalMasterName as InternalMasterName,personName as PersonName,logDateTime as LogDateTime,description as Description";
            return result;
        }

        //public async Task<IEnumerable<MasterUserActivityLog>> GetAllMasterUserActivityLog()
        //{
        //    return await _masterUserActivityLogRepository.GetAllMasterUserActivityLog();
        //}

        public async Task<MasterUserActivityLog> GetMasterUserActivityLogById(int id)
        {
            return await _masterUserActivityLogRepository.GetMasterUserActivityLogById(id);
        }

        public async Task UpdateMasterUserActivityLog(MasterUserActivityLog masterUser)
        {
            await _masterUserActivityLogRepository.UpdateMasterUserActivityLog(masterUser);
        }
    }
}
