using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyConfigurationRepositroy : ICompanyConfigurationRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly ICommonRepositroy _commonRepositroy;


        public CompanyConfigurationRepositroy(FleetLynkDbContext appDbContext, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _commonRepositroy = commonRepositroy;
        }

        public async Task<CompanyConfigration> AddCompanyConfiguration(CompanyConfigration companyConfiguration)
        {
            try
            {
                await _appDbContext.companyConfigurations.AddAsync(companyConfiguration);
                await _appDbContext.SaveChangesAsync();
                return companyConfiguration;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteCompanyConfiguration(CompanyConfigration companyConfiguration)
        {
            _appDbContext.companyConfigurations.Update(companyConfiguration);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PageList<CompanyConfigrationResponseDto>> GetAllCompanyConfiguration(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<CompanyConfigrationResponseDto>(StoredProcedureHelper.sp_GetCompanyConfigurationList, pagingParam);
        }

        public async Task<CompanyConfigration?> GetCompanyConfigurationId(int id)
        {
            try
            {
                return await _appDbContext.companyConfigurations
               .Where(x => x.CompanyConfigId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateCompanyConfiguration(CompanyConfigration companyConfiguration)
        {
            try
            {
                var existing = await GetCompanyConfigurationId(companyConfiguration.CompanyConfigId);

                if (existing != null)
                {
                    _appDbContext.Entry(existing).State = EntityState.Detached;
                    companyConfiguration.StatusId = existing.StatusId;
                    _appDbContext.companyConfigurations.Update(companyConfiguration);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
