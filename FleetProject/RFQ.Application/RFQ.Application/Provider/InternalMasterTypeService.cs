using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class InternalMasterTypeService : IInternalMasterTypeService
    {
        private readonly IInternalMasterTypeRepository _internalMasterTypeRepository;

        public InternalMasterTypeService(IInternalMasterTypeRepository internalMasterTypeRepository)
        {
            _internalMasterTypeRepository = internalMasterTypeRepository;
        }

        public async Task<InternalMasterType> AddInternalMasterType(InternalMasterType masterType)
        {
            return await _internalMasterTypeRepository.AddInternalMasterType(masterType);
        }

        public async Task<int> DeleteInternalMasterType(int id)
        {
            var master = await _internalMasterTypeRepository.GetInternalMasterTypeId(id);
            if (master != null)
            {
                await _internalMasterTypeRepository.DeleteInternalMasterType(master);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<InternalMasterType>> GetAllInternalMasterType()
        {
            return await _internalMasterTypeRepository.GetAllInternalMasterType();
        }

        public async Task<InternalMasterType> GetInternalMasterTypeById(int id)
        {
            return await _internalMasterTypeRepository.GetInternalMasterTypeId(id);
        }

        public async Task UpdateInternalMasterType(InternalMasterType masterType)
        {
            await _internalMasterTypeRepository.DeleteInternalMasterType(masterType);
        }
    }
}
