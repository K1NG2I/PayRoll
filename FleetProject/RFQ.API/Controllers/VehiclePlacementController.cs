using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
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

    public class VehiclePlacementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<VehiclePlacementController> _logger;
        private readonly IVehiclePlacementService _vehiclePlacementService;

        public VehiclePlacementController(IMapper mapper, ILogger<VehiclePlacementController> logger, IVehiclePlacementService vehiclePlacementService)
        {
            _mapper = mapper;
            _logger = logger;
            _vehiclePlacementService = vehiclePlacementService;
        }

        [HttpPost("AddVehiclePlacement")]
        public async Task<ActionResult> AddVehiclePlacement([FromBody] VehiclePlacementDto vehiclePlacementDto)
        {
            try
            {
                _logger.LogInformation("Add Vehicle Placement Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var vehiclePlacement = _mapper.Map<VehiclePlacement>(vehiclePlacementDto);
                var result = await _vehiclePlacementService.AddVehiclePlacement(vehiclePlacement);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GeneratePlacementNo")]
        public async Task<ActionResult> GeneratePlacementNo()
        {
            try
            {
                var nextPlacementNo = await _vehiclePlacementService.GeneratePlacementNo();
                if (nextPlacementNo == null)
                {
                    return NotFound("nextPlacementNo was not found.");
                }
                return Ok(nextPlacementNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating the placement number.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("AutoFetchPlacement/{id}")]
        public async Task<ActionResult<AutoFetchIndentResponseDto>> AutoFetchPlacement(int id)
        {
            try
            {
                _logger.LogInformation("Get FetchPlacement Details....");
                var message = await _vehiclePlacementService.AutoFetchPlacement(id);
                if (message == null)
                {
                    return NotFound("FetchPlacement not Found");
                }
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("GetAllVehiclePlacement")]
        public async Task<ActionResult> GetAllVehiclePlacement([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Get All Vehicle Indent Details....");
                var indent = await _vehiclePlacementService.GetAllVehiclePlacement(pagingParam);
                if (indent == null)
                {
                    NotFound("Vehicle Placement unavailable");
                }
                return Ok(indent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetVehiclePlacementtById/{id}")]
        public async Task<ActionResult<VehicleIndent>> GetVehiclePlacementtById(int id)
        {
            try
            {
                _logger.LogInformation("Get VehiclePlacementtById Details....");
                var vehiclePlacement = await _vehiclePlacementService.GetVehiclePlacementtById(id);
                if (vehiclePlacement == null || vehiclePlacement.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("Vehicle Indent not Found");
                }
                return Ok(vehiclePlacement);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPut("UpdateVehiclePlacement/{id}")]
        public async Task<ActionResult> UpdateVehiclePlacement(int id, VehiclePlacementDto vehiclePlacementDto)
        {
            try
            {
                _logger.LogInformation("Update VehicleIndent Details....");
                if (vehiclePlacementDto == null)
                {
                    return BadRequest();
                }
                var result = _mapper.Map<VehiclePlacement>(vehiclePlacementDto);
                result.IndentId = id;
                await _vehiclePlacementService.UpdateVehiclePlacement(result);
                return Ok("Update VehiclePlacement Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteVehiclePlacement/{id}")]
        public async Task<ActionResult> DeleteVehiclePlacement(int id)
        {
            try
            {
                _logger.LogInformation("Delete Vehicle Placement Details....");
                await _vehiclePlacementService.DeleteVehiclePlacement(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllVehiclePlacementNo")]
        public async Task<IActionResult> GetAllVehiclePlacementNo([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllVehiclePlacementNo Details...");
                var vehicleIndentList = await _vehiclePlacementService.GetAllVehiclePlacementNo(companyId);
                if (vehicleIndentList == null)
                {
                    NotFound("GetAllVehiclePlacementNo is not Found");
                }
                return Ok(vehicleIndentList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("CheckVehicleAndIndentUnique/{vehicleId}/{indentId}")]
        public async Task<IActionResult> CheckVehicleAndIndentUnique(int vehicleId, int indentId)
        {
            try
            {
                var result = await _vehiclePlacementService.CheckVehicleAndIndentUnique(vehicleId, indentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetAwardedIndentList/{companyId}")]
        public async Task<IActionResult> GetAwardedIndentList(int companyId)
        {
            try
            {
                var result = await _vehiclePlacementService.GetAwardedIndentList(companyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetVehiclePlacementCountByIndentNo/{indentId}")]
        public async Task<IActionResult> GetVehiclePlacementCountByIndentNo(int indentId)
        {
            try
            {
                var result = await _vehiclePlacementService.GetVehiclePlacementCountByIndentNo(indentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("CheckAwardedVendor")]
        public async Task<IActionResult> CheckAwardedVendor(CheckAwardedVendorRequestDto requestDto)
        {
            try
            {
                var result = await _vehiclePlacementService.CheckAwardedVendor(requestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
