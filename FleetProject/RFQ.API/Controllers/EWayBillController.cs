using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EWayBillController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EWayBillController> _logger;
        private readonly IEWayBillService _eWayBillService;

        public EWayBillController(IMapper mapper, ILogger<EWayBillController> logger, IEWayBillService eWayBillService)
        {
            _mapper = mapper;
            _logger = logger;
            _eWayBillService = eWayBillService;
        }

        [HttpPost("GetTripDetailsByBillExpiryDate")]
        public async Task<IActionResult> GetTripDetailsByBillExpiryDate([FromBody] TripDetailsRequestDto requestDto)
        {
            try
            {
                var response = await _eWayBillService.GetTripDetailsByBillExpiryDate(requestDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetTripDetailsByBillExpiryDate");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
