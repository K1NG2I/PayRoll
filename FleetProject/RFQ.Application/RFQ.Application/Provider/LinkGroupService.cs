using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class LinkGroupService : ILinkService
    {
        private readonly ILinkGroupRepository _linkRepository;

        public LinkGroupService(ILinkGroupRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task<IEnumerable<LinkGroup>> GetAllLinkGroup()
        {
            return await _linkRepository.GetAllLinkGroup();
        }

        public async Task<LinkGroup> GetLinkGroupById(int id)
        {
            return await _linkRepository.GetLinkGroupById(id);
        }

        public async Task<LinkGroup> AddLinkGroup(LinkGroup link)
        {
            return await _linkRepository.AddLinkGroup(link);
        }

        public async Task UpdateLinkGroup(LinkGroup link)
        {
            await _linkRepository.UpdateLinkGroup(link);
        }

        public async Task<int> DeleteLinkGroup(int id)
        {
            var result = await _linkRepository.GetLinkGroupById(id);
            if (result != null)
            {
                await _linkRepository.DeleteLinkGroup(result);
                return 1;
            }
            return 0;
        }
    }
}
