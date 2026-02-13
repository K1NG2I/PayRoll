using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IRfqLinkService
    {
        Task<IEnumerable<RfqLink>> AddRfqLink(List<RfqLink> rfqLinks);
    }
}
