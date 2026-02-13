using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public CompanyService(ICompanyRepository companyRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _companyRepository = companyRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<Company?> GetCompanyById(int companyId)
        {
            return await _companyRepository.GetCompanyById(companyId);
        }

        public async Task<PageList<CorporateCompanyResponseDto>> GetAllCompany(PagingParam pagingParam)
        {
            var result = await _companyRepository.GetAllCompany(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.CorporateCompany.ToString());
            return result;
        }

        public async Task<PageList<FranchiseResponseDto>> GetAllFranchise(PagingParam pagingParam)
        {
            var result = await _companyRepository.GetAllFranchise(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.Franchise.ToString());
            return result;
        }

        public async Task<Company?> AddCompany(Company company)
        {
            return await _companyRepository.AddCompany(company);
        }


        public async Task UpdateCompany(int? id,Company company)
        {
            await _companyRepository.UpdateCompany(id,company);
        }

        public async Task<int> DeleteCompany(int id)
        {
            var check = await _companyRepository.DeleteCompany(id);
            if (check)
                return 1;
            else
                return 0;
        }

        public async Task<List<Company>> GetAllCompanyAndFranchise()
        {
            return await _companyRepository.GetAllCompanyAndFranchise();
        }
    }
}
