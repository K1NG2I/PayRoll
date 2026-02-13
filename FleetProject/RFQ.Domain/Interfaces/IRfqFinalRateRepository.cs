using RFQ.Domain.Models;

namespace RFQ.Domain.Interfaces
{
    public interface IRfqFinalRateRepository
    {
        Task<IEnumerable<RfqFinalRate>> AddRfqFinalRate(List<RfqFinalRate> rfqFinalRates);
        Task<IEnumerable<RfqFinalRate>> UpdateRfqFinalRate(List<RfqFinalRate> rfqFinalRates);
        Task<bool> DeleteRfqFinalRate(int rfqFinalId);
        Task<List<RfqFinalRate>> GetRfqFinalRateList(int rfqFinalId);
    }
}
