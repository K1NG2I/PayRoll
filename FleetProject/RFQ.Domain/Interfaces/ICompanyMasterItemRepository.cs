using Microsoft.AspNetCore.Mvc;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface ICompanyMasterItemRepository
    {
        Task<CompanyMasterItem?> GetMasterItemById(int id);
        Task<PageList<CompanyMasterItemResponseDto>> GetAllMasterItem([FromBody] PagingParam pagingParam);
        Task<bool> AddMasterItem(CompanyMasterItem masterItem);
        Task<bool> UpdateMasterItem(CompanyMasterItem masterItem);
        Task DeleteMasterItem(CompanyMasterItem masterItem);
        Task<IEnumerable<CompanyMasterItem>> GetDrpProductList(int companyId);
        Task<CompanyMasterItem?> GetExistingMasterItemById(int id);
    }
}
