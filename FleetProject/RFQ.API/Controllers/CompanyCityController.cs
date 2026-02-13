using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyCityController : ControllerBase
    {
        private readonly ICompanyCityService _companyCityService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyCityController> _logger;

        public CompanyCityController(ICompanyCityService companyCityService, IMapper mapper, ILogger<CompanyCityController> logger)
        {
            _companyCityService = companyCityService;
            _mapper = mapper;
            _logger = logger;
        }

        //CompanyCity
        [HttpGet("GetCityById/{id}")]
        public async Task<ActionResult<CompanyCity>> GetCityById(int id)
        {
            try
            {
                _logger.LogInformation("Get CityById Details....");
                var city = await _companyCityService.GetCityById(id);
                if (city == null || city.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("City not Found");
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpGet("GetAllCity")]
        public async Task<ActionResult<IEnumerable<CompanyCity>>> GetAllCity()
        {
            try
            {
                _logger.LogInformation("Get All City Details....");
                var City = await _companyCityService.GetAllCity();
                if (City == null)
                {
                    NotFound("City unavailable");
                }
                return Ok(City);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPost("AddCity")]
        public async Task<ActionResult<CompanyCity>> AddCity(CompanyCityDto City)
        {
            try
            {
                _logger.LogInformation("Add City Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyCity>(City);
                await _companyCityService.AddCity(result);
                return Ok("Add City Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateCity/{id}")]
        public async Task<ActionResult> UpdateCity(int id, CompanyCityDto City)
        {
            try
            {
                _logger.LogInformation("Update City Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyCity>(City);
                result.CityId = id;
                await _companyCityService.UpdateCity(result);
                return Ok("Update City Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPut("DeleteCity/{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            try
            {
                _logger.LogInformation("Delete City Details....");
                await _companyCityService.DeleteCity(id);
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
