using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;
        private readonly ILogger<DriverController> _logger;
        public DriverController(IDriverService driverService, IMapper mapper, ILogger<DriverController> logger)
        {
            _driverService = driverService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("GetAllDrivers")]
        public async Task<ActionResult> GetAllDrivers(PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting Drivers Details...");
                var drivers = await _driverService.GetAllDrivers(pagingParam);
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetDriverById/{id}")]
        public async Task<ActionResult<Driver>> GetDriverById(int id)
        {
            try
            {
                _logger.LogInformation("Get Driver Details....");
                var driver = await _driverService.GetDriverById(id);
                if (driver == null || driver.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("Driver not Found");
                }
                return Ok(driver);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddDriver")]
        public async Task<ActionResult<Driver>> AddDriver([FromBody] DriverDto driver)
        {
            try
            {
                _logger.LogInformation("Add Driver Details....");

                var driverRequest = _mapper.Map<Driver>(driver);
                var result = await _driverService.AddDriver(driverRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                if (!string.IsNullOrWhiteSpace(innerMessage) && innerMessage.ToLower().Contains("unique") || innerMessage.ToLower().Contains("already"))
                {
                    _logger.LogError(ex, "Error while adding Driver.");
                    return Conflict(innerMessage);
                }
                else
                {
                    _logger.LogError(ex, "Error while adding Driver.");
                    return StatusCode(500, "Internal server error.");
                }
            }
        }

        [HttpPut("UpdateDriver/{id}")]
        public async Task<ActionResult> UpdateDriver(int id, DriverDto driver)
        {
            try
            {
                _logger.LogInformation("Update Driver Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<Driver>(driver);
                result.DriverId = id;
                await _driverService.UpdateDriver(result);
                return Ok("Update Driver Successfully");
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                if (!string.IsNullOrWhiteSpace(innerMessage) && innerMessage.ToLower().Contains("unique") || innerMessage.ToLower().Contains("already"))
                {
                    _logger.LogError(ex, "Error while adding Driver.");
                    return Conflict("Driver already exists");
                }
                else
                {
                    _logger.LogError(ex, "Error while Update Driver.");
                    return StatusCode(500, "Internal server error.");
                }
            }
        }

        [HttpDelete("DeleteDriver/{id}")]
        public async Task<ActionResult> DeleteDriver(int id)
        {
            try
            {
                _logger.LogInformation("Delete Driver Details....");
                await _driverService.DeleteDriver(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetDriverType")]
        public async Task<ActionResult<InternalMaster>> GetDriverType()
        {
            try
            {
                _logger.LogInformation("Get GetDriverType");
                var master = await _driverService.GetDriverType();
                if (master == null)
                {
                    return NotFound("GetDriverType not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllDriverList")]
        public async Task<ActionResult> GetAllDriverList()
        {
            try
            {
                _logger.LogInformation("Requesting Drivers Details...");
                var drivers = await _driverService.GetAllDriverList();
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GenerateDriverCode/{UserId}")]
        public async Task<ActionResult> GenerateDriverCode(int UserId)
        {
            try
            {

                var nextDriverCode = await _driverService.GenerateDriverCode(UserId);
                if (nextDriverCode == null)
                {
                    throw new Exception("Error generating DriverCode.");
                }
                return Ok(nextDriverCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating the DriverCode.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
