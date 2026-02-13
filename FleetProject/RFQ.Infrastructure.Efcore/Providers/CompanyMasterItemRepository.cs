using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class CompanyMasterItemRepository : ICompanyMasterItemRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly ICommonRepositroy _commonRepositroy;

        public CompanyMasterItemRepository(FleetLynkDbContext appDbContext, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _commonRepositroy = commonRepositroy;
        }

        public async Task<bool> AddMasterItem(CompanyMasterItem masterItem)
        {
            try
            {
                _appDbContext.MasterItem.Add(masterItem);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<CommanResponseDto> AddMasterItem(CompanyMasterItem masterItem)
        //{
        //    masterItem.CreatedOn = DateTime.Now;
        //    masterItem.UpdatedOn = DateTime.Now;
        //    await _appDbContext.MasterItem.AddAsync(masterItem);
        //    await _appDbContext.SaveChangesAsync();
        //    return masterItem;
        //}
        public async Task DeleteMasterItem(CompanyMasterItem masterItem)
        {
            _appDbContext.MasterItem.Update(masterItem);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PageList<CompanyMasterItemResponseDto>> GetAllMasterItem(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<CompanyMasterItemResponseDto>(StoredProcedureHelper.sp_GetComMstItemList, pagingParam);
        }

        public async Task<CompanyMasterItem?> GetMasterItemById(int id)
        {
            return await _appDbContext.MasterItem.Where(x => x.ItemId == id && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<CompanyMasterItem?> GetExistingMasterItemById(int id)
        {
            return await _appDbContext.MasterItem.Where(x => x.ItemId == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateMasterItem(CompanyMasterItem masterItem)
        {
            try
            {
                var result = await GetExistingMasterItemById(masterItem.ItemId);
                masterItem.CreatedOn = result.CreatedOn;
                masterItem.UpdatedOn = DateTime.Now;
                masterItem.StatusId = result.StatusId;
                _appDbContext.MasterItem.Update(masterItem);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CompanyMasterItem>> GetDrpProductList(int companyId)
        {
            return await _appDbContext.MasterItem.Where(x => x.StatusId == (int)EStatus.IsActive && x.CompanyId == companyId).ToListAsync();
        }
    }
}
