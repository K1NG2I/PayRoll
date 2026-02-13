using Microsoft.AspNetCore.Mvc;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface ICompanyMasterItemService
    {
        Task<CompanyMasterItem> GetMasterItemById(int id);
        Task<PageList<CompanyMasterItemResponseDto>> GetAllMasterItem([FromBody] PagingParam pagingParam);
        Task<bool> AddMasterItem(CompanyMasterItem masterItem);
        Task UpdateMasterItem(CompanyMasterItem masterItem);
        Task<int> DeleteMasterItem(int id);
        Task<IEnumerable<CompanyMasterItem>> GetDrpProductList(int companyId);
    }
}
