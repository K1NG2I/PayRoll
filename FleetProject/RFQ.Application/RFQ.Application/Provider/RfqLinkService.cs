using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class RfqLinkService : IRfqLinkService
    {
        private readonly IRfqLinkRepository _rfqLinkRepository;
        public RfqLinkService(IRfqLinkRepository rfqLinkRepository)
        {
            _rfqLinkRepository = rfqLinkRepository;
        }

        public async Task<IEnumerable<RfqLink>> AddRfqLink(List<RfqLink> rfqLinks)
        {
            return await _rfqLinkRepository.AddRfqLink(rfqLinks);
        }
    }
}