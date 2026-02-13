using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class RfqRecipientRepository : IRfqRecipientRepository
    {
        private readonly FleetLynkDbContext _fleetLynkDbContext;
        public RfqRecipientRepository(FleetLynkDbContext fleetLynkDbContext)
        {
            _fleetLynkDbContext = fleetLynkDbContext;
        }
        public async Task<List<RfqRecipient>> AddRfqRecipient(List<RfqRecipient> rfqRecipient)
        {
            await _fleetLynkDbContext.rfqRecipient.AddRangeAsync(rfqRecipient);
            await _fleetLynkDbContext.SaveChangesAsync();
            return rfqRecipient;
        }

        public async Task DeleteRfqRecipient(RfqRecipient rfqRecipient)
        {
            _fleetLynkDbContext.rfqRecipient.Remove(rfqRecipient);
            await _fleetLynkDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RfqRecipient>> GetAllRfqRecipient()
        {
            return await _fleetLynkDbContext.rfqRecipient.AsNoTracking().ToListAsync();
        }

        public async Task<RfqRecipient> GetRfqRecipientById(int id)
        {
            return await _fleetLynkDbContext.rfqRecipient.Where(x => x.RfqRecipientId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateRfqRecipient(int rfqId, List<RfqRecipient> rfqRecipient)
        {
            try
            {
                if (rfqRecipient.Count > 0)
                {
                    var exsist = await _fleetLynkDbContext.rfqRecipient.Where(x => x.RfqId == rfqId).ToListAsync();
                    if (exsist.Any())
                    {
                        _fleetLynkDbContext.rfqRecipient.RemoveRange(exsist);
                        await _fleetLynkDbContext.SaveChangesAsync();
                    }
                    rfqRecipient = rfqRecipient.Select(x => { x.RfqId = rfqId; return x; }).ToList();
                    await _fleetLynkDbContext.rfqRecipient.AddRangeAsync(rfqRecipient);
                    await _fleetLynkDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
