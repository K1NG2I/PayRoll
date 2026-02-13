using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Application.Provider;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class MasterPartyVehicleTypeController : ControllerBase
    {
        private readonly IMasterPartyVehicleTypeService _masterPartyVehicleTypeService;
        private readonly IMapper _mapper;
        private readonly ILogger<MasterPartyVehicleTypeController> _logger;
        public MasterPartyVehicleTypeController(IMasterPartyVehicleTypeService masterPartyVehicleTypeService,IMapper mapper,ILogger<MasterPartyVehicleTypeController> logger)
        {
            _masterPartyVehicleTypeService = masterPartyVehicleTypeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetMasterPartyVehicleTypeByPartyId/{id}")]
        public async Task<IActionResult> GetMasterPartyVehicleTypeByPartyId(int id)
        {
            try
            {
                _logger.LogInformation("Get Master Party Vehicle Type Details....");
                var result = await _masterPartyVehicleTypeService.GetMasterPartyVehicleTypeByPartyId(id);
                if (result == null)
                {
                    return NotFound("Master Party Vehicle Type not Found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteMasterPartyVehicleType/{id}")]
        public async Task<ActionResult> DeleteMasterPartyVehicleType(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterPartyVehicleType Details....");
                var result = await _masterPartyVehicleTypeService.DeleteMasterPartyVehicleType(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterPartyVehicleTypeById/{id}")]
        public async Task<IActionResult> GetMasterPartyVehicleTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get Master Party Vehicle Type Details....");
                var result = await _masterPartyVehicleTypeService.GetMasterPartyVehicleTypeById(id);
                if (result == null)
                {
                    return NotFound("Master Party Vehicle Type not Found");
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
