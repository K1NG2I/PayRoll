using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IMasterPartyService
    {
        Task<MasterParty> GetMasterPartyById(int id);
        Task<PageList<MasterPartyResponse>> GetAllCustomer(PagingParam pagingParam);
        Task<PageList<MasterPartyResponse>> GetAllVendor(PagingParam pagingParam);
        Task<MasterParty> AddMasterParty(MasterParty party, List<MasterPartyVehicleType> masterPartyVehicleType, List<MasterPartyRoute> masterPartyRoute);
        Task<MasterParty> UpdateMasterParty(MasterParty party, List<MasterPartyVehicleType> masterPartyVehicleType, List<MasterPartyRoute> masterPartyRoute);
        Task<int> DeleteMasterParty(int id);
        Task<IEnumerable<MasterParty>> GetDrpCustomerList(int companyId);
        Task<List<VendorListResponseDto>> GetAllVendorList(int companyId);
        Task<string> GetAutoCustomerCode(int UserId);
    }
}
