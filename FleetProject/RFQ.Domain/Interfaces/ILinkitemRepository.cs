using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface ILinkItemRepository
    {
        Task<IEnumerable<LinkItem>> GetAllLinkItem();
        Task<LinkItem> GetLinkItemById(int id);
        Task AddLinkItem(LinkItem link);
        Task UpdateLinkItem(LinkItem link);
        Task DeleteLinkItem(LinkItem link);
        Task<IEnumerable<LinkItemListResponseDto>> GetLinkItemList(int? profileID);
    }
}
