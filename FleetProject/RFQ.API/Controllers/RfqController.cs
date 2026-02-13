using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
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
    public class RfqController : ControllerBase
    {
        private readonly IRfqService _rfqService;
        private readonly IMapper _mapper;
        private readonly ILogger<RfqController> _logger;
        private readonly IRfqRecipientService _rfqRecipientService;

        public RfqController(IRfqService rfqService, IMapper mapper, ILogger<RfqController> logger, IRfqRecipientService rfqRecipientService)
        {
            _rfqService = rfqService;
            _mapper = mapper;
            _logger = logger;
            _rfqRecipientService = rfqRecipientService;
        }

        [HttpPost("GetAllRfq")]
        public async Task<IActionResult> GetAllRfq([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Get RFQ Details....");
                var rfqList = await _rfqService.GetAllRfq(pagingParam);
                if (rfqList == null)
                {
                    NotFound("Rfq list unavailable");
                }
                return Ok(rfqList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetRfqById/{id}")]
        public async Task<IActionResult> GetRfqById(int id)
        {
            try
            {
                _logger.LogInformation("Get GetRfqById Details....");
                var rfq = await _rfqService.GetRfqId(id);
                if (rfq == null || rfq.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("Rfq not Found");
                }
                return Ok(rfq);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddRfq")]
        public async Task<IActionResult> AddRfq([FromBody] RequestForQuoteDto requestForQouteDto)
        {
            try
            {
                _logger.LogInformation("Add RFQ Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var rfqRequest = _mapper.Map<Rfq>(requestForQouteDto.RfqRequestDto);
                var recipientRequest = _mapper.Map<List<RfqRecipient>>(requestForQouteDto.RfqRecipients);
                var result = await _rfqService.AddRfq(rfqRequest, recipientRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateRfq/{rfqId}")]
        public async Task<IActionResult> UpdateRfq(int rfqId, RequestForQuoteDto requestForQuoteDto)
        {
            try
            {
                _logger.LogInformation("Update Rfq Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var rfqUpdateRequest = _mapper.Map<Rfq>(requestForQuoteDto.RfqRequestDto);
                var updatedRecipients = _mapper.Map<List<RfqRecipient>>(requestForQuoteDto.RfqRecipients);
                rfqUpdateRequest.RfqId = rfqId;
                var result = await _rfqService.UpdateRfq(rfqUpdateRequest);
                if (result != null)
                    return Ok("Update RFQ Successfully");
                else
                    throw new Exception("RFQ Not Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteRfq/{rfqId}")]
        public async Task<IActionResult> DeleteRfq(int rfqId)
        {
            try
            {
                _logger.LogInformation("Delete Rfq Details....");
                await _rfqService.DeleteRfq(rfqId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Cannot delete RFQ: referenced in RFQFinalization.");
                return StatusCode(400, "Cannot delete RFQ: referenced in RFQFinalization.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GenerateRfqAutoNo")]
        public async Task<IActionResult> GenerateRfqAutoNo()
        {
            try
            {
                var nextIndentNo = await _rfqService.GenerateRfqAutoNo();
                if (nextIndentNo == null)
                {
                    NotFound("nextRfqAutoNo is not Found");
                }
                return Ok(nextIndentNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetRfqByRfqNo/{rfqNo}")]
        public async Task<IActionResult> GetRfqByRfqNo(string rfqNo)
        {
            try
            {
                var result = await _rfqService.GetRfqByRfqNo(rfqNo);
                if (result == null)
                {
                    NotFound("Rfq Data is Not Found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("GetAllVendorListForRfq")]
        public async Task<IActionResult> GetAllVendorListForRfq([FromBody] RfqVendorDetailsParam rfqVendorDetailsParam)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllVendorListForRfq Details...");
                var result = await _rfqService.GetAllVendorListForRfq(rfqVendorDetailsParam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("GetPreviousQuotesList")]
        public async Task<IActionResult> GetPreviousQuotesList([FromBody] RfqVendorDetailsParam rfqVendorDetailsParam)
        {
            try
            {
                _logger.LogInformation("Requesting GetPreviousQuotesList Details...");
                var result = await _rfqService.GetPreviousQuotesList(rfqVendorDetailsParam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetRfqQuoteRateVendorDetails/{rfqId}")]
        public async Task<IActionResult> GetRfqQuoteRateVendorDetails(int rfqId)
        {
            try
            {
                var result = await _rfqService.GetRfqQuoteRateVendorDetails(rfqId);
                if (result == null)
                {
                    NotFound("Rfq Data is Not Found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetRfqDrpList")]
        public async Task<IActionResult> GetRfqDrpList([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Get Dropdown List of Rfq...");
                var rfqDrpList = await _rfqService.GetRfqDrpList(companyId);
                var result = _mapper.Map<IEnumerable<RfqDrpListResponseDto>>(rfqDrpList);
                if (result == null)
                {
                    NotFound("Rfq Data is Not Found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetRfqTableData")]
        public async Task<IActionResult> GetRfqTableData()
        {
            try
            {
                var result = await _rfqService.GetRfqTableData();
                if (result == null)
                {
                    NotFound("Rfq Table Data is Not Found");
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
