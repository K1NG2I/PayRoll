using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;
using System.Net;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class DriverRepository : IDriverRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly IFleetLynkAdo _fleetLynkAdo;
        private readonly string _connectionString;
        private readonly ICommonRepositroy _commonRepositroy;

        public DriverRepository(FleetLynkDbContext appDbContext, IConfiguration configuration, ICommonRepositroy commonRepositroy, IFleetLynkAdo fleetLynkAdo)
        {
            _appDbContext = appDbContext;
            _connectionString = configuration.GetConnectionString("RfqDBConnection");
            _commonRepositroy = commonRepositroy;
            _fleetLynkAdo = fleetLynkAdo;
        }
        public async Task<Driver> AddDriver(Driver driver)
        {
            try
            {
                var driverExists = await _appDbContext.com_mst_driver.FirstOrDefaultAsync(d =>
                                d.CompanyId == driver.CompanyId &&
                                (d.DriverName == driver.DriverName ||
                                d.LicenseNo == driver.LicenseNo));

                if (driverExists != null)
                {
                    if (driverExists.LicenseNo == driver.LicenseNo)
                        throw new Exception("License No already exists.");
                    else
                        throw new Exception("Driver Name already exists.");
                }
                else
                {
                    await _appDbContext.com_mst_driver.AddAsync(driver);
                    await _appDbContext.SaveChangesAsync();
                    return driver;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteDriver(Driver driver)
        {
            _appDbContext.com_mst_driver.Update(driver);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PageList<DriverResponseDto>> GetAllDrivers(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<DriverResponseDto>(StoredProcedureHelper.sp_GetDriverList, pagingParam);
        }

        public async Task<Driver> GetDriverById(int id)
        {
            return await _appDbContext.com_mst_driver.Where(x => x.DriverId == id && x.StatusId == (int)EStatus.IsActive).FirstOrDefaultAsync();

        }

        public async Task<Driver> GetexistingDriverById(int id)
        {
            return await _appDbContext.com_mst_driver.Where(x => x.DriverId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<InternalMaster>> GetDriverType()
        {
            return await _appDbContext.internalMaster.Where(x => x.InternalMasterId == (int)EnumInternalMaster.OWNED || x.InternalMasterId == (int)EnumInternalMaster.MARKET).AsNoTracking().ToListAsync();
        }

        public async Task UpdateDriver(Driver driver)
        {
            try
            {
                bool isExists = await _appDbContext.com_mst_driver.AnyAsync(d =>
                                d.CompanyId == driver.CompanyId && d.DriverId != driver.DriverId &&
                                (d.DriverName == driver.DriverName ||
                                d.LicenseNo == driver.LicenseNo));
                if (isExists)
                {
                    throw new Exception("Driver already exists.");
                }
                else
                {
                    var existingDriver = await _appDbContext.com_mst_driver
                                        .FirstOrDefaultAsync(x => x.DriverId == driver.DriverId);

                    if (existingDriver == null)
                        throw new Exception("Driver not found");

                    // Update only allowed fields
                    existingDriver.DriverName = driver.DriverName;
                    existingDriver.DriverTypeId = driver.DriverTypeId;
                    existingDriver.DriverCode = driver.DriverCode;
                    existingDriver.LicenseNo = driver.LicenseNo;
                    existingDriver.DateOfBirth = driver.DateOfBirth;
                    existingDriver.LicenseIssueDate = driver.LicenseIssueDate;
                    existingDriver.LicenseIssueCityId = driver.LicenseIssueCityId;
                    existingDriver.LicenseExpDate = driver.LicenseExpDate;
                    existingDriver.MobNo = driver.MobNo;
                    existingDriver.WhatsAppNo = driver.WhatsAppNo;
                    existingDriver.AddressLine = driver.AddressLine;
                    existingDriver.CityId = driver.CityId;
                    existingDriver.PinCode = driver.PinCode;
                    existingDriver.DriverImagePath = driver.DriverImagePath;
                    existingDriver.LinkId = driver.LinkId;

                    // Audit fields
                    existingDriver.UpdatedBy = driver.UpdatedBy;
                    existingDriver.UpdatedOn = DateTime.Now;
                    await _appDbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<Driver>> GetAllDriverList()
        {
            return await _appDbContext.com_mst_driver.Where(x => x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<string> GenerateDriverCode(int UserId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", SqlDbType.Int) { Value= UserId},
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
              StoredProcedureHelper.GetNextDriverCode, parameters);

            if (dataTable.Rows[0]["NextDriverCode"] != DBNull.Value)
            {
                string GeneratedCode = dataTable.Rows[0]["NextDriverCode"].ToString();
                return GeneratedCode;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> IsDuplicateDriver(string licenseNo, int createdBy)
        {
            if (string.IsNullOrWhiteSpace(licenseNo))
                return false;

            var exists = await _appDbContext.com_mst_driver
                .AnyAsync(c => c.CreatedBy == createdBy &&
                               c.LicenseNo.ToLower() == licenseNo.ToLower());
            return exists;
        }
    }
}
