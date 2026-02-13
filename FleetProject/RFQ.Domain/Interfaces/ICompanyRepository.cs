using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyRepository
    {

        //Company 
        Task<Company?> GetCompanyById(int companyId);
        Task<List<Company>> GetAllCompanyAndFranchise();
        Task<PageList<CorporateCompanyResponseDto>> GetAllCompany(PagingParam pagingParam);
        Task<PageList<FranchiseResponseDto>> GetAllFranchise(PagingParam pagingParam);
        Task<Company> AddCompany(Company company);
        Task UpdateCompany(int? id, Company company);
        Task<bool> DeleteCompany(int id);
        Task<Company?> GetExistingCompany(string? companyName, int? createdBy);
    }
}
