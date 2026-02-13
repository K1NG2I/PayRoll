using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Provider
{
    public class EWayBillService : IEWayBillService
    {
        private readonly IEWayBillRepository _eWayBillRepository;
        public EWayBillService(IEWayBillRepository eWayBillRepository)
        {
            _eWayBillRepository = eWayBillRepository;
        }
        public async Task<IEnumerable<TripDetailsResponse>> GetTripDetailsByBillExpiryDate(TripDetailsRequestDto requestDto)
        {
            return await _eWayBillRepository.GetTripDetailsByBillExpiryDate(requestDto);
        }
    }
}
