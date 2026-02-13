using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFQ.Domain.Enums;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class BookingInvoiceRepository : IBookingInvoiceRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly string _connectionString;
        private readonly ICommonRepositroy _commonRepositroy;

        public BookingInvoiceRepository(FleetLynkDbContext appDbContext, IConfiguration configuration, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _connectionString = configuration.GetConnectionString("RfqDBConnection");
            _commonRepositroy = commonRepositroy;
        }

        public async Task<BookingInvoice> AddBookingInvoice(BookingInvoice bookingInvoice)
        {
            await _appDbContext.AddAsync(bookingInvoice);
            await _appDbContext.SaveChangesAsync();
            return bookingInvoice;
        }

        //public async Task<BookingInvoice> AddBookingInvoice(BookingInvoice bookingInvoice)
        //{
        //    await _appDbContext.AddAsync(bookingInvoice);
        //    await _appDbContext.SaveChangesAsync();
        //    return bookingInvoice;
        //}

        public async Task DeleteBookingInvoice(BookingInvoice bookingInvoice)
        {
            _appDbContext.bookingInvoices.Remove(bookingInvoice);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<BookingInvoice> GetBookingInvoiceById(int id)
        {
            return await _appDbContext.bookingInvoices.Where(x => x.BookingInvoiceId == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateBookingInvoice(BookingInvoice bookingInvoice)
        {
            var existingBookingOrTrip = await GetBookingInvoiceById(bookingInvoice.BookingInvoiceId);
            if (existingBookingOrTrip != null)
            {
                //bookingInvoice.CreatedOn = existingBookingOrTrip.CreatedOn;
                //bookingInvoice.UpdatedOn = DateTime.Now;
                _appDbContext.bookingInvoices.Update(bookingInvoice);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookingInvoice>> GetBookingInvoiceListByBookingId(int bookingId)
        {
            return await _appDbContext.bookingInvoices
                .Where(x => x.BookingId == bookingId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
