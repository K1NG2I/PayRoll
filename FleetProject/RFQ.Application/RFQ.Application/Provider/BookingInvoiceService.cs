using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Provider
{
    public class BookingInvoiceService : IBookingInvoiceService
    {
        private readonly IBookingInvoiceRepository _bookingInvoiceRepository;
        private readonly LinkItemContextHelper _linkItemContextHelper;

        public BookingInvoiceService(IBookingInvoiceRepository bookingInvoiceRepository, LinkItemContextHelper linkItemContextHelper)
        {
            _bookingInvoiceRepository = bookingInvoiceRepository;
            _linkItemContextHelper = linkItemContextHelper;
        }

        public Task<BookingInvoice> AddBookingInvoice(BookingInvoice bookingInvoice)
        {
            return _bookingInvoiceRepository.AddBookingInvoice(bookingInvoice);
        }

        //public async Task<BookingInvoice> AddBookingInvoice(BookingInvoice bookingInvoice)
        //{
        //    return await _bookingInvoiceRepository.AddBookingInvoice(bookingInvoice);
        //}

        public async Task<BookingInvoice> GetBookingInvoiceById(int id)
        {
            return await _bookingInvoiceRepository.GetBookingInvoiceById(id);
        }

        public async Task UpdateBookingInvoice(BookingInvoice bookingInvoice)
        {
            await _bookingInvoiceRepository.UpdateBookingInvoice(bookingInvoice);
        }
        public async Task<int> DeleteBookingInvoice(int id)
        {
            var bookingInvoice = await _bookingInvoiceRepository.GetBookingInvoiceById(id);
            if (bookingInvoice != null)
            {
                await _bookingInvoiceRepository.DeleteBookingInvoice(bookingInvoice);
                return 1;
            }
            return 0;
        }
        public async Task<IEnumerable<BookingInvoice>> GetBookingInvoiceListByBookingId(int bookingId)
        {
            return await _bookingInvoiceRepository.GetBookingInvoiceListByBookingId(bookingId);
        }
    }
}
