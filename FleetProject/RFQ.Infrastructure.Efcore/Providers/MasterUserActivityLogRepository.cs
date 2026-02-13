using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class MasterUserActivityLogRepository : IMasterUserActivityLogRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly string _connectionString;
        private readonly IFleetLynkAdo _fleetLynkAdo;

        public MasterUserActivityLogRepository(FleetLynkDbContext appDbContext, IConfiguration configuration, IFleetLynkAdo fleetLynkAdo)
        {
            _appDbContext = appDbContext;
            _fleetLynkAdo = fleetLynkAdo;
            _connectionString = configuration.GetConnectionString("RfqDBConnection");
        }

        public async Task<MasterUserActivityLog> AddMasterUserActivityLog(MasterUserActivityLog masterUser)
        {
            await _appDbContext.masterUserActivityLogs.AddAsync(masterUser);
            await _appDbContext.SaveChangesAsync();
            return masterUser;
        }

        public async Task DeleteMasterUserActivityLog(MasterUserActivityLog masterUser)
        {
            _appDbContext.masterUserActivityLogs.Update(masterUser);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PageList<MasterUserActivityLogResponseDto>> GetAllMasterUserActivityLogList(PagingParam pagingParam)
        {
            //var statusId = (int)EStatus.IsActive;
            var pageNumber = (pagingParam.Start / pagingParam.Length) + 1;
            var pageSize = pagingParam.Length;

            var searchTerm = string.IsNullOrEmpty(pagingParam.SearchValue) ? (object)DBNull.Value : pagingParam.SearchValue;
            var sortColumn = string.IsNullOrEmpty(pagingParam.OrderColumn) ? (object)DBNull.Value : pagingParam.OrderColumn;
            var sortDirection = string.IsNullOrEmpty(pagingParam.OrderDir) ? (object)DBNull.Value : pagingParam.OrderDir;

            var parameters = new List<SqlParameter>
            {
                //new SqlParameter("@CompanyId", SqlDbType.Int) { Value = pagingParam.CompanyId },
                //new SqlParameter("@StatusId", SqlDbType.Int) { Value = statusId },
                new SqlParameter("@PageNumber", SqlDbType.Int) { Value = pageNumber },
                new SqlParameter("@PageSize", SqlDbType.Int) { Value = pageSize },
                new SqlParameter("@SearchTerm", SqlDbType.NVarChar, 100) { Value = searchTerm },
                new SqlParameter("@SortColumn", SqlDbType.NVarChar, 50) { Value = sortColumn },
                new SqlParameter("@SortDirection", SqlDbType.NVarChar, 4) { Value = sortDirection }
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
                StoredProcedureHelper.sp_GetUserActivityLogList, parameters
            );

            var items = DataTableMapper.MapToList<MasterUserActivityLogResponseDto>(dataTable);

            int totalCount = dataTable.Columns.Contains("TotalCount") && dataTable.Rows.Count > 0
                ? Convert.ToInt32(dataTable.Rows[0]["TotalCount"])
                : items.Count;

            return new PageList<MasterUserActivityLogResponseDto>(items, totalCount, pageNumber, pageSize);
        }

        //public async Task<IEnumerable<MasterUserActivityLog>> GetAllMasterUserActivityLog()
        //{
        //    return await _appDbContext.masterUserActivityLogs.AsNoTracking().ToListAsync();
        //}

        public async Task<MasterUserActivityLog> GetMasterUserActivityLogById(int id)
        {
            return await _appDbContext.masterUserActivityLogs.Where(x => x.UserActivityLogId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateMasterUserActivityLog(MasterUserActivityLog masterUser)
        {
            _appDbContext.masterUserActivityLogs.Update(masterUser);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
