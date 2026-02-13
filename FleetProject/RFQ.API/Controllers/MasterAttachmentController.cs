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
    public class MasterAttachmentController : ControllerBase
    {
        private readonly IMasterAttachmentService _masterAttachmentService;
        private readonly IMapper _mapper;
        private readonly ILogger<MasterAttachmentController> _logger;

        public MasterAttachmentController(IMasterAttachmentService masterAttachmentService,
                                          IMapper mapper, ILogger<MasterAttachmentController> logger)
        {
            _masterAttachmentService = masterAttachmentService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetAllMasterAttachment")]
        public async Task<ActionResult<IEnumerable<MasterAttachment>>> GetAllMasterAttachment()
        {
            try
            {
                _logger.LogInformation("Requesting MasterAttachment Details...");
                var master = await _masterAttachmentService.GetAllMasterAttachment();
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterAttachment/{id}")]
        public async Task<ActionResult<MasterAttachment>> GetMasterAttachmentById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterAttachmentById Details....");
                var master = await _masterAttachmentService.GetMasterAttachmentId(id);
                if (master == null)
                {
                    return NotFound("MasterAttachment not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddMasterAttachment")]
        public async Task<ActionResult<MasterAttachment>> AddMasterAttachment(List<MasterAttachmentDto> masterAttachment)
        {
            try
            {
                _logger.LogInformation("Add MasterType Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)  
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<List<MasterAttachment>>(masterAttachment);
                await _masterAttachmentService.AddMasterAttachment(result);
                return Ok("Add MasterAttachment Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateMasterAttachment")]
        public async Task<ActionResult> UpdateMasterAttachment(List<MasterAttachmentDto> masterAttachment)
        {
            try
            {
                _logger.LogInformation("Update MasterAttachment Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                        .SelectMany(modelState => modelState.Value.Errors)
                        .Select(err => err.ErrorMessage)
                        .ToList();

                    return BadRequest(messages);
                }

                var result = _mapper.Map<List<MasterAttachment>>(masterAttachment);
                

                await _masterAttachmentService.UpdateMasterAttachment(result);
                return Ok("Update MasterAttachment Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating MasterAttachment");
                return StatusCode(500, "An error occurred while updating the master attachment.");
            }
        }


       
        [HttpDelete("DeleteMasterAttachment/{id}")]
        public async Task<ActionResult> DeleteMasterAttachment(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterAttachment Details....");
                var result = await _masterAttachmentService.DeleteMasterAttachment(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }   
        }

        [HttpDelete("DeleteMasterAttachmentTable/{id}")]
        public async Task<ActionResult> DeleteMasterAttachmentTable(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterAttachment Details....");
                await _masterAttachmentService.DeleteMasterAttachmentTable(id);
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
