using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class LinkItemService : ILinkItemService
    {
        private readonly ILinkItemRepository _linkitemRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMemoryCache _memoryCache;

        public LinkItemService(ILinkItemRepository linkitemRepository, ICurrentUserService currentUserService, IMemoryCache memoryCache)
        {
            _linkitemRepository = linkitemRepository;
            _currentUserService = currentUserService;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<LinkItem>> GetAllLinkItem()
        {
            return await _linkitemRepository.GetAllLinkItem();
        }

        public async Task<LinkItem> GetLinkItemById(int id)
        {
            return await _linkitemRepository.GetLinkItemById(id);
        }

        public Task AddLinkItem(LinkItem link)
        {
            return _linkitemRepository.AddLinkItem(link);
        }

        public Task UpdateLinkItem(LinkItem link)
        {
            return _linkitemRepository.UpdateLinkItem(link);
        }

        public async Task<int> DeleteLinkItem(int id)
        {
            var result = await _linkitemRepository.GetLinkItemById(id);
            if (result != null)
            {
                result.StatusId = (int)EStatus.Deleted;
                await _linkitemRepository.DeleteLinkItem(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<LinkItemListResponseDto>> GetLinkItemList()
        {
            return await _linkitemRepository.GetLinkItemList(null);
        }
    }
}
