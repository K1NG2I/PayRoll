using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface ILinkGroupRepository
    {
        Task<LinkGroup> GetLinkGroupById(int id);
        Task<IEnumerable<LinkGroup>> GetAllLinkGroup();
        Task<LinkGroup> AddLinkGroup(LinkGroup link);
        Task UpdateLinkGroup(LinkGroup link);
        Task DeleteLinkGroup(LinkGroup link);

    }
}
