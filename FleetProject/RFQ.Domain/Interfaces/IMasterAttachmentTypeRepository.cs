using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IMasterAttachmentTypeRepository
    {
        Task<MasterAttachmentType> GetMasterAttachmentTypeById(int id);
        Task<IEnumerable<MasterAttachmentType>> GetAllMasterAttachmentType();
        Task<MasterAttachmentType> AddMasterAttachmentType(MasterAttachmentType masterAttachmentType);
        Task UpdateMasterAttachmentType(MasterAttachmentType masterAttachmentType);
        Task DeleteMasterAttachmentType(MasterAttachmentType masterAttachmentType);
    }
}
