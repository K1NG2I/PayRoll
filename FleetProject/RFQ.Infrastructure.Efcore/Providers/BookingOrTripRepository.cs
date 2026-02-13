using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;
using System.Data;

namespace RFQ.Infrastructure.Efcore.Providers
{
    public class BookingOrTripRepository : IBookingOrTripRepository
    {
        private readonly FleetLynkDbContext _appDbContext;
        private readonly string _connectionString;
        private readonly ICommonRepositroy _commonRepositroy;

        public BookingOrTripRepository(FleetLynkDbContext appDbContext, IConfiguration configuration, ICommonRepositroy commonRepositroy)
        {
            _appDbContext = appDbContext;
            _connectionString = configuration.GetConnectionString("RfqDBConnection");
            _commonRepositroy = commonRepositroy;
        }

        //public async Task<BookingOrTrip> AddBookingOrTrip(BookingOrTrip bookingOrTrip)
        //{
        //    await _appDbContext.AddAsync(bookingOrTrip);
        //    await _appDbContext.SaveChangesAsync();
        //    return bookingOrTrip;
        //}

        public async Task<BookingOrTrip> AddBookingOrTrip(BookingOrTrip bookingOrTrip)
        {
            await _appDbContext.AddAsync(bookingOrTrip);
            await _appDbContext.SaveChangesAsync();
            return bookingOrTrip;
        }

        //public async Task<IEnumerable<AutoFetchBookingResponseDto>> AutoFetchBooking(int id)
        //{
        //    var query = from v in _appDbContext.vehicleIndents
        //                join vehiclePlacements in _appDbContext.vehiclePlacements on v.IndentId equals vehiclePlacements.IndentId
        //                where v.IndentId == id
        //                select new AutoFetchBookingResponseDto
        //                {
        //                    IndentId = v.IndentId,
        //                    IndentNo = v.IndentNo,
        //                    PlacementId = vehiclePlacements.PlacementId,
        //                    PlacementNo = vehiclePlacements.PlacementNo,
        //                    VehicleId = vehiclePlacements.VehicleId,
        //                    DriverId = vehiclePlacements.DriverId,
        //                    MobileNo = vehiclePlacements.MobileNo,
        //                    VehicleTypeId = v.VehicleTypeId,
        //                    FromLocation  = v.FromLocation,
        //                    ToLocation = v.ToLocation

        //                };
        //   return await query.ToListAsync();
        //}

        public async Task<IEnumerable<AutoFetchBookingResponseDto>> AutoFetchBooking(int placementId)
        {
            var query =
                from p in _appDbContext.vehiclePlacements
                join v in _appDbContext.vehicleIndents
                    on p.IndentId equals v.IndentId
                where p.PlacementId == placementId
                select new AutoFetchBookingResponseDto
                {
                    IndentId = p.IndentId,
                    IndentNo = v.IndentNo,
                    PlacementId = p.PlacementId,
                    PlacementNo = p.PlacementNo,
                    VehicleId = p.VehicleId,
                    DriverId = p.DriverId,
                    MobileNo = p.MobileNo,
                    VehicleTypeId = v.VehicleTypeId,
                    FromLocation = v.FromLocation,
                    ToLocation = v.ToLocation,
                    PartyId = v.PartyId
                };

            return await query.ToListAsync();
        }

        public async Task DeleteBookingOrTrip(BookingOrTrip bookingOrTrip)
        {
            _appDbContext.bookingOrTrips.Update(bookingOrTrip);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<string> GenerateLRNo()
        {
            string nextLRNo = "";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("GetNextLRNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nextLRNo = reader["NextLRNo"].ToString();
                }
            }
            return nextLRNo;
        }

        public async Task<PageList<BookingOrTripResponseDto>> GetAllBookingOrTrip(PagingParam pagingParam)
        {
            return await _commonRepositroy.GetAllRecordsFromStoredProcedure<BookingOrTripResponseDto>(StoredProcedureHelper.sp_GetBookingList, pagingParam);
        }

        public async Task<IEnumerable<BookingOrTrip>> GetAllLRNo(int companyId)
        {
            return await _appDbContext.bookingOrTrips.Where(x => x.CompanyId == companyId && x.StatusId == (int)EStatus.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<BookingOrTrip> GetBookingOrTripById(int id)
        {
            return await _appDbContext.bookingOrTrips.Where(x => x.BookingId == id && x.StatusId == (int)EStatus.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateBookingOrTrip(BookingOrTrip bookingOrTrip)
        {
            var existingBookingOrTrip = await GetBookingOrTripById(bookingOrTrip.BookingId);
            if (existingBookingOrTrip != null) 
            {
                bookingOrTrip.StatusId = existingBookingOrTrip.StatusId;
                bookingOrTrip.CreatedOn = existingBookingOrTrip.CreatedOn;
                bookingOrTrip.UpdatedOn = DateTime.Now;
                _appDbContext.bookingOrTrips.Update(bookingOrTrip);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
