using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IRfqFinalRateService
    {
        Task<List<RfqFinalRate>> GetRfqFinalRateList(int rfqFinalId);
    }
}
