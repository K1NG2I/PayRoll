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
    public class MasterAttachmentTypeController : ControllerBase
    {
        private readonly IMasterAttachmentTypeService _masterAttachmentTypeService;
        private readonly IMapper _mapper;
        private readonly ILogger<MasterAttachmentTypeController> _logger;

        public MasterAttachmentTypeController(IMasterAttachmentTypeService masterAttachmentTypeService, IMapper mapper, ILogger<MasterAttachmentTypeController> logger)
        {
            _masterAttachmentTypeService = masterAttachmentTypeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllMasterAttachmentType")]
        public async Task<ActionResult<IEnumerable<MasterAttachmentType>>> GetAllMasterAttachmentType()
        {
            try
            {
                _logger.LogInformation("Requesting MasterAttachmentType Details...");
                var master = await _masterAttachmentTypeService.GetAllMasterAttachmentType();
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterAttachmentType/{id}")]
        public async Task<ActionResult<MasterAttachmentType>> GetMasterAttachmentTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterAttachmentTypeById Details....");
                var master = await _masterAttachmentTypeService.GetMasterAttachmentTypeById(id);
                if (master == null)
                {
                    return NotFound("MasterAttachmentType not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddMasterAttachmentType")]
        public async Task<ActionResult<MasterAttachmentType>> AddMasterAttachmentType(MasterAttachmentTypeDto masterAttachmentType)
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
                var result = _mapper.Map<MasterAttachmentType>(masterAttachmentType);
                await _masterAttachmentTypeService.AddMasterAttachmentType(result);
                return Ok("Add MasterAttachmentType Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateMasterAttachmentType/{id}")]
        public async Task<ActionResult> UpdateMasterAttachmentType(int id, MasterAttachmentTypeDto masterAttachmentType)
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
                var result = _mapper.Map<MasterAttachmentType>(masterAttachmentType);
                result.AttachmentTypeId = id;
                await _masterAttachmentTypeService.UpdateMasterAttachmentType(result);
                return Ok("Update MasterAttachmentType Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteMasterAttachmentType/{id}")]
        public async Task<ActionResult> DeleteMasterAttachmentType(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterAttachmentType Details....");
                await _masterAttachmentTypeService.DeleteMasterAttachmentType(id);
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
