using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IMasterPartyRepository
    {
        Task<MasterParty> GetMasterPartyById(int id);
        Task<PageList<MasterPartyResponse>> GetAllCustomer(PagingParam pagingParam);
        Task<PageList<MasterPartyResponse>> GetAllVendor(PagingParam pagingParam);
        Task<MasterParty> AddMasterParty(MasterParty party);
        Task<MasterParty> UpdateMasterParty(MasterParty party);
        Task DeleteMasterParty(MasterParty party);
        Task<IEnumerable<MasterParty>> GetDrpCustomerList(int companyId);
        Task<List<VendorListResponseDto>> GetAllVendorList(int companyId);
        Task<MasterParty> GetexistingMasterPartyById(int id);
        Task<string> GetAutoCustomerCode(int UserId);
    }
}
