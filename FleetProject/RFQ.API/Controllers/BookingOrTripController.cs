using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BookingOrTripController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BookingOrTripController> _logger;
        private readonly IBookingOrTripService _bookingOrTripService;
        public BookingOrTripController(IMapper mapper, ILogger<BookingOrTripController> logger, IBookingOrTripService bookingOrTripService)
        {
            _mapper = mapper;
            _logger = logger;
            _bookingOrTripService = bookingOrTripService;
        }

        [HttpPost("AddBookingOrTrip")]
        public async Task<ActionResult> AddBookingOrTrip([FromBody] BookingOrTripRequestDto bookingOrTripRequestDto)
        {
            try
            {
                _logger.LogInformation("Add Vehicle Placement Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = await _bookingOrTripService.AddBookingOrTrip(bookingOrTripRequestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
        [HttpGet("GenerateLRNo")]
        public async Task<ActionResult> GenerateLRNo()
        {
            try
            {
                var nextLRNo = await _bookingOrTripService.GenerateLRNo();
                if (nextLRNo == null)
                {
                    return NotFound("nextLR Number was not found.");
                }
                return Ok(nextLRNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating the LR Number.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("GetAllBookingOrTrip")]
        public async Task<ActionResult> GetAllBookingOrTrip([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Get All Booking Or Trip Details....");
                var indent = await _bookingOrTripService.GetAllBookingOrTrip(pagingParam);
                if (indent == null)
                {
                    NotFound("Booking Or Trip unavailable");
                }
                return Ok(indent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetBookingOrTripById/{id}")]
        public async Task<ActionResult<BookingOrTrip>> GetBookingOrTripById(int id)
        {
            try
            {
                _logger.LogInformation("Get BookingOrTripById Details....");
                var bookingOrTripById = await _bookingOrTripService.GetBookingOrTripById(id);
                if (bookingOrTripById == null || bookingOrTripById.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("BookingOrTripById not Found");
                }
                return Ok(bookingOrTripById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPut("UpdateBookingOrTrip/{id}")]
        public async Task<ActionResult> UpdateBookingOrTrip(int id, BookingOrTripRequestDto bookingOrTripRequestDto)
        {
            try
            {
                _logger.LogInformation("Update VehicleIndent Details....");
                if (bookingOrTripRequestDto == null)
                {
                    return BadRequest();
                }
                var result = _mapper.Map<BookingOrTrip>(bookingOrTripRequestDto);
                result.BookingId = id;
                await _bookingOrTripService.UpdateBookingOrTrip(result);
                return Ok("Update BookingOrTrip Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteBookingOrTrip/{id}")]
        public async Task<ActionResult> DeleteBookingOrTrip(int id)
        {
            try
            {
                _logger.LogInformation("Delete BookingOrTrip Details....");
                await _bookingOrTripService.DeleteBookingOrTrip(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllLRNo")]
        public async Task<IActionResult> GetAllLRNo([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllLRNo Details...");
                var bookingOrTrip = await _bookingOrTripService.GetAllLRNo(companyId);
                if (bookingOrTrip == null)
                {
                    NotFound("GetAllLRNo is not Found");
                }
                return Ok(bookingOrTrip);   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("AutoFetchBooking/{id}")]
        public async Task<ActionResult<AutoFetchBookingResponseDto>> AutoFetchBooking(int id)
        {
            try
            {
                _logger.LogInformation("Get FetchBooking Details....");
                var message = await _bookingOrTripService.AutoFetchBooking(id);
                if (message == null)
                {
                    return NotFound("FetchBooking not Found");
                }
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }

}
