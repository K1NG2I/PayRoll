using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Domain.RequestDto;
using RFQ.Application.Interface;
using RFQ.Domain.Models;
using RFQ.Application.Provider;
using RFQ.Domain.Helper;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class RfqRateController : ControllerBase
    {
        private readonly IRfqRateService _rfqRateService;
        private readonly IMapper _mapper;
        private readonly ILogger<RfqRateController> _logger;

        public RfqRateController(IRfqRateService rfqRateService, IMapper mapper, ILogger<RfqRateController> logger)
        {
            _rfqRateService = rfqRateService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetRfqRateById/{id}")]
        public async Task<IActionResult> GetRfqRateById(int id)
        {
            try
            {
                _logger.LogInformation("Get GetRfqRateById Details....");
                var rate = await _rfqRateService.GetRfqRateId(id);
                if (rate == null)
                {
                    return NotFound("Rfq Detail not Found");
                }
                return Ok(rate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetRfqRateAll")]
        public async Task<IActionResult> GetRfqRateAll()
        {
            try
            {
                _logger.LogInformation("Get RFQ Rate Details....");
                var rate = await _rfqRateService.GetAllRfqRate();
                if (rate == null)
                {
                    NotFound("Rfq rate list unavailable");
                }
                return Ok(rate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("AddRfqRate")]
        public async Task<IActionResult> AddRfqRate([FromBody]RfqRateDto rate)
        {
            try
            {
                _logger.LogInformation("Add Rfq rate Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var rfqRate = _mapper.Map<RfqRate>(rate);
                rfqRate.UpdatedOn = DateTime.Now;
                var result =  await _rfqRateService.AddRfqRate(rfqRate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateRfqRate/{id}")]
        public async Task<IActionResult> UpdateRfqRate(int id, RfqRateDto rate)
        {
            try
            {
                _logger.LogInformation("Update Rfq rate detail....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<RfqRate>(rate);
                result.RfqRateId = id;
                await _rfqRateService.UpdateRfqRate(result);
                return Ok("Update RFQ Rate Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteRfqRate/{id}")]
        public async Task<IActionResult> DeleteRfqRate(int id)
        {
            try
            {
                _logger.LogInformation("Delete Rfq Rate....");
                await _rfqRateService.DeleteRfqRate(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("GetAllReceivedVendorCosting")]
        public async Task<ActionResult> GetAllReceivedVendorCosting(ReceivedVendorCosting request)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllReceivedVendorCosting Details...");
                var drivers = await _rfqRateService.GetAllReceivedVendorCosting(request);
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
