using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface ILinkItemService
    {
        Task<IEnumerable<LinkItem>> GetAllLinkItem();
        Task<LinkItem> GetLinkItemById(int id);
        Task AddLinkItem(LinkItem link);
        Task UpdateLinkItem(LinkItem link);
        Task<int> DeleteLinkItem(int id);
        Task<IEnumerable<LinkItemListResponseDto>> GetLinkItemList();
    }
}
