using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class RfqFinalRateRepository : IRfqFinalRateRepository
    {
        private readonly FleetLynkDbContext _fleetLynkDbContext;
        public RfqFinalRateRepository(FleetLynkDbContext fleetLynkDbContext)
        {
            _fleetLynkDbContext = fleetLynkDbContext;
        }
        public async Task<IEnumerable<RfqFinalRate>> AddRfqFinalRate(List<RfqFinalRate> rfqFinalRates)
        {
            foreach (var item in rfqFinalRates)
            {
                var existing = await _fleetLynkDbContext.rfqFinalRates
                    .FirstOrDefaultAsync(x =>
                        x.RfqId == item.RfqId &&
                        x.VendorId == item.VendorId &&
                        x.RfqFinalId == item.RfqFinalId);

                if (existing != null)
                {
                    existing.AvailVehicleCount = item.AvailVehicleCount;
                    existing.AssignedVehicles = item.AssignedVehicles;
                    existing.IsAssigned = item.IsAssigned;
                    _fleetLynkDbContext.rfqFinalRates.Update(existing);
                }
                else
                {
                    await _fleetLynkDbContext.rfqFinalRates.AddAsync(item);
                }
            }
            await _fleetLynkDbContext.SaveChangesAsync();
            return rfqFinalRates;
        }

        public async Task<bool> DeleteRfqFinalRate(int rfqFinalId)
        {
            var rfqFinalRates = _fleetLynkDbContext.rfqFinalRates.Where(x => x.RfqFinalId == rfqFinalId);
            if (rfqFinalRates.Any())
            {
                _fleetLynkDbContext.rfqFinalRates.RemoveRange(rfqFinalRates);
                await _fleetLynkDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<RfqFinalRate>> GetRfqFinalRateList(int rfqFinalId)
        {
            return await _fleetLynkDbContext.rfqFinalRates.Where(x => x.RfqFinalId == rfqFinalId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<RfqFinalRate>> UpdateRfqFinalRate(List<RfqFinalRate> rfqFinalRates)
        {
            foreach (var item in rfqFinalRates)
            {
                var existing = await _fleetLynkDbContext.rfqFinalRates
                    .FirstOrDefaultAsync(x =>
                        x.RfqId == item.RfqId &&
                        x.VendorId == item.VendorId &&
                        x.RfqFinalId == item.RfqFinalId);

                if (existing != null)
                {
                    existing.AvailVehicleCount = item.AvailVehicleCount;
                    existing.AssignedVehicles = item.AssignedVehicles;
                    existing.IsAssigned = item.IsAssigned;
                    _fleetLynkDbContext.rfqFinalRates.Update(existing);
                }
                else
                {
                    await _fleetLynkDbContext.rfqFinalRates.AddAsync(item);
                }
            }
            await _fleetLynkDbContext.SaveChangesAsync();
            return rfqFinalRates;
        }
    }
}
