using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IRfqRateService
    {
        Task<RfqRate> GetRfqRateId(int id);
        Task<IEnumerable<RfqRate>> GetAllRfqRate();
        Task<RfqRate> AddRfqRate(RfqRate rate);
        Task UpdateRfqRate(RfqRate rate);
        Task<int> DeleteRfqRate(int id);
        Task<IEnumerable<VendorCostingList>> GetAllReceivedVendorCosting(ReceivedVendorCosting request);
    }
}
