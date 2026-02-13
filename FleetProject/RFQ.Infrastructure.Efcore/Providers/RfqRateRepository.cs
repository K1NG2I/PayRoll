using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using System.Data;
using System.Drawing.Printing;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class RfqRateRepository : IRfqRateRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IFleetLynkAdo _fleetLynkAdo;

        public RfqRateRepository(FleetLynkDbContext context, IMapper mapper, IFleetLynkAdo fleetLynkAdo)
        {
            _appDbContext = context;
            _mapper = mapper;
            _fleetLynkAdo = fleetLynkAdo;
        }

        public async Task<RfqRate> AddRfqRate(RfqRate rate)
        {
            try
            {
                var filterVendorRate = await _appDbContext.rate
               .Where(x => x.RfqId == rate.RfqId && x.VendorId == rate.VendorId)
               .AsNoTracking().FirstOrDefaultAsync();

                if (filterVendorRate != null)
                {
                    //var rfqRateHistoryCheck = await _appDbContext.rfqRateHistories.Where(h => h.RfqId == filterVendorRate.RfqId && h.VendorId == filterVendorRate.VendorId).AsNoTracking().FirstOrDefaultAsync();

                    var rfqRateHistory = _mapper.Map<RfqRateHistory>(filterVendorRate);

                    //if (rfqRateHistoryCheck != null)
                    //{
                    //    rfqRateHistoryCheck.AvailVehicleCount = rfqRateHistory.AvailVehicleCount;
                    //    rfqRateHistoryCheck.TotalHireCost = rfqRateHistory.TotalHireCost;
                    //    rfqRateHistoryCheck.DetentionPerDay = rfqRateHistory.DetentionPerDay;
                    //    rfqRateHistoryCheck.DetentionFreeDays = rfqRateHistory.DetentionFreeDays;
                    //    _appDbContext.rfqRateHistories.Update(rfqRateHistoryCheck);
                    //}

                    //else
                    await _appDbContext.rfqRateHistories.AddAsync(rfqRateHistory);


                    filterVendorRate.AvailVehicleCount = rate.AvailVehicleCount;
                    filterVendorRate.TotalHireCost = rate.TotalHireCost;
                    filterVendorRate.DetentionPerDay = rate.DetentionPerDay;
                    filterVendorRate.DetentionFreeDays = rate.DetentionFreeDays;
                    filterVendorRate.UpdatedOn = DateTime.Now;
                    _appDbContext.rate.Update(filterVendorRate);
                }
                else
                {
                    await _appDbContext.rate.AddAsync(rate);
                }
                await _appDbContext.SaveChangesAsync();
                return rate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteRfqRate(RfqRate rate)
        {
            _appDbContext.rate.Update(rate);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RfqRate>> GetAllRfqRate()
        {
            return await _appDbContext.rate.AsNoTracking().ToListAsync();
        }

        public async Task<RfqRate> GetRfqRateId(int id)
        {
            return _appDbContext.rate.Where(x => x.RfqRateId == id).AsNoTracking().FirstOrDefault();
        }

        public async Task UpdateRfqRate(RfqRate rate)
        {
            _appDbContext.rate.Update(rate);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<VendorCostingList>> GetAllReceivedVendorCosting(ReceivedVendorCosting request)
        {

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IsActive", SqlDbType.Int, 50) { Value = EStatus.IsActive },
                new SqlParameter("@CompanyId", SqlDbType.Int, 50) { Value = request.CompanyId }
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
                StoredProcedureHelper.sp_GetVendorCostingList, parameters
            );
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                var items = DataTableMapper.MapToList<VendorCostingList>(dataTable);
                return items;
            }
            else
            {
                return new List<VendorCostingList>();
            }
        }
    }
}
