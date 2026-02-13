using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class CompanyMasterItemService : ICompanyMasterItemService
    {
        private readonly ICompanyMasterItemRepository _companyMasterItemRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public CompanyMasterItemService(ICompanyMasterItemRepository companyMasterItemRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _companyMasterItemRepository = companyMasterItemRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public async Task<bool> AddMasterItem(CompanyMasterItem masterItem)
        {
            return await _companyMasterItemRepository.AddMasterItem(masterItem);
        }

        public async Task<int> DeleteMasterItem(int id)
        {
            var result = await _companyMasterItemRepository.GetExistingMasterItemById(id);
            if (result != null)
            {
                if (result.StatusId == (int)EStatus.IsActive)
                    result.StatusId = (int)EStatus.Deleted;
                else
                    result.StatusId = (int)EStatus.IsActive;
                await _companyMasterItemRepository.DeleteMasterItem(result);
                return 1;
            }
            return 0;
        }

        public async Task<PageList<CompanyMasterItemResponseDto>> GetAllMasterItem([FromBody] PagingParam pagingParam)
        {
            var result = await _companyMasterItemRepository.GetAllMasterItem(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.ItemOrProduct);
            return result;
        }

        public async Task<CompanyMasterItem> GetMasterItemById(int id)
        {
            return await _companyMasterItemRepository.GetMasterItemById(id);
        }

        public async Task UpdateMasterItem(CompanyMasterItem masterItem)
        {
            await _companyMasterItemRepository.UpdateMasterItem(masterItem);
        }

        public async Task<IEnumerable<CompanyMasterItem>> GetDrpProductList(int companyId)
        {
            return await _companyMasterItemRepository.GetDrpProductList(companyId);
        }
    }
}
