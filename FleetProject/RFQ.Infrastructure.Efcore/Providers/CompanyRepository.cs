using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using RFQ.Infrastructure.Efcore.Configration;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly ICommonRepositroy _commonRepositroy;
        private readonly ILogger<CompanyRepository> _logger;

        public CompanyRepository(FleetLynkDbContext appDbContext, ICommonRepositroy commonRepositroy, ILogger<CompanyRepository> logger)
        {
            _appDbContext = appDbContext;
            _commonRepositroy = commonRepositroy;
            _logger = logger;
        }

        public async Task<Company?> GetCompanyById(int companyId)
        {
            try
            {
                var query = _appDbContext.company
                    .Where(x => x.CompanyId == companyId && x.StatusId == (int)EStatus.IsActive)
                    .AsNoTracking();

                // Log generated SQL to help debugging
                try
                {
                    var sql = query.ToQueryString();
                    _logger.LogDebug("GetCompanyById SQL: {Sql}", sql);
                    _logger.LogInformation("DB connection: {Conn}", _appDbContext.Database.GetDbConnection().ConnectionString);
                    _logger.LogInformation("GetCompanyById SQL: {Sql}", query.ToQueryString());
                }
                catch (Exception ex)
                {
                    _logger.LogDebug(ex, "Unable to get SQL for query");
                }

                var company = await query.FirstOrDefaultAsync();

                if (company == null)
                {
                    _logger.LogInformation("No active company found with CompanyId={CompanyId}", companyId);
                }

                return company;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching company by id {CompanyId}", companyId);
                throw;
            }
        }

        public async Task<Company?> GetExistingCompany(string? companyName, int? createdBy)
        {
            return await _appDbContext.company.Where(x => x.CompanyName.ToLower() == companyName.ToLower() && x.CreatedBy == createdBy).AsNoTracking().FirstOrDefaultAsync();

        }
        public async Task<PageList<CorporateCompanyResponseDto>> GetAllCompany(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<CorporateCompanyResponseDto>(StoredProcedureHelper.sp_GetCompanyList, pagingParam);
        }

        public async Task<PageList<FranchiseResponseDto>> GetAllFranchise(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<FranchiseResponseDto>(StoredProcedureHelper.sp_GetFranchiseList, pagingParam);
        }
        public async Task<Company> AddCompany(Company company)
        {
            try
            {
                await _appDbContext.company.AddAsync(company);
                await _appDbContext.SaveChangesAsync();
                return company;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateCompany(int? id, Company company)
        {
            try
            {
                var exsitcompany = await _appDbContext.company.Where(x => x.CompanyId == id).AsNoTracking().FirstOrDefaultAsync();
                if (exsitcompany != null)
                {
                    company.CompanyId = exsitcompany.CompanyId;
                    company.StatusId = exsitcompany.StatusId;
                    company.UpdatedBy = company.UpdatedBy;
                    _appDbContext.company.Update(company);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCompany(int id)
        {
            try
            {
                var exsit = await _appDbContext.company.Where(x => x.CompanyId == id).AsNoTracking().FirstOrDefaultAsync();
                if (exsit.StatusId == (int)EStatus.IsActive)
                    exsit.StatusId = (int)EStatus.Deleted;
                else
                    exsit.StatusId = (int)EStatus.IsActive;
                _appDbContext.company.Update(exsit);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Company>> GetAllCompanyAndFranchise()
        {
            return await _appDbContext.company.Where(x => x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }
    }
}
