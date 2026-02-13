using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class MasterAttachmentTypeRepository : IMasterAttachmentTypeRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public MasterAttachmentTypeRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MasterAttachmentType> AddMasterAttachmentType(MasterAttachmentType masterAttachmentType)
        {
            await _appDbContext.masterAttachmentTypes.AddAsync(masterAttachmentType);
            await _appDbContext.SaveChangesAsync();
            return masterAttachmentType;
        }

        public async Task DeleteMasterAttachmentType(MasterAttachmentType masterAttachmentType)
        {
            _appDbContext.masterAttachmentTypes.Update(masterAttachmentType);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<MasterAttachmentType>> GetAllMasterAttachmentType()
        {
            return await _appDbContext.masterAttachmentTypes.AsNoTracking().ToListAsync();
        }

        public async Task<MasterAttachmentType> GetMasterAttachmentTypeById(int id)
        {
            return _appDbContext.masterAttachmentTypes.Where(x => x.AttachmentTypeId == id).AsNoTracking().FirstOrDefault();
        }

        public async Task UpdateMasterAttachmentType(MasterAttachmentType masterAttachmentType)
        {
            _appDbContext.masterAttachmentTypes.Update(masterAttachmentType);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
