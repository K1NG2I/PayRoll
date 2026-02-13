using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class InternalMasterService : IInternalMasterService
    {
        private readonly IInternalMasterRepository _internalMasterRepository;
        public InternalMasterService(IInternalMasterRepository internalMasterRepository)
        {
            _internalMasterRepository = internalMasterRepository;
        }
        public async Task<IEnumerable<InternalMaster>> GetAllInternalMaster()
        {
            return await _internalMasterRepository.GetAllInternalMaster();
        }
    }
}
