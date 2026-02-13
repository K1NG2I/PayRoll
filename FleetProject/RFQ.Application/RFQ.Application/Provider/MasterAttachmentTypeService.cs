using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class MasterAttachmentTypeService : IMasterAttachmentTypeService
    {
        private readonly IMasterAttachmentTypeRepository _masterAttachmentTypeRepository;

        public MasterAttachmentTypeService(IMasterAttachmentTypeRepository masterAttachmentTypeRepository)
        {
            _masterAttachmentTypeRepository = masterAttachmentTypeRepository;
        }

        public async Task<MasterAttachmentType> AddMasterAttachmentType(MasterAttachmentType masterAttachmentType)
        {
            return await _masterAttachmentTypeRepository.AddMasterAttachmentType(masterAttachmentType);
        }

        public async Task<int> DeleteMasterAttachmentType(int id)
        {
            var result = await _masterAttachmentTypeRepository.GetMasterAttachmentTypeById(id);
            if (result != null)
            {
                await _masterAttachmentTypeRepository.DeleteMasterAttachmentType(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<MasterAttachmentType>> GetAllMasterAttachmentType()
        {
            return await _masterAttachmentTypeRepository.GetAllMasterAttachmentType();
        }

        public async Task<MasterAttachmentType> GetMasterAttachmentTypeById(int id)
        {
            return await _masterAttachmentTypeRepository.GetMasterAttachmentTypeById(id);
        }

        public async Task UpdateMasterAttachmentType(MasterAttachmentType masterAttachmentType)
        {
            await _masterAttachmentTypeRepository.UpdateMasterAttachmentType(masterAttachmentType);
        }
    }
}
