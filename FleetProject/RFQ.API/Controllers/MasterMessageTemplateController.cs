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
    public class MasterMessageTemplateController : ControllerBase
    {
        private readonly IMasterMessageTemplateService _masterMessageTemplateService;
        private readonly IMapper _mapper;
        private readonly ILogger<MasterMessageTemplateController> _logger;

        public MasterMessageTemplateController(IMasterMessageTemplateService masterMessageTemplateService, IMapper mapper, ILogger<MasterMessageTemplateController> logger)
        {
            _masterMessageTemplateService = masterMessageTemplateService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllMasterMessageTemplate")]
        public async Task<ActionResult<IEnumerable<MasterMessageTemplate>>> GetAllMasterMessageTemplate()
        {
            try
            {
                _logger.LogInformation("Requesting MasterMessageTemplate Details...");
                var master = await _masterMessageTemplateService.GetAllMasterMessageTemplate();
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterMessageTemplate/{id}")]
        public async Task<ActionResult<MasterMessageTemplate>> GetMasterAttachmentTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterAttachmentTypeById Details....");
                var messageTemplate = await _masterMessageTemplateService.GetMasterMessageTemplateById(id);
                if (messageTemplate == null)
                {
                    return NotFound("MasterAttachmentType not Found");
                }
                return Ok(messageTemplate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddMasterMessageTemplate")]
        public async Task<ActionResult<MasterMessageTemplate>> AddMasterMessageTemplate(MasterMessageTemplateDto masterMessage)
        {
            try
            {
                _logger.LogInformation("Add MasterMessageTemplate Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<MasterMessageTemplate>(masterMessage);
                await _masterMessageTemplateService.AddMasterMessageTemplate(result);
                return Ok("Add MasterMessageTemplate Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateMasterMessageTemplate/{id}")]
        public async Task<ActionResult> UpdateMasterAttachmentType(int id, MasterMessageTemplateDto masterMessage)
        {
            try
            {
                _logger.LogInformation("Update MasterMessageTemplate Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<MasterMessageTemplate>(masterMessage);
                result.TemplateId = id;
                await _masterMessageTemplateService.UpdateMasterMessageTemplate(result);
                return Ok("Update MasterMessageTemplate Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteMasterMessageTemplate/{id}")]
        public async Task<ActionResult> DeleteMasterMessageTemplate(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterMessageTemplate Details....");
                await _masterMessageTemplateService.DeleteMasterMessageTemplate(id);
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
