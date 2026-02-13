using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
using RFQ.Domain.Enums;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BookingInvoiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BookingInvoiceController> _logger;
        private readonly IBookingInvoiceService _bookingInvoiceService;
        
        public BookingInvoiceController(IMapper mapper, ILogger<BookingInvoiceController> logger, IBookingInvoiceService bookingInvoiceService)
        {
            _mapper = mapper;
            _logger = logger;   
            _bookingInvoiceService = bookingInvoiceService;
        }

        [HttpPost("AddBookingInvoice")]
        public async Task<ActionResult> AddBookingInvoice([FromBody] BookingInvoiceRequestDto bookingInvoiceRequestDto)
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
                var bookingInvoice = _mapper.Map<BookingInvoice>(bookingInvoiceRequestDto);
                await _bookingInvoiceService.AddBookingInvoice(bookingInvoice);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetBookingInvoiceById/{id}")]
        public async Task<ActionResult<BookingInvoice>> GetBookingInvoiceById(int id)
        {
            try
            {
                _logger.LogInformation("Get BookingInvoiceById Details....");
                var bookingInvoiceById = await _bookingInvoiceService.GetBookingInvoiceById(id);
                if (bookingInvoiceById == null)
                {
                    return NotFound("BookingInvoiceById not Found");
                }
                return Ok(bookingInvoiceById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPut("UpdateBookingInvoice/{id}")]
        public async Task<ActionResult> UpdateBookingInvoice(int id, BookingInvoiceRequestDto bookingInvoiceRequestDto)
        {
            try
            {
                _logger.LogInformation("Update BookingInvoice Details....");
                if (bookingInvoiceRequestDto == null)
                {
                    return BadRequest();
                }
                var result = _mapper.Map<BookingInvoice>(bookingInvoiceRequestDto);
                result.BookingId = id;
                await _bookingInvoiceService.UpdateBookingInvoice(result);
                return Ok("Update BookingInvoice Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteBookingInvoice/{id}")]
        public async Task<ActionResult> DeleteBookingInvoice(int id)
        {
            try
            {
                _logger.LogInformation("Delete BookingInvoice Details....");
                await _bookingInvoiceService.DeleteBookingInvoice(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetBookingInvoiceListByBookingId/{id}")]
        public async Task<ActionResult> GetBookingInvoiceListByBookingId(int id)
        {
            try
            {
                _logger.LogInformation(" GetBookingInvoiceListByBookingId Details....");
                var result = await _bookingInvoiceService.GetBookingInvoiceListByBookingId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }
    }
}
