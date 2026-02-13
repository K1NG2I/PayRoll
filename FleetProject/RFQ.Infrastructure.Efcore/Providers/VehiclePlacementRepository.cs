using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using System.ComponentModel.Design;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class VehiclePlacementRepository : IVehiclePlacementRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly string _connectionString;
        private readonly ICommonRepositroy _commonRepositroy;
        private readonly IFleetLynkAdo _fleetLynkAdo;
        public VehiclePlacementRepository(FleetLynkDbContext appDbContext, IConfiguration configuration, ICommonRepositroy commonRepositroy, IFleetLynkAdo fleetLynkAdo)
        {
            _appDbContext = appDbContext;
            _connectionString = configuration.GetConnectionString("RfqDBConnection");
            _commonRepositroy = commonRepositroy;
            _fleetLynkAdo = fleetLynkAdo;
        }

        public async Task<VehiclePlacement> AddVehiclePlacement(VehiclePlacement vehiclePlacement)
        {
            await _appDbContext.AddAsync(vehiclePlacement);
            await _appDbContext.SaveChangesAsync();
            return vehiclePlacement;
        }

        public async Task<IEnumerable<AutoFetchIndentResponseDto>> AutoFetchPlacement(int id)
        {
            var query = from v in _appDbContext.vehicleIndents
                        join rfq in _appDbContext.rfq on v.IndentId equals rfq.IndentId
                        where v.IndentId == id
                        select new AutoFetchIndentResponseDto
                        {
                            IndentId = v.IndentId,
                            IndentNo = v.IndentNo,
                            IndentDate = v.IndentDate,
                            LocationId = v.LocationId,
                            VehicleReqOn = v.VehicleReqOn,
                            RfqNo = rfq.RfqNo,
                            RfqDate = rfq.RfqDate,
                            PartyId = rfq.PartyId,
                            FromLocation = rfq.FromLocation,
                            ToLocation = rfq.ToLocation,
                            VehicleTypeId = rfq.VehicleTypeId,
                            RequiredVehicles = v.RequiredVehicles,
                            PendingVehicles = 1

                        };
            return await query.ToListAsync();

        }

        public async Task DeleteVehiclePlacement(VehiclePlacement vehiclePlacement)
        {
            _appDbContext.vehiclePlacements.Update(vehiclePlacement);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<string> GeneratePlacementNo()
        {
            string nextPlacementNo = "";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("GetNextPlacementNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nextPlacementNo = reader["NextPlacementNo"].ToString();
                }
            }
            return nextPlacementNo;
        }

        public async Task<PageList<VehiclePlacementResponseDto>> GetAllVehiclePlacement(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<VehiclePlacementResponseDto>(StoredProcedureHelper.sp_GetVehiclePlacementList, pagingParam);
        }

        public async Task<VehiclePlacement> GetVehiclePlacementtById(int id)
        {
            return await _appDbContext.vehiclePlacements.Where(x => x.PlacementId == id && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateVehiclePlacement(VehiclePlacement vehiclePlacement)
        {
            var existingPlacement = await GetVehiclePlacementtById(vehiclePlacement.PlacementId);
            if (existingPlacement != null)
            {
                vehiclePlacement.CreatedOn = existingPlacement.CreatedOn;
                vehiclePlacement.UpdatedOn = DateTime.Now;
                _appDbContext.vehiclePlacements.Update(vehiclePlacement);
                await _appDbContext.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<VehiclePlacement>> GetAllVehiclePlacementNo(int companyId)
        {
            return await _appDbContext.vehiclePlacements.Where(x => x.CompanyId == companyId && x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }
        public async Task<bool> CheckVehicleAndIndentUnique(int vehicleId, int indentId)
        {
            return await _appDbContext.vehiclePlacements.AsNoTracking()
                         .AnyAsync(x =>
                             x.VehicleId == vehicleId &&
                             x.IndentId == indentId &&
                             x.StatusId == (int)EStatus.IsActive
                         );
        }
        public async Task<IEnumerable<AwardedIndentListResponseDto>> GetAwardedIndentList(int companyId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@CompanyId", SqlDbType.Int) { Value= companyId},
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
              StoredProcedureHelper.sp_GetAwardedIndentList, parameters);

            var items = DataTableMapper.MapToList<AwardedIndentListResponseDto>(dataTable);
            return items;
        }
        public async Task<int> GetVehiclePlacementCountByIndentNo(int indentId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IndentId", SqlDbType.VarChar) { Value= indentId},
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
              StoredProcedureHelper.sp_GetVehiclePlacementCountByIndentNo, parameters);

            // ✅ safety checks
            if (dataTable == null || dataTable.Rows.Count == 0)
                return 0;

            return Convert.ToInt32(dataTable.Rows[0]["PlacementCount"]);
        }

        public async Task<bool> CheckAwardedVendor(CheckAwardedVendorRequestDto requestDto)
        {
            try
            {
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PartyId", SqlDbType.Int) { Value= requestDto.PartyId},
            };

                var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
                  StoredProcedureHelper.sp_GetAwardedIndentList, parameters);

                // ✅ safety checks
                if (dataTable == null || dataTable.Rows.Count == 0)
                    return false;

                var PartyId = Convert.ToInt32(dataTable.Rows[0]["PartyId"]);
                if (PartyId > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
