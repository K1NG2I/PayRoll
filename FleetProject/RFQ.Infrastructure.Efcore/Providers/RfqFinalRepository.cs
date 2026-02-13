using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class RfqFinalRepository : IRfqFinalRepository
    {
        private readonly FleetLynkDbContext _fleetLynkDbContext;
        private readonly IFleetLynkAdo _fleetLynkAdo;
        private readonly ICommonRepositroy _commonRepositroy;
        public RfqFinalRepository(FleetLynkDbContext fleetLynkDbContext, IFleetLynkAdo fleetLynkAdo, ICommonRepositroy commonRepositroy)
        {
            _fleetLynkDbContext = fleetLynkDbContext;
            _fleetLynkAdo = fleetLynkAdo;
            _commonRepositroy = commonRepositroy;
        }
        public async Task<RfqFinal?> GetRfqFinalById(int rfqFinalId)
        {
            return await _fleetLynkDbContext.rfqFinals
                         .Where(x => x.RfqFinalIdId == rfqFinalId)
                         .AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<RfqFinal> AddRfqFinal(RfqFinal rfqFinal)
        {
            await _fleetLynkDbContext.rfqFinals.AddAsync(rfqFinal);
            await _fleetLynkDbContext.SaveChangesAsync();
            return rfqFinal;
        }

        public async Task<IEnumerable<VendorFinalizationDto>> AwardedVendor(int id)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@RfqId", SqlDbType.Int, 50) { Value = id },
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
                StoredProcedureHelper.sp_GetAwardedVendorList, parameters
            );
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                var items = DataTableMapper.MapToList<VendorFinalizationDto>(dataTable);
                return items;
            }
            else
            {
                return new List<VendorFinalizationDto>();
            }
        }

        public async Task<PageList<RfqFinalizationResponseDto>> GetAllRfqFinalization(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<RfqFinalizationResponseDto>(StoredProcedureHelper.sp_GetRfqFinalizationList, pagingParam);
        }

        public async Task<RfqFinal> UpdateRfqFinal(RfqFinal rfqFinal)
        {
            var existingRfqFinal = await GetRfqFinalById(rfqFinal.RfqFinalIdId);
            if (existingRfqFinal != null)
            {
                rfqFinal.CreatedOn = existingRfqFinal.CreatedOn;
                rfqFinal.UpdatedOn = DateTime.Now;
                rfqFinal.StatusId = existingRfqFinal.StatusId;
                _fleetLynkDbContext.rfqFinals.Update(rfqFinal);
                await _fleetLynkDbContext.SaveChangesAsync();
                return rfqFinal;
            }
            return null;
        }

        public async Task<bool> DeleteRfqFinal(int rfqFinalId)
        {
            var result = await GetRfqFinalById(rfqFinalId);
            if (result != null)
            {
                result.StatusId = (int)EStatus.Deleted;
                _fleetLynkDbContext.rfqFinals.Update(result);
                await _fleetLynkDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
