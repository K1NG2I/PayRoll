using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleIndentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<VehicleIndentController> _logger;
        private readonly IVehicleIndentService _vehicleIndentService;
        public VehicleIndentController(IMapper mapper, ILogger<VehicleIndentController> logger, IVehicleIndentService vehicleIndentService)
        {
            _mapper = mapper;
            _logger = logger;
            _vehicleIndentService = vehicleIndentService;
        }

        [HttpPost("AddVehicleIndent")]
        public async Task<ActionResult> AddVehicleIndent([FromBody] VehicleIndentDto vehicleIndentDto)
        {
            try
            {
                _logger.LogInformation("Add AddVehicleIndent Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var vehicleIndentRequest = _mapper.Map<VehicleIndent>(vehicleIndentDto);
                var result = await _vehicleIndentService.AddVehicleIndent(vehicleIndentRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GenerateVehicleIndent")]
        public async Task<IActionResult> GenerateVehicleIndent()
        {
            try
            {
                _logger.LogInformation("Requesting Generate next Indent No...");
                var nextIndentNo = await _vehicleIndentService.GenerateVehicleIndent();
                if (nextIndentNo == null)
                {
                    NotFound("nextIndentNo is not Found");
                }
                return Ok(nextIndentNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllVehicleIndentList")]
        public async Task<IActionResult> GetAllVehicleIndentList([FromQuery]int companyId)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllVehicleIndentList Details...");
                var vehicleIndentList = await _vehicleIndentService.GetAllVehicleIndentList(companyId);
                if (vehicleIndentList == null)
                {
                    NotFound("vehicleIndentList is not Found");
                }
                return Ok(vehicleIndentList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("GetAllVehicleIndent")]
        public async Task<ActionResult> GetAllVehicleIndent([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Get All Vehicle Indent Details....");
                var indent = await _vehicleIndentService.GetAllVehicleIndent(pagingParam);
                if (indent == null)
                {
                    NotFound("Vehicle Indent unavailable");
                }
                return Ok(indent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetVehicleIndentById/{id}")]
        public async Task<ActionResult<VehicleIndent>> GetVehicleIndentById(int id)
        {
            try
            {
                _logger.LogInformation("Get VehicleIndentById Details....");
                var vehicleIndent = await _vehicleIndentService.GetVehicleIndentById(id);
                if (vehicleIndent == null || vehicleIndent.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("Vehicle Indent not Found");
                }
                return Ok(vehicleIndent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPut("UpdateVehicleIndent/{id}")]
        public async Task<ActionResult> UpdateVehicleIndent(int id, VehicleIndentDto vehicleIndentDto)
        {
            try
            {
                _logger.LogInformation("Update VehicleIndent Details....");
                if (vehicleIndentDto == null)
                {
                    return BadRequest();
                }
                var result = _mapper.Map<VehicleIndent>(vehicleIndentDto);
                result.IndentId = id;
                await _vehicleIndentService.UpdateVehicleIndent(result);
                return Ok("Update VehicleIndent Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteVehicleIndent/{id}")]
        public async Task<ActionResult> DeleteVehicleIndent(int id)
        {
            try
            {
                _logger.LogInformation("Delete Vehicle Indent Details....");
                var result = await _vehicleIndentService.DeleteVehicleIndent(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("IndentReferenceCheckInRfqAsync/{indentId}")]
        public async Task<ActionResult> IndentReferenceCheckInRfqAsync(int indentId)
        {
            try
            {
                var indent = await _vehicleIndentService.IndentReferenceCheckInRfqAsync(indentId);
                return Ok(indent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

    }
}
