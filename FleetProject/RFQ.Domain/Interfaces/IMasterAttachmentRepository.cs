using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IMasterAttachmentRepository
    {
        Task<MasterAttachment> GetMasterAttachmentId(int id);
        Task<IEnumerable<MasterAttachment>> GetAllMasterAttachment();
        Task<List<MasterAttachment>> AddMasterAttachment(List<MasterAttachment> masterAttachment);
        Task<List<MasterAttachment>> UpdateMasterAttachment(List<MasterAttachment> masterAttachment);
        Task<List<MasterAttachment>> DeleteMasterAttachment(MasterAttachment masterAttachment);
        Task DeleteMasterAttachmentTable(MasterAttachment masterAttachment);

    }
}
