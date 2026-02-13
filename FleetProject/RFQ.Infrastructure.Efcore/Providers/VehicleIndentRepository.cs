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
    public class VehicleIndentRepository : IVehicleIndentRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly string _connectionString;
        private readonly ICommonRepositroy _commonRepositroy;


        public VehicleIndentRepository(FleetLynkDbContext appDbContext, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _connectionString = appDbContext.Database.GetConnectionString() ?? throw new InvalidOperationException("Connection string not found.");
            _commonRepositroy = commonRepositroy;
        }

        public async Task<bool> AddVehicleIndent(VehicleIndent vehicleIndent)
        {
            await _appDbContext.vehicleIndents.AddAsync(vehicleIndent);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleIndent(VehicleIndent vehicleIndent)
        {
            try
            {
                vehicleIndent.StatusId = (int)EStatus.Deleted;
                _appDbContext.vehicleIndents.Update(vehicleIndent);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> GenerateVehicleIndent()
        {
            string nextVehicleIndentNo = string.Empty;
            await using (var conn = new SqlConnection(_connectionString))
            await using (var cmd = new SqlCommand(StoredProcedureHelper.sp_GetNext_trn_indentNo, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var value = reader["NextIndentNo"];
                        nextVehicleIndentNo = value != null ? value.ToString()! : string.Empty;
                    }
                }
            }
            return nextVehicleIndentNo;
        }

        public async Task<PageList<VehicleIndentResponseDto>> GetAllVehicleIndent(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<VehicleIndentResponseDto>(StoredProcedureHelper.sp_GetVehicleIndentList, pagingParam);
        }

        public async Task<IEnumerable<VehicleIndent>> GetAllVehicleIndentList(int companyId)
        {
            return await _appDbContext.vehicleIndents.Where(x => x.CompanyId == companyId && x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<VehicleIndent> GetVehicleIndentById(int id)
        {
            return await _appDbContext.vehicleIndents.Where(x => x.IndentId == id && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task UpdateVehicleIndent(VehicleIndent vehicleIndent)
        {
            var existingVehicleIndent = await GetVehicleIndentById(vehicleIndent.IndentId);
            if (existingVehicleIndent != null)
            {
                vehicleIndent.CreatedOn = existingVehicleIndent.CreatedOn;
                vehicleIndent.UpdatedOn = DateTime.Now;
                vehicleIndent.StatusId = existingVehicleIndent.StatusId;
                _appDbContext.vehicleIndents.Update(vehicleIndent);
                await _appDbContext.SaveChangesAsync();
            }
        }
        public async Task<bool> IndentReferenceCheckInRfqAsync(int indentId)
        {
            return await _appDbContext.rfq.AnyAsync(r => r.IndentId == indentId && r.StatusId == 30);
        }
    }
}
