using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class MasterAttachmentService : IMasterAttachmentService
    {
        private readonly IMasterAttachmentRepository _masterAttachmentRepository;

        public MasterAttachmentService(IMasterAttachmentRepository masterAttachmentRepository)
        {
            _masterAttachmentRepository = masterAttachmentRepository;
        }

        public async Task<List<MasterAttachment>> AddMasterAttachment(List<MasterAttachment> masterAttachment)
        {
            return await _masterAttachmentRepository.AddMasterAttachment(masterAttachment);
        }

        public async Task<List<MasterAttachment>> UpdateMasterAttachment(List<MasterAttachment> masterAttachment)
        {
            return await _masterAttachmentRepository.UpdateMasterAttachment(masterAttachment);
        }

        public async Task<List<MasterAttachment>> DeleteMasterAttachment(int id)
        {
            var result = await _masterAttachmentRepository.GetMasterAttachmentId(id);
            if (result != null)
            {
                var attachmentList = await _masterAttachmentRepository.DeleteMasterAttachment(result);
                return attachmentList;
            }
            return null;
        }

        public async Task<int> DeleteMasterAttachmentTable(int id)
        {
            var result = await _masterAttachmentRepository.GetMasterAttachmentId(id);
            if (result != null)
            {
                await _masterAttachmentRepository.DeleteMasterAttachmentTable(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<MasterAttachment>> GetAllMasterAttachment()
        {
            return await _masterAttachmentRepository.GetAllMasterAttachment();
        }

        public async Task<MasterAttachment> GetMasterAttachmentId(int id)
        {
            return await _masterAttachmentRepository.GetMasterAttachmentId(id);
        }

        
    }
}
