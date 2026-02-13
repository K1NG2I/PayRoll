using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class MasterMessageTemplateRepository : IMasterMessageTemplateRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public MasterMessageTemplateRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MasterMessageTemplate> AddMasterMessageTemplate(MasterMessageTemplate masterMessage)
        {
            await _appDbContext.masterMessageTemplate.AddRangeAsync(masterMessage);
            await _appDbContext.SaveChangesAsync();
            return masterMessage;
        }

        public async Task DeleteMasterMessageTemplate(MasterMessageTemplate masterMessage)
        {
            _appDbContext.masterMessageTemplate.Update(masterMessage);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MasterMessageTemplate>> GetAllMasterMessageTemplate()
        {
            return await _appDbContext.masterMessageTemplate.AsNoTracking().ToListAsync();
        }

        public async Task<MasterMessageTemplate> GetMasterMessageTemplateById(int id)
        {
            return await _appDbContext.masterMessageTemplate.Where(x => x.TemplateId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateMasterMessageTemplate(MasterMessageTemplate masterMessage)
        {
            _appDbContext.masterMessageTemplate.Update(masterMessage);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
