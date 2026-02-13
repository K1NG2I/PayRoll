using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface ICompanyService
    {
        //Company 
        Task<Company?> GetCompanyById(int id);
        Task<List<Company>> GetAllCompanyAndFranchise();
        Task<PageList<FranchiseResponseDto>> GetAllFranchise(PagingParam pagingParam);
        Task<PageList<CorporateCompanyResponseDto>> GetAllCompany(PagingParam pagingParam);
        Task<Company?> AddCompany(Company company);
        Task UpdateCompany(int? id, Company company);
        Task<int> DeleteCompany(int id);
    }
}
