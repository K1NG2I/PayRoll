using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class RfqFinalController : ControllerBase
    {
        private readonly IRfqFinalService _rfqFinalService;
        private readonly IMapper _mapper;
        private readonly ILogger<RfqFinalController> _logger;
        public RfqFinalController(IRfqFinalService rfqFinalService, IMapper mapper, ILogger<RfqFinalController> logger)
        {
            _logger = logger;
            _rfqFinalService = rfqFinalService;
            _mapper = mapper;
        }

        [HttpPost("AddRfqFinal")]
        public async Task<ActionResult> AddRfqFinal([FromBody] RfqFinalizationSaveDto rfqFinalizationSaveDto)
        {
            try
            {
                _logger.LogInformation("Add RfqFinal Details....");
                if (rfqFinalizationSaveDto == null)
                {
                    return BadRequest("RfqFinal data is null");
                }
                var rfqFinal = _mapper.Map<RfqFinal>(rfqFinalizationSaveDto.RfqFinalDto);
                var rfqFinalRates = _mapper.Map<List<RfqFinalRate>>(rfqFinalizationSaveDto.RfqFinalRateDtos);
                var result = await _rfqFinalService.AddRfqFinal(rfqFinal, rfqFinalRates);
                if (!result)
                {
                    return NotFound("RfqFinal not added");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding RfqFinal");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("UpdateRfqFinal/{rfqFinalId}")]
        public async Task<IActionResult> UpdateRfqFinal(int rfqFinalId,RfqFinalizationSaveDto rfqFinalizationSaveDto)
        {
            try
            {
                _logger.LogInformation("Update Rfq Finalization Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var rfqFinalUpdate = _mapper.Map<RfqFinal>(rfqFinalizationSaveDto.RfqFinalDto);
                var rfqFinalRatesUpdate = _mapper.Map<List<RfqFinalRate>>(rfqFinalizationSaveDto.RfqFinalRateDtos);
                rfqFinalUpdate.RfqFinalIdId = rfqFinalId;
                var result = await _rfqFinalService.UpdateRfqFinal(rfqFinalUpdate,rfqFinalRatesUpdate);
                if (!result)
                {
                    return NotFound("Rfq Final not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("AwardedVendor/{id}")]
        public async Task<ActionResult> AwardedVendor(int id)
        {
            try
            {
                _logger.LogInformation("Get AwardedVendor Details....");
                var message = await _rfqFinalService.AwardedVendor(id);
                if (message == null)
                {
                    return NotFound("AwardedVendor not Found");
                }
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("GetAllRfqFinalization")]
        public async Task<ActionResult> GetAllRfqFinalization([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Get RFQ Finalization Details....");
                var rfqFinalizationList = await _rfqFinalService.GetAllRfqFinalization(pagingParam);
                if (rfqFinalizationList == null)
                {
                    NotFound("Rfq Finalization list unavailable");
                }
                return Ok(rfqFinalizationList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteRfqFinal/{rfqFinalId}")]
        public async Task<IActionResult> DeleteRfqFinal(int rfqFinalid)
        {
            try
            {
                _logger.LogInformation("Delete Rfq Finalization Details....");
                var result = await _rfqFinalService.DeleteRfqFinal(rfqFinalid);
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
