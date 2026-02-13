using AutoMapper;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Provider
{
    public class BookingOrTripService : IBookingOrTripService
    {
        private readonly IBookingOrTripRepository _bookingOrTripRepository;
        private readonly IBookingInvoiceRepository _bookingInvoiceRepository;
        private readonly IMapper _mapper;
        private readonly LinkItemContextHelper _linkItemContextHelper;
        public BookingOrTripService(IBookingOrTripRepository bookingOrTripRepository, IBookingInvoiceRepository bookingInvoiceRepository, LinkItemContextHelper linkItemContextHelper, IMapper mapper)
        {
            _bookingOrTripRepository = bookingOrTripRepository;
            _linkItemContextHelper = linkItemContextHelper;
            _bookingInvoiceRepository = bookingInvoiceRepository;
            _mapper = mapper;
        }

        public async Task<BookingOrTripRequestDto> AddBookingOrTrip(BookingOrTripRequestDto bookingOrTripRequest)
        {
            try
            {
                var bookingDetail = _mapper.Map<BookingOrTrip>(bookingOrTripRequest);

                BookingOrTrip bookingResponse = await _bookingOrTripRepository.AddBookingOrTrip(bookingDetail);
                if (bookingResponse != null)
                {
                    if (bookingOrTripRequest.BookingInvoiceDetailList.Count > 0)
                    {
                        foreach (var item in bookingOrTripRequest.BookingInvoiceDetailList)
                        {
                            var bookingInvoice = _mapper.Map<BookingInvoice>(item);
                            bookingInvoice.BookingId = bookingResponse.BookingId;
                            BookingInvoice bookingInvoiceResponse = await _bookingInvoiceRepository.AddBookingInvoice(bookingInvoice);
                        }
                    }
                }
                return bookingOrTripRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<BookingOrTrip> AddBookingOrTrip(BookingOrTrip bookingOrTrip)
        //{
        //    return await _bookingOrTripRepository.AddBookingOrTrip(bookingOrTrip);
        //}

        public async Task<int> DeleteBookingOrTrip(int id)
        {
            var bookingOrTrip = await _bookingOrTripRepository.GetBookingOrTripById(id);
            if (bookingOrTrip != null)
            {
                bookingOrTrip.StatusId = (int)EStatus.Deleted;
                await _bookingOrTripRepository.DeleteBookingOrTrip(bookingOrTrip);
                return 1;
            }
            return 0;
        }

        public async Task<string> GenerateLRNo()
        {
            return await _bookingOrTripRepository.GenerateLRNo();
        }

        public async Task<PageList<BookingOrTripResponseDto>> GetAllBookingOrTrip(PagingParam pagingParam)
        {
            var result = await _bookingOrTripRepository.GetAllBookingOrTrip(pagingParam);
            result.DisplayColumns = await _linkItemContextHelper.GetDisplayColumns(ELinkItems.BookingOrTrip);
            return result;
        }

        public async Task<IEnumerable<BookingOrTrip>> GetAllLRNo(int companyId)
        {
            return await _bookingOrTripRepository.GetAllLRNo(companyId);
        }

        public async Task<BookingOrTrip> GetBookingOrTripById(int id)
        {
            return await _bookingOrTripRepository.GetBookingOrTripById(id);
        }

        public async Task UpdateBookingOrTrip(BookingOrTrip bookingOrTrip)
        {
            await _bookingOrTripRepository.UpdateBookingOrTrip(bookingOrTrip);
        }

        public Task<IEnumerable<AutoFetchBookingResponseDto>> AutoFetchBooking(int id)
        {
            return _bookingOrTripRepository.AutoFetchBooking(id);
        }
    }
}
