using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class MasterMessageTemplateService : IMasterMessageTemplateService
    {
        private readonly IMasterMessageTemplateRepository _masterMessageTemplateRepository;
        public MasterMessageTemplateService(IMasterMessageTemplateRepository masterMessageTemplateRepository)
        {
            _masterMessageTemplateRepository = masterMessageTemplateRepository;
        }

        public async Task<MasterMessageTemplate> AddMasterMessageTemplate(MasterMessageTemplate masterMessage)
        {
            return await _masterMessageTemplateRepository.AddMasterMessageTemplate(masterMessage);
        }

        public async Task<int> DeleteMasterMessageTemplate(int id)
        {
            var result = await _masterMessageTemplateRepository.GetMasterMessageTemplateById(id);
            if (result != null)
            {
                await _masterMessageTemplateRepository.UpdateMasterMessageTemplate(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<MasterMessageTemplate>> GetAllMasterMessageTemplate()
        {
            return await _masterMessageTemplateRepository.GetAllMasterMessageTemplate();
        }

        public async Task<MasterMessageTemplate> GetMasterMessageTemplateById(int id)
        {
            return await _masterMessageTemplateRepository.GetMasterMessageTemplateById(id);
        }

        public async Task UpdateMasterMessageTemplate(MasterMessageTemplate masterMessage)
        {
            await _masterMessageTemplateRepository.UpdateMasterMessageTemplate(masterMessage);
        }
    }
}
