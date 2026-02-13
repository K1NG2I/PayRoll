using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterPartyRouteController : ControllerBase
    {
        private readonly IMasterPartyRouteService _masterPartyRouteService;
        private readonly IMapper _mapper;
        private readonly ILogger<MasterPartyRouteController> _logger;

        public MasterPartyRouteController(IMasterPartyRouteService masterPartyRouteService, IMapper mapper, ILogger<MasterPartyRouteController> logger)
        {
            _masterPartyRouteService = masterPartyRouteService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllMasterPartyRoute")]
        public async Task<ActionResult<IEnumerable<MasterPartyRoute>>> GetAllMasterPartyRoute()
        {
            try
            {
                _logger.LogInformation("Requesting MasterPartyRoute Details...");
                var master = await _masterPartyRouteService.GetAllMasterPartyRoute();
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterPartyRoute/{id}")]
        public async Task<ActionResult<MasterPartyRoute>> GetMasterPartyRouteById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterPartyRoute Details....");
                var messageTemplate = await _masterPartyRouteService.GetMasterPartyRouteById(id);
                if (messageTemplate == null)
                {
                    return NotFound("MasterPartyRoute not Found");
                }
                return Ok(messageTemplate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddMasterPartyRoute")]
        public async Task<ActionResult> AddMasterPartyRoute([FromBody]List<MasterPartyRouteDto> masterPartyRoutes)
        {
            try
            {
                _logger.LogInformation("Add MasterPartyRoute Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<List<MasterPartyRoute>>(masterPartyRoutes);
                await _masterPartyRouteService.AddMasterPartyRoute(result);
                return Ok("Add MasterPartyRoute Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateMasterPartyRoute/{id}")]
        public async Task<ActionResult> UpdateMasterPartyRoute(int id, MasterPartyRouteDto masterPartyRoute)
        {
            try
            {
                _logger.LogInformation("Update masterPartyRoute Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<MasterPartyRoute>(masterPartyRoute);
                result.PartyRouteId = id;
                //await _masterPartyRouteService.UpdateMasterPartyRoute(result);
                return Ok("Update MasterPartyRoute Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteMasterPartyRoute/{id}")]
        public async Task<ActionResult> DeleteMasterPartyRoute(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterPartyRoute Details....");
                var result = await _masterPartyRouteService.DeleteMasterPartyRoute(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterPartyRouteByPartyId/{id}")]
        public async Task<IActionResult> GetMasterPartyRouteByPartyId(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterPartyRoute Details by PartyId....");
                var result = await _masterPartyRouteService.GetMasterPartyRouteByPartyId(id);
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
