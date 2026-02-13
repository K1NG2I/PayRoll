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
    public class MasterPartyRepository : IMasterPartyRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly IFleetLynkAdo _fleetLynkAdo;
        private readonly ICommonRepositroy _commonRepositroy;

        public MasterPartyRepository(FleetLynkDbContext appDbContext, IFleetLynkAdo fleetLynkAdo, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _fleetLynkAdo = fleetLynkAdo;
            _commonRepositroy = commonRepositroy;
        }

        public async Task<MasterParty> AddMasterParty(MasterParty party)
        {
            try
             {
                await _appDbContext.masterParty.AddAsync(party);
                await _appDbContext.SaveChangesAsync();
                return party;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteMasterParty(MasterParty party)
        {       
            _appDbContext.masterParty.Update(party);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PageList<MasterPartyResponse>> GetAllCustomer(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<MasterPartyResponse>(StoredProcedureHelper.sp_GetCustomerList, pagingParam);
        }

        public async Task<PageList<MasterPartyResponse>> GetAllVendor(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<MasterPartyResponse>(StoredProcedureHelper.sp_GetVendorList, pagingParam);
        }

        public async Task<MasterParty> GetMasterPartyById(int id)
        {
            return await _appDbContext.masterParty.Where(x => x.PartyId == id && x.StatusId ==(int)EStatus.IsActive).FirstOrDefaultAsync();
        }

        public async Task<MasterParty> GetexistingMasterPartyById(int id)
        {
            return await _appDbContext.masterParty.Where(x => x.PartyId == id).FirstOrDefaultAsync();
        }

        public async Task<MasterParty> UpdateMasterParty(MasterParty party)
        {
            try
            {
                var existingParty = await GetexistingMasterPartyById(party.PartyId);
                if (existingParty != null)
                {
                    party.CreatedOn = existingParty.CreatedOn;
                    party.UpdatedOn = DateTime.Now;
                    party.StatusId = existingParty.StatusId;
                    existingParty.UpdatedOn = DateTime.Now;
                    _appDbContext.masterParty.Entry(existingParty).CurrentValues.SetValues(party);
                    //_appDbContext.masterParty.Update(party);
                    await _appDbContext.SaveChangesAsync();
                    return existingParty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public async Task<IEnumerable<MasterParty>> GetDrpCustomerList(int companyId)
        {
            return await _appDbContext.masterParty
                                      .Where(x => x.StatusId == (int)EStatus.IsActive && x.CompanyId == companyId && x.PartyTypeId == (int)EnumInternalMaster.CUSTOMER)
                                      .ToListAsync();
        }

        public async Task<List<VendorListResponseDto>> GetAllVendorList(int companyId)
        {
            var vendors = await (from party in _appDbContext.masterParty
                                 join internalMaster in _appDbContext.internalMaster
                                     on party.PartyCategoryId equals internalMaster.InternalMasterId
                                 where party.StatusId == (int)EStatus.IsActive && party.PartyTypeId == (int)EnumInternalMaster.VENDOR && party.CompanyId == companyId
                                 select new VendorListResponseDto
                                 {
                                     PartyId = party.PartyId,
                                     PartyName = party.PartyName,
                                     PartyCategoryId = (int)party.PartyCategoryId,
                                     MobNo = party.MobNo,
                                     WhatsAppNo = party.WhatsAppNo,
                                     Email = party.Email,
                                     PANNo = party.PANNo,
                                     GSTNo = party.GSTNo,
                                     VendorCategoryName = internalMaster.InternalMasterName
                                 }).ToListAsync();
            return vendors;
        }

        public async Task<string?> GetAutoCustomerCode(int UserId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", SqlDbType.Int) { Value= UserId},
            };

            var dataTable = await _fleetLynkAdo.ExecuteStoredProcedureAsync(
              StoredProcedureHelper.sp_CodeCustomer_Auto, parameters);

            if (dataTable.Rows[0]["GeneratedCode"] != DBNull.Value)
            {
                string GeneratedCode = dataTable.Rows[0]["GeneratedCode"].ToString();
                return GeneratedCode;
            }
            else
            {
                return null;
            }
        }
    }
}
