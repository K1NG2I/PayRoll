using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class MasterAttachmentRepository : IMasterAttachmentRepository
    {
        private readonly FleetLynkDbContext _appDbContext;

        public MasterAttachmentRepository(FleetLynkDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<MasterAttachment>> AddMasterAttachment(List<MasterAttachment> masterAttachment)
        {
            await _appDbContext.masterAttachments.AddRangeAsync(masterAttachment);
            await _appDbContext.SaveChangesAsync();
            return masterAttachment;
        }

        public async Task<List<MasterAttachment>> UpdateMasterAttachment(List<MasterAttachment> masterAttachment)
        {
            _appDbContext.masterAttachments.UpdateRange(masterAttachment);
            await _appDbContext.SaveChangesAsync();
            return masterAttachment;
        }

        public async Task<List<MasterAttachment>> DeleteMasterAttachment(MasterAttachment masterAttachment)
        {
            var attachmentmasterList = _appDbContext.masterAttachments.Where(x => x.TransactionId == masterAttachment.TransactionId).ToList();
            foreach (var item in attachmentmasterList)
            {
                _appDbContext.masterAttachments.Remove(item);
            }
            await _appDbContext.SaveChangesAsync();
            return attachmentmasterList;
        }

        public async Task DeleteMasterAttachmentTable(MasterAttachment masterAttachment)
        {
            var attachmentmaster = await GetMasterAttachmentId(masterAttachment.AttachmentId);
            _appDbContext.masterAttachments.Remove(attachmentmaster);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MasterAttachment>> GetAllMasterAttachment()
        {
            return await _appDbContext.masterAttachments.AsNoTracking().ToListAsync();
        }

        public async Task<MasterAttachment> GetMasterAttachmentId(int id)
        {
            return _appDbContext.masterAttachments.Where(x => x.AttachmentId == id).AsNoTracking().FirstOrDefault();
        }


    }

}
