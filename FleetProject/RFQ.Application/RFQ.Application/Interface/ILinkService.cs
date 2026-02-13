using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface ILinkService
    {
        Task<LinkGroup> GetLinkGroupById(int id);
        Task<IEnumerable<LinkGroup>> GetAllLinkGroup();
        Task<LinkGroup> AddLinkGroup(LinkGroup link);
        Task UpdateLinkGroup(LinkGroup link);
        Task<int> DeleteLinkGroup(int id);
    }
}
