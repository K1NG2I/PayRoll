using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public VehicleController(IVehicleService vehicleService, IMapper mapper, ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("GetAllVehicles")]
        public async Task<ActionResult> GetAllVehicles([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting Vehicle Details...");
                var vehicles = await _vehicleService.GetAllVehicles(pagingParam);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetVehicleById/{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            try
            {
                _logger.LogInformation("Get Vehicle Details....");
                var vehicle = await _vehicleService.GetVehicleById(id);
                if (vehicle == null || vehicle.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("Vehicle not Found");
                }
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddVehicle")]
        public async Task<ActionResult<Vehicle>> AddVehicle([FromBody] VehicleDto vehicle)
        {
            try
            {
                _logger.LogInformation("Add Vehicle Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var vehicleRequest = _mapper.Map<Vehicle>(vehicle);
                var result = await _vehicleService.AddVehicle(vehicleRequest);
                if (result)
                {
                    return Ok(new { success = true, message = "Add Vehicle Successfully.." });
                }
                else
                {
                    return Ok(new { success = false, message = "Duplicate record not allowed." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(new { success = false, message = "Something went wrong, please try again later." });
            }
        }


        [HttpPut("UpdateVehicle/{id}")]
        public async Task<ActionResult> UpdateVehicle(int id, VehicleDto vehicle)
        {
            try
            {
                _logger.LogInformation("Update Vehicle Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<Vehicle>(vehicle);
                result.VehicleId = id;
                await _vehicleService.UpdateVehicle(result);
                return Ok("Update Vehicle Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteVehicle/{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            try
            {
                _logger.LogInformation("Delete Vehicle Details....");
                await _vehicleService.DeleteVehicle(id);
                return Ok("Delete Vehicle Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllVehicleCategory")]
        public async Task<ActionResult<InternalMaster>> GetAllVehicleCategory()
        {
            try
            {
                _logger.LogInformation("Get GetAllVehicleCategory Details...");
                var master = await _vehicleService.GetAllVehicleCategory();
                if (master == null)
                {
                    return NotFound("GetAllVehicleCategory not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllOwnerOrVendor")]
        public async Task<ActionResult<MasterParty>> GetAllOwnerOrVendor([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Get GetAllOwnerOrVendo Details...");
                var master = await _vehicleService.GetAllOwnerOrVendor(companyId);
                if (master == null)
                {
                    return NotFound("GetAllOwnerOrVendor not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllVehicleType")]
        public async Task<ActionResult<IEnumerable<VehicleType>>> GetAllVehicleType([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Requesting VehicleType Details...");
                var vehicleTypes = await _vehicleService.GetAllVehicleType(companyId);

                if (vehicleTypes != null && vehicleTypes.Any())
                {
                    return Ok(vehicleTypes);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetVehicleNumber")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicleNumber()
        {
            try
            {
                _logger.LogInformation("Requesting VehicleType Details...");
                var vehicleNo = await _vehicleService.GetVehicleNumber();

                if (vehicleNo == null || !vehicleNo.Any())
                {
                    _logger.LogWarning(" Vehicle Number found.");
                    return NotFound("Vehicle Number available.");
                }

                return Ok(vehicleNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
