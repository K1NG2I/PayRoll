using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class CompanyConfigurationService : ICompanyConfigurationService
    {
        private readonly ICompanyConfigurationRepository _companyConfigurationRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public CompanyConfigurationService(ICompanyConfigurationRepository companyConfigurationRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _companyConfigurationRepository = companyConfigurationRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<CompanyConfigration> AddCompanyConfiguration(CompanyConfigration companyConfiguration)
        {
            return await _companyConfigurationRepository.AddCompanyConfiguration(companyConfiguration);
        }

        public async Task<int> DeleteCompanyConfiguration(int id)
        {
            var result = await _companyConfigurationRepository.GetCompanyConfigurationId(id);
            if (result != null)
            {
                if (result.StatusId == (int)EStatus.IsActive)
                    result.StatusId = (int)EStatus.Deleted;
                else
                    result.StatusId = (int)EStatus.IsActive;
                await _companyConfigurationRepository.DeleteCompanyConfiguration(result);
                return 1;
            }
            return 0;
        }

        public async Task<PageList<CompanyConfigrationResponseDto>> GetAllCompanyConfiguration(PagingParam pagingParam)
        {
            var result = await _companyConfigurationRepository.GetAllCompanyConfiguration(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.CompanyConfiguration);
            return result;
        }

        public async Task<CompanyConfigration> GetCompanyConfigurationId(int id)
        {
            return await _companyConfigurationRepository.GetCompanyConfigurationId(id);
        }

        public async Task UpdateCompanyConfiguration(CompanyConfigration companyConfiguration)
        {
            await _companyConfigurationRepository.UpdateCompanyConfiguration(companyConfiguration);
        }
    }
}
