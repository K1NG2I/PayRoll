using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IMasterAttachmentTypeService
    {
        Task<MasterAttachmentType> GetMasterAttachmentTypeById(int id);
        Task<IEnumerable<MasterAttachmentType>> GetAllMasterAttachmentType();
        Task<MasterAttachmentType> AddMasterAttachmentType(MasterAttachmentType masterAttachmentType);
        Task UpdateMasterAttachmentType(MasterAttachmentType masterAttachmentType);
        Task<int> DeleteMasterAttachmentType(int id);
    }
}
