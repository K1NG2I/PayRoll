using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IMasterMessageTemplateService
    {
        Task<MasterMessageTemplate> GetMasterMessageTemplateById(int id);
        Task<IEnumerable<MasterMessageTemplate>> GetAllMasterMessageTemplate();
        Task<MasterMessageTemplate> AddMasterMessageTemplate(MasterMessageTemplate masterMessage);
        Task UpdateMasterMessageTemplate(MasterMessageTemplate masterMessage);
        Task<int> DeleteMasterMessageTemplate(int id);
    }
}
