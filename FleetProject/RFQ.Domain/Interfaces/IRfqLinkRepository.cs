using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IRfqLinkRepository
    {
        Task<IEnumerable<RfqLink>> AddRfqLink(List<RfqLink> rfqLinks);
    }
}
