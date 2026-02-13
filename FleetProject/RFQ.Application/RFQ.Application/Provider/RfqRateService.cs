using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class RfqRateService : IRfqRateService
    {
        private readonly IRfqRateRepository _rfqRateRepository;

        public RfqRateService(IRfqRateRepository rfqRateRepository)
        {
            _rfqRateRepository = rfqRateRepository;
        }

        public async Task<RfqRate> AddRfqRate(RfqRate rate)
        {
            return await _rfqRateRepository.AddRfqRate(rate);
        }

        public async Task<int> DeleteRfqRate(int id)
        {
            var rate = await _rfqRateRepository.GetRfqRateId(id);
            if (rate != null)
            {
                await _rfqRateRepository.DeleteRfqRate(rate);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<RfqRate>> GetAllRfqRate()
        {
            return await _rfqRateRepository.GetAllRfqRate();
        }

        public async Task<RfqRate> GetRfqRateId(int id)
        {
            return await _rfqRateRepository.GetRfqRateId(id);
        }

        public Task UpdateRfqRate(RfqRate rate)
        {
            return _rfqRateRepository.UpdateRfqRate(rate);
        }
        public async Task<IEnumerable<VendorCostingList>> GetAllReceivedVendorCosting(ReceivedVendorCosting request)
        {
            return await _rfqRateRepository.GetAllReceivedVendorCosting(request);
        }

    }
}
