using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IMasterMessageTemplateRepository
    {
        Task<MasterMessageTemplate> GetMasterMessageTemplateById(int id);
        Task<IEnumerable<MasterMessageTemplate>> GetAllMasterMessageTemplate();
        Task<MasterMessageTemplate> AddMasterMessageTemplate(MasterMessageTemplate masterMessage);
        Task UpdateMasterMessageTemplate(MasterMessageTemplate masterMessage);
        Task DeleteMasterMessageTemplate(MasterMessageTemplate masterMessage);
    }
}
