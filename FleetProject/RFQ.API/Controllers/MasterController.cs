using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Models;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MasterController : ControllerBase
    {
        private readonly IInternalMasterTypeService _internalMasterTypeService;
        private readonly ILogger<MasterController> _logger;

        public MasterController(IInternalMasterTypeService internalMasterTypeService, ILogger<MasterController> logger)
        {
            _internalMasterTypeService = internalMasterTypeService;
            _logger = logger;
        }

        [HttpGet("GetAllMasterType")]
        public async Task<ActionResult<IEnumerable<InternalMasterType>>> GetAllInternalMaster()
        {
            try
            {
                _logger.LogInformation("Requesting MasterType Details...");
                var master = await _internalMasterTypeService.GetAllInternalMasterType();
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterType/{id}")]
        public async Task<ActionResult<InternalMasterType>> GetMasterTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterTypeById Details....");
                var master = await _internalMasterTypeService.GetInternalMasterTypeById(id);
                if (master == null)
                {
                    return NotFound("MasterType not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddMasterType")]
        public async Task<ActionResult<InternalMasterType>> AddMasterType(InternalMasterType masterType)
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
                await _internalMasterTypeService.AddInternalMasterType(masterType);
                return Ok("Add MasterType Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateMasterType/{id}")]
        public async Task<ActionResult> UpdateMasterType(int id, InternalMasterType masterType)
        {
            try
            {
                _logger.LogInformation("Update MasterType Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                await _internalMasterTypeService.UpdateInternalMasterType(masterType);
                return Ok("Update MasterType Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteMaster/{id}")]
        public async Task<ActionResult> DeleteMaster(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterType Details....");
                await _internalMasterTypeService.DeleteInternalMasterType(id);
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
