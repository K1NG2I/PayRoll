using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class RfqFinalRateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<RfqFinalRateController> _logger;
        private readonly IRfqFinalRateService _rfqFinalRateService;
        public RfqFinalRateController(IMapper mapper, ILogger<RfqFinalRateController> logger, IRfqFinalRateService rfqFinalRateService)
        {
            _logger = logger;
            _mapper = mapper;
            _rfqFinalRateService = rfqFinalRateService;
        }

        [HttpGet("GetRfqFinalRateList")]
        public async Task<IActionResult> GetRfqFinalRateList([FromQuery] int rfqFinalId)
        {
            try
            {
                _logger.LogInformation("Get GetRfqFinalRateList Details....");
                var result = await _rfqFinalRateService.GetRfqFinalRateList(rfqFinalId);
                if (result == null)
                {
                    return NotFound("GetRfqFinalRateList not Found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
