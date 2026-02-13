using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IMasterAttachmentService
    {
        Task<MasterAttachment> GetMasterAttachmentId(int id);
        Task<IEnumerable<MasterAttachment>> GetAllMasterAttachment();
        Task<List<MasterAttachment>> AddMasterAttachment(List<MasterAttachment> masterAttachment);
        Task<List<MasterAttachment>> UpdateMasterAttachment(List<MasterAttachment> masterAttachment);
        Task<List<MasterAttachment>> DeleteMasterAttachment(int id);
        Task<int> DeleteMasterAttachmentTable(int id);
    }
}
