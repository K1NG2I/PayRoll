using RFQ.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Interface
{
    public interface IBookingInvoiceService
    {
        //Task<BookingInvoice> AddBookingInvoice(BookingInvoice bookingInvoice);
        Task<BookingInvoice> AddBookingInvoice(BookingInvoice bookingInvoice);
        Task<BookingInvoice> GetBookingInvoiceById(int id);
        Task UpdateBookingInvoice(BookingInvoice bookingInvoice);
        Task<int> DeleteBookingInvoice(int id);

        Task<IEnumerable<BookingInvoice>> GetBookingInvoiceListByBookingId(int bookingId);
    }
}
