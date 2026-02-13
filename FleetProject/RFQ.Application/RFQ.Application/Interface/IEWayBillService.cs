using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Application.Interface
{
    public interface IEWayBillService
    {
        Task<IEnumerable<TripDetailsResponse>> GetTripDetailsByBillExpiryDate(TripDetailsRequestDto requestDto);
    }
}
