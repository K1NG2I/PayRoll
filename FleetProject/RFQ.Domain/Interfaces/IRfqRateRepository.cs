using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Domain.Interfaces
{
    public interface IRfqRateRepository
    {
        Task<RfqRate> GetRfqRateId(int id);
        Task<IEnumerable<RfqRate>> GetAllRfqRate();
        Task<RfqRate> AddRfqRate(RfqRate rate);
        Task UpdateRfqRate(RfqRate rate);
        Task DeleteRfqRate(RfqRate rate);
        Task<IEnumerable<VendorCostingList>> GetAllReceivedVendorCosting(ReceivedVendorCosting request);
    }
}
