using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class LinkItemRepository : ILinkItemRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public LinkItemRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<LinkItem>> GetAllLinkItem()
        {
            return await _appDbContext.link_Item.Where(x => x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();

        }

        public async Task<LinkItem> GetLinkItemById(int id)
        {

            return await _appDbContext.link_Item.Where(x => x.LinkId == id && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task AddLinkItem(LinkItem link)
        {
            await _appDbContext.link_Item.AddAsync(link);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateLinkItem(LinkItem link)
        {
            _appDbContext.link_Item.Update(link);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task DeleteLinkItem(LinkItem link)
        {
            _appDbContext.link_Item.Update(link);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<LinkItemListResponseDto>> GetLinkItemList(int? profileID)
        {

            IEnumerable<LinkItemListResponseDto> data = await (from item in _appDbContext.link_Item
                                                               join cr in _appDbContext.companyProfileRights
                                                                   on item.LinkId equals cr.LinkId
                                                               where item.StatusId == (int)EStatus.IsActive
                                                               && cr.ProfileId == (profileID ?? cr.ProfileId)
                                                               select new LinkItemListResponseDto
                                                               {
                                                                   LinkId = item.LinkId,
                                                                   LinkName = item.LinkName,
                                                                   ListingQuery = item.ListingQuery,
                                                                   LinkGroupId = item.LinkGroupId,
                                                                   LinkIcon = item.LinkIcon,
                                                                   SequenceNo = item.SequenceNo,
                                                                   LinkUrl = item.LinkUrl,
                                                                   AddUrl = item.AddUrl,
                                                                   EditUrl = item.EditUrl,
                                                                   CancelUrl = item.CancelUrl,
                                                                   StatusId = item.StatusId,
                                                                   ProfileId = cr.ProfileId,
                                                                   IsAdd = cr.IsAdd,
                                                                   IsEdit = cr.IsEdit,
                                                                   IsView = cr.IsView,
                                                                   IsCancel = cr.IsCancel,
                                                               })
                                                .AsNoTracking()
                                                .ToListAsync();

            return data;



        }
    }
}
