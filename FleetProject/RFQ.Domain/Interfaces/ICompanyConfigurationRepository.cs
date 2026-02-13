using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyConfigurationRepository
    {
        Task<CompanyConfigration?> GetCompanyConfigurationId(int id);
        Task<PageList<CompanyConfigrationResponseDto>> GetAllCompanyConfiguration(PagingParam pagingParam);
        Task<CompanyConfigration> AddCompanyConfiguration(CompanyConfigration companyConfiguration);
        Task UpdateCompanyConfiguration(CompanyConfigration companyConfiguration);
        Task DeleteCompanyConfiguration(CompanyConfigration companyConfiguration);
    }
}

