using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IMapper _mapper;
        private readonly ILogger<VehicleTypeController> _logger;


        public VehicleTypeController(IVehicleTypeService vehicleTypeService, IMapper mapper, ILogger<VehicleTypeController> logger)
        {
            _vehicleTypeService = vehicleTypeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("GetAllVehicleType")]
        public async Task<ActionResult> GetAllVehicleType([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting VehicleType Details...");
                var result = await _vehicleTypeService.GetAllVehicleType(pagingParam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetVehicleType/{id}")]
        public async Task<ActionResult<VehicleType>> GetVehicleTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get VehicleTypeById Details....");
                var master = await _vehicleTypeService.GetVehicleTypeById(id);
                if (master == null || master.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("VehicleType not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddVehicleType")]
        public async Task<ActionResult<VehicleType>> AddVehicleType(VehicleTypeDto VehicleType)
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
                var result = _mapper.Map<VehicleType>(VehicleType);
                var response = await _vehicleTypeService.AddVehicleType(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateVehicleType/{id}")]
        public async Task<ActionResult> UpdateVehicleType(int id, VehicleTypeDto VehicleType)
        {
            try
            {
                _logger.LogInformation("Update VehicleType Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<VehicleType>(VehicleType);
                result.VehicleTypeId = id;
                await _vehicleTypeService.UpdateVehicleType(result);
                return Ok("Update VehicleType Successfully");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("VehicleType Already Exsist."))
                    return StatusCode(409, ex.Message);
                else
                    throw;
            }
        }

        [HttpDelete("DeleteVehicleType/{id}")]
        public async Task<ActionResult> DeleteVehicleType(int id)
        {
            try
            {
                _logger.LogInformation("Delete VehicleType Details....");
                await _vehicleTypeService.DeleteVehicleType(id);
                return Ok();
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
                _logger.LogInformation("Get GetAllVehicleCategory");
                var master = await _vehicleTypeService.GetAllVehicleCategory();
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
        public async Task<ActionResult<MasterParty>> GetAllOwnerOrVendor()
        {
            try
            {
                _logger.LogInformation("Get GetAllOwnerOrVendor");
                var master = await _vehicleTypeService.GetAllOwnerOrVendor();
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

        [HttpGet("GetVehicleTypeList")]
        public async Task<ActionResult> GetVehicleList()
        {
            try
            {
                _logger.LogInformation("Get All VehicleList Details....");
                var vehicle = await _vehicleTypeService.GetVehicleTypeList();
                if (vehicle == null)
                {
                    NotFound("VehicleList unavailable");
                }
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
