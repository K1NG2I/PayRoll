using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Domain.Interfaces
{
    public interface IBookingInvoiceRepository
    {
        //Task<BookingInvoice> AddBookingInvoice(BookingInvoice bookingInvoice);
        Task<BookingInvoice> AddBookingInvoice(BookingInvoice bookingInvoice);
        Task<BookingInvoice> GetBookingInvoiceById(int id);
        Task UpdateBookingInvoice(BookingInvoice bookingInvoice);
        Task DeleteBookingInvoice(BookingInvoice bookingInvoice);
        Task<IEnumerable<BookingInvoice>> GetBookingInvoiceListByBookingId(int bookingId);
    }
}
