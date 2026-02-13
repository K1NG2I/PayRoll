using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{

    public class LinkGroupRepository : ILinkGroupRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public LinkGroupRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Add
        public async Task<LinkGroup> AddLinkGroup(LinkGroup link)
        {
            await _appDbContext.link_Group.AddAsync(link);
            await _appDbContext.SaveChangesAsync();
            return link;
        }

        //Delete
        public async Task DeleteLinkGroup(LinkGroup link)
        {
            _appDbContext.link_Group.Update(link);
            await _appDbContext.SaveChangesAsync();
        }

        //GetAll
        public async Task<IEnumerable<LinkGroup>> GetAllLinkGroup()
        {
            return await _appDbContext.link_Group.AsNoTracking().ToListAsync();
        }

        //GetById
        public async Task<LinkGroup> GetLinkGroupById(int id)
        {
            return await _appDbContext.link_Group.Where(x => x.LinkGroupId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        //Update
        public async Task UpdateLinkGroup(LinkGroup link)
        {
            _appDbContext.link_Group.Update(link);
            await _appDbContext.SaveChangesAsync();
        }
    }
}