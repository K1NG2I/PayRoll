using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Interfaces
{
    public interface IBookingOrTripRepository
    {
        Task<string> GenerateLRNo();
        //Task<BookingOrTrip> AddBookingOrTrip(BookingOrTrip bookingOrTrip);
        Task<BookingOrTrip> AddBookingOrTrip(BookingOrTrip bookingOrTrip);
        Task<PageList<BookingOrTripResponseDto>> GetAllBookingOrTrip(PagingParam pagingParam);
        Task<BookingOrTrip> GetBookingOrTripById(int id);
        Task UpdateBookingOrTrip(BookingOrTrip bookingOrTrip);
        Task DeleteBookingOrTrip(BookingOrTrip bookingOrTrip);
        Task<IEnumerable<BookingOrTrip>> GetAllLRNo(int companyId);
        Task<IEnumerable<AutoFetchBookingResponseDto>> AutoFetchBooking(int id);
    }
}
