using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface ICompanyConfigurationService
    {
        Task<CompanyConfigration> GetCompanyConfigurationId(int id);
        Task<PageList<CompanyConfigrationResponseDto>> GetAllCompanyConfiguration(PagingParam pagingParam);
        Task<CompanyConfigration> AddCompanyConfiguration(CompanyConfigration companyConfiguration);
        Task UpdateCompanyConfiguration(CompanyConfigration companyConfiguration);
        Task<int> DeleteCompanyConfiguration(int id);
    }
}
