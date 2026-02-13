using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Helper
{
    public class LinkItemContextHelper
    {
        private readonly IMemoryCache _cache;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILinkItemRepository _linkItemRepository;
        private readonly AppSettingContxt _appSettingContxt;
        private const string CachePrefix = "LinkItems_Profile_";

        public LinkItemContextHelper(IMemoryCache cache, ICurrentUserService currentUserService, ILinkItemRepository linkItemRepository, IOptions<AppSettingContxt> appSettingContxt)
        {
            _cache = cache;
            _currentUserService = currentUserService;
            _linkItemRepository = linkItemRepository;
            _appSettingContxt = appSettingContxt.Value;
        }

        public async Task<IEnumerable<LinkItemListResponseDto>> GetCurrentProfileLinksAsync(string? linkName)
        {
            var profileId = _currentUserService.ProfileId;

            if (profileId == null)
                return Enumerable.Empty<LinkItemListResponseDto>();

            var cacheKey = $"{CachePrefix}{profileId}";

            if (_cache.TryGetValue(cacheKey, out IEnumerable<LinkItemListResponseDto> cachedList))
                return linkName == null ? cachedList : cachedList.Where(x => x.LinkName == linkName).ToList();

            var list = await _linkItemRepository.GetLinkItemList(profileId);

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(_appSettingContxt.LinkItemCacheMinutes));

            _cache.Set(cacheKey, list, cacheOptions);

            return linkName == null ? list : list.Where(x => x.LinkName == (string)linkName).ToList();
        }

        public async Task<string?> GetDisplayColumns(string? linkName)
        {
            var links = await GetCurrentProfileLinksAsync(linkName);
            if (links == null)
                return null;

            return links.FirstOrDefault()?.ListingQuery.Trim();
        }
        public void ClearCache(int profileId)
        {
            _cache.Remove($"{CachePrefix}{profileId}");
        }
    }
}
