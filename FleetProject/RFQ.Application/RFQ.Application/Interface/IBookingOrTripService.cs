using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Interface
{
    public interface IBookingOrTripService
    {
        Task<string> GenerateLRNo();
        Task<BookingOrTripRequestDto> AddBookingOrTrip(BookingOrTripRequestDto bookingOrTripRequest);
        Task<PageList<BookingOrTripResponseDto>> GetAllBookingOrTrip(PagingParam pagingParam);
        Task<BookingOrTrip> GetBookingOrTripById(int id);
        Task UpdateBookingOrTrip(BookingOrTrip bookingOrTrip);
        Task<int> DeleteBookingOrTrip(int id);
        Task<IEnumerable<BookingOrTrip>> GetAllLRNo(int companyId);
        Task<IEnumerable<AutoFetchBookingResponseDto>> AutoFetchBooking(int id);
    }
}
