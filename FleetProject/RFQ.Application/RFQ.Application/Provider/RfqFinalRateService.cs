using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;

namespace RFQ.Application.Provider
{
    public class RfqFinalRateService : IRfqFinalRateService
    {
        private readonly IRfqFinalRateRepository _rfqFinalRateRepository;
        public RfqFinalRateService(IRfqFinalRateRepository rfqFinalRateRepository)
        {
            _rfqFinalRateRepository = rfqFinalRateRepository;
        }
        public async Task<List<RfqFinalRate>> GetRfqFinalRateList(int rfqFinalId)
        {
            return await _rfqFinalRateRepository.GetRfqFinalRateList(rfqFinalId);
        }
    }
}
