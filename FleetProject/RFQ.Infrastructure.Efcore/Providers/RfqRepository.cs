using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class RfqRepository : IRfqRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly string _connectionString;
        private readonly IFleetLynkAdo _fleetLynkAdo;
        private readonly ICommonRepositroy _commonRepositroy;
        public RfqRepository(FleetLynkDbContext appDbContext, IConfiguration configuration, IFleetLynkAdo fleetLynkAdo, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _connectionString = configuration.GetConnectionString("RfqDBConnection");
            _fleetLynkAdo = fleetLynkAdo;
            _commonRepositroy = commonRepositroy;
        }

        public async Task<Rfq> AddRfq(Rfq rfq)
        {
            await _appDbContext.AddAsync(rfq);
            await _appDbContext.SaveChangesAsync();
            return rfq;
        }

        public async Task<bool> DeleteRfq(Rfq rfq)
        {
            bool isReferenced = await _appDbContext.rfqFinals.AnyAsync(r => Convert.ToInt64(r.RfqId) == rfq.RfqId && r.StatusId == 30);
            if (isReferenced)
                throw new InvalidOperationException("Cannot delete RFQ: referenced in RFQFinalization.");

            rfq.StatusId = (int)EStatus.Deleted;
            _appDbContext.rfq.Update(rfq);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PageList<RfqListResponseDto>> GetAllRfq(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<RfqListResponseDto>(StoredProcedureHelper.sp_GetRfqList, pagingParam);
        }

        public async Task<Rfq?> GetRfqId(int id)
        {
            return _appDbContext.rfq.Where(x => x.RfqId == id && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefault();
        }
        public async Task<Rfq> UpdateRfq(Rfq rfq)
        {
            var existingRfq = await GetRfqId(rfq.RfqId);
            if (existingRfq != null)
            {
                rfq.CreatedOn = existingRfq.CreatedOn;
                rfq.CreatedBy = existingRfq.CreatedBy;
                rfq.UpdatedOn = DateTime.Now;
                rfq.StatusId = existingRfq.StatusId;
                _appDbContext.rfq.Update(rfq);
                await _appDbContext.SaveChangesAsync();
                return rfq;
            }
            return null;
        }

        public async Task<string> GenerateRfqAutoNo()
        {
            string nextRfqNo = "";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("GetNextRfqNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nextRfqNo = reader["NextRfqNo"].ToString();
                }
            }
            return nextRfqNo;
        }

        public async Task<Rfq> GetRfqByRfqNo(string rfqNo)
        {
            return await _appDbContext.rfq.Where(x => x.RfqNo == rfqNo && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RfqVendorListResponseDto>> GetAllVendorListForRfq(RfqVendorDetailsParam rfqVendorDetailsParam)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@OriginFrom", SqlDbType.VarChar) { Value = rfqVendorDetailsParam.OriginFrom},
               new SqlParameter("@ToDestination", SqlDbType.VarChar) { Value = rfqVendorDetailsParam.ToDestination},
               new SqlParameter("@VehicleType", SqlDbType.Int) { Value = rfqVendorDetailsParam.VehicleTypeId},
               new SqlParameter("@RfqId", SqlDbType.Int) { Value = rfqVendorDetailsParam.RfqId}
            };

            var rfqVendorListDataSet = await _fleetLynkAdo.ExecuteStoredProcedureDataSet(
               StoredProcedureHelper.sp_RfqVendorDetails, parameters
            );

            var rfqVendorList = rfqVendorListDataSet.Tables[0].AsEnumerable().Select(row => new RfqVendorListResponseDto
            {
                PartyId = row.Field<int>("PartyId"),
                PartyName = row.Field<string>("PartyName"),
                PartyCategoryId = row.Field<int>("PartyCategoryId"),
                MobNo = row.Field<string>("MobNo"),
                WhatsAppNo = row.Field<string>("WhatsAppNo"),
                PANNo = row.Field<string>("PANNo"),
                Email = row.Field<string>("Email")
            });

            return rfqVendorList;
        }

        public async Task<IEnumerable<RfqPreviousQuotesList>> GetPreviousQuotesList(RfqVendorDetailsParam rfqVendorDetailsParam)
        {
            List<RfqPreviousQuotesList> quotesList = new();
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@OriginFrom", SqlDbType.VarChar) { Value = rfqVendorDetailsParam.OriginFrom},
               new SqlParameter("@ToDestination", SqlDbType.VarChar) { Value = rfqVendorDetailsParam.ToDestination},
               new SqlParameter("@VehicleType", SqlDbType.Int) { Value = rfqVendorDetailsParam.VehicleTypeId}
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
               StoredProcedureHelper.sp_RfqPreviousQuotesList, parameters
           );
            quotesList = DataTableMapper.MapToList<RfqPreviousQuotesList>(dataTable);
            if (quotesList.Count > 0)
            {
                return quotesList;
            }
            return quotesList;
        }

        public async Task<RfqQuoteRateVendorDetails> GetRfqQuoteRateVendorDetails(int rfqId)
        {
            RfqQuoteRateVendorDetails rfqQuoteRateVendorDetails = new();
            var parameters = new List<SqlParameter>
            {

               new SqlParameter("@RfqId ", SqlDbType.Int) { Value = rfqId}
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
               StoredProcedureHelper.sp_GetRfqQuoteRateVendorDetailsByRfqId, parameters
           );
            rfqQuoteRateVendorDetails = DataTableMapper.MapToSingle<RfqQuoteRateVendorDetails>(dataTable);
            return rfqQuoteRateVendorDetails;
        }

        public async Task<IEnumerable<Rfq>> GetRfqDrpList(int companyId)
        {
            return await _appDbContext.rfq.Where(x => x.CompanyId == companyId && x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Rfq>> GetRfqTableData()
        {
            return await _appDbContext.rfq
                .Where(x => x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }
    }
}
