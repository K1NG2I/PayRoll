using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using Microsoft.AspNetCore.Identity;
using RFQ.Application.Interface;
using RFQ.Domain.RequestDto;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyUserRepository : ICompanyUserRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly IFleetLynkAdo _fleetLynkAdo;
        private readonly IPasswordHasher _passwordHasher;

        public CompanyUserRepository(FleetLynkDbContext appDbContext, IFleetLynkAdo fleetLynkAdo, IPasswordHasher passwordHasher)
        {
            _appDbContext = appDbContext;
            _fleetLynkAdo = fleetLynkAdo;
            _passwordHasher = passwordHasher;
        }

        public async Task<CompanyUser> AddUser(CompanyUser user)
        {
            try
            {
                await _appDbContext.company_user.AddAsync(user);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public async Task DeleteUser(CompanyUser user)
        {
            _appDbContext.company_user.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PageList<CompanyUserResponseDto>> GetAllUser(PagingParam pagingParam)
        {
            var statusId = (int)EStatus.IsActive;
            var pageNumber = (pagingParam.Start / pagingParam.Length) + 1;
            var pageSize = pagingParam.Length;

            var searchTerm = string.IsNullOrEmpty(pagingParam.SearchValue) ? (object)DBNull.Value : pagingParam.SearchValue;
            var sortColumn = string.IsNullOrEmpty(pagingParam.OrderColumn) ? (object)DBNull.Value : pagingParam.OrderColumn;
            var sortDirection = string.IsNullOrEmpty(pagingParam.OrderDir) ? (object)DBNull.Value : pagingParam.OrderDir;

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@ProfileId", SqlDbType.Int) { Value = pagingParam.ProfileId },
                //new SqlParameter("@CompanyId", SqlDbType.Int) { Value = pagingParam.CompanyId },
                new SqlParameter("@UserId", SqlDbType.Int) { Value = pagingParam.UserId },
                new SqlParameter("@StatusId", SqlDbType.Int) { Value = statusId },
                new SqlParameter("@PageNumber", SqlDbType.Int) { Value = pageNumber },
                new SqlParameter("@PageSize", SqlDbType.Int) { Value = pageSize },
                new SqlParameter("@SearchTerm", SqlDbType.NVarChar, 100) { Value = searchTerm },
                new SqlParameter("@SortColumn", SqlDbType.NVarChar, 50) { Value = sortColumn },
                new SqlParameter("@SortDirection", SqlDbType.NVarChar, 4) { Value = sortDirection }
            };
            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
                StoredProcedureHelper.sp_GetUserList, parameters
                );

            var items = DataTableMapper.MapToList<CompanyUserResponseDto>(dataTable);
            int totalCount = dataTable.Columns.Contains("TotalCount") && dataTable.Rows.Count > 0
                ? Convert.ToInt32(dataTable.Rows[0]["TotalCount"])
                : items.Count;
            return new PageList<CompanyUserResponseDto>(items, totalCount, pageNumber, pageSize);

        }

        public async Task<CompanyUser?> GetUserById(int id)
        {
            var user = await _appDbContext.company_user.AsNoTracking()
                       .FirstOrDefaultAsync(x => x.UserId == id && x.StatusId == (int)EStatus.IsActive);

            user.Password = _passwordHasher.Decrypt(user.Password);
            return user;
        }
        public async Task<CompanyUser?> GetExistingUserById(int id)
        {
            return await _appDbContext.company_user.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task UpdateUser(CompanyUser user)
        {
            var existinguser = await GetExistingUserById(user.UserId);
            if (existinguser != null)
            {
                user.CreatedOn = existinguser.CreatedOn;
                user.ProfileId = existinguser.ProfileId;
                user.StatusId = existinguser.StatusId;
                user.UpdatedOn = DateTime.Now;
                _appDbContext.company_user.Update(user);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<bool> UpdateUserPassWord(UpdateUserPasswordDto user)
        {
            var existinguser = await _appDbContext.company_user
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if(existinguser == null && !string.IsNullOrEmpty(user.LoginId))
            {
                existinguser = await _appDbContext.company_user
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.LoginId == user.LoginId);
            }

            if (existinguser != null)
            {
                string passwordHash = _passwordHasher.Encrypt(user.Password);
                existinguser.Password = passwordHash;
                existinguser.UpdatedOn = DateTime.Now;

                _appDbContext.company_user.Update(existinguser);
                await _appDbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }


        public async Task<CompanyUser?> GetAuthentication(string EmailId, string Password)
        {
            return await _appDbContext.company_user.Where(x => x.EmailId == EmailId && x.Password == Password).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<CompanyUser?> GetByEmailAsync(string emailId)
        {
            return await _appDbContext
                .company_user.Where(x => x.EmailId == emailId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<CompanyUser?> GetByLoginIdAsync(string LoginId)
        {
            return await _appDbContext.company_user.Where(x => x.LoginId == LoginId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<MasterUserActivityLog> AddUserActivitylog(MasterUserActivityLog userActivityLog)
        {
            try
            {
                await _appDbContext.masterUserActivityLogs.AddAsync(userActivityLog);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userActivityLog;
        }
    }
}
