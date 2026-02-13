using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFQ.Application.Interface;
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
    public class LocationController
        : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocationService locationService, IMapper mapper, ILogger<LocationController> logger)
        {
            _locationService = locationService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet("GetAllLocationList")]
        public async Task<ActionResult> GetAllLocationList([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Requesting Location Details...");
                var master = await _locationService.GetAllLocationList(companyId);
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
        [HttpPost("GetAllLocation")]
        public async Task<ActionResult> GetAllLocation([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting Location Details...");
                var master = await _locationService.GetAllLocation(pagingParam);
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetLocationById/{id}")]
        public async Task<ActionResult<MasterLocation>> GetLocationById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterLocation Details....");
                var master = await _locationService.GetLocationyId(id);
                if (master == null || master.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("Location not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddLocation")]
        public async Task<ActionResult> AddLocation(MasterLocationDto masterLoction)
        {
            try
            {
                _logger.LogInformation("Add Location Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<MasterLocation>(masterLoction);
                var response = await _locationService.AddLocation(result);
                return Ok(response);
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                if (innerMessage.Contains("UNIQUE") || innerMessage.Contains("duplicate"))
                {
                    _logger.LogError(ex, "Error already exists adding Location.");
                    return Conflict("Location name or code already exists");
                }
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("UpdateLocation/{id}")]
        public async Task<ActionResult> UpdateLocation(int id, MasterLocationDto masterLoction)
        {
            try
            {
                _logger.LogInformation("Update Loction Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<MasterLocation>(masterLoction);
                result.LocationId = id;
                await _locationService.UpdateLocation(result);
                return Ok("Update Location Successfully");
            }
            catch (DbUpdateException ex)
                {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                if (innerMessage.Contains("UNIQUE") || innerMessage.Contains("duplicate"))
                {
                    _logger.LogError(ex, "Error already exists adding Location.");
                    return Conflict("Location name already exists");
                }
                else
                    throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw;
            }
        }

        [HttpDelete("DeleteLoction/{id}")]
        public async Task<ActionResult> DeleteLoction(int id)
        {
            try
            {
                _logger.LogInformation("Delete Loction Details....");
                await _locationService.DeleteLocation(id);
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
