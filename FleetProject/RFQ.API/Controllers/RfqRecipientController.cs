using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class RfqRecipientController : Controller
    {
        private readonly IRfqRecipientService _rfqRecipientService;
        private readonly IMapper _mapper;
        private readonly ILogger<RfqRecipientController> _logger;
        public RfqRecipientController(IRfqRecipientService rfqRecipientService, IMapper mapper, ILogger<RfqRecipientController> logger)
        {
            _rfqRecipientService = rfqRecipientService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetRfqRecipientById/{id}")]
        public async Task<ActionResult> GetRfqRecipientById(int id)
        {
            try
            {
                _logger.LogInformation("Get GetRfqRecipientById Details....");
                var recipient = await _rfqRecipientService.GetRfqRecipientById(id);
                if (recipient == null)
                {
                    return NotFound("Rfq Recipient not Found");
                }
                return Ok(recipient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllRfqRecipient")]
        public async Task<ActionResult<IEnumerable<RfqRecipient>>> GetAllRfqRecipient()
        {
            try
            {
                _logger.LogInformation("Get RFQ Recipient Details....");
                var recipientList = await _rfqRecipientService.GetAllRfqRecipient();
                if (recipientList == null)
                {
                    NotFound("Rfq Recipient list unavailable");
                }
                return Ok(recipientList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddRfqRecipient")]
        public async Task<ActionResult> AddRfqRecipient([FromBody] List<RfqRecipientRequestDto> rfqRecipientRequestDto)
        {
            try
            {
                _logger.LogInformation("Add RfqRecipient Details....");
                if (rfqRecipientRequestDto == null)
                {
                    return BadRequest("Invalid RfqRecipient data.");
                }
                var rfqRecipients = _mapper.Map<List<RfqRecipient>>(rfqRecipientRequestDto);
                await _rfqRecipientService.AddRfqRecipient(rfqRecipients);
                return Ok("RfqRecipients added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding RfqRecipients");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("UpdateRfqRecipient/{id}")]
        public async Task<ActionResult> UpdateRfqRecipient(int id, List<RfqRecipientRequestDto> rfqRecipientRequestDto)
        {
            try
            {
                _logger.LogInformation("Update Rfq Recipient detail....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var rfqRecipients = _mapper.Map<List<RfqRecipient>>(rfqRecipientRequestDto);
                await _rfqRecipientService.UpdateRfqRecipient(id,rfqRecipients);
                return Ok("Update RFQ Recipient Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteRfqRecipient/{id}")]
        public async Task<ActionResult> DeleteRfqRecipient(int id)
        {
            try
            {
                _logger.LogInformation("Delete Rfq Recipient....");
                await _rfqRecipientService.DeleteRfqRecipient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
