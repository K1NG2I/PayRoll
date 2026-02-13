using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyCountryController : ControllerBase
    {
        private readonly ICompanyCountryService _companyCountryService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyCountryController> _logger;

        public CompanyCountryController(ICompanyCountryService companyCountryService, IMapper mapper, ILogger<CompanyCountryController> logger)
        {
            _companyCountryService = companyCountryService;
            _mapper = mapper;
            _logger = logger;
        }

        //CompanyCountry

        [HttpGet("GetAllCountry")]
        public async Task<ActionResult<IEnumerable<CompanyCountry>>> GetAllCountry()
        {
            try
            {
                _logger.LogInformation("Get All Country Details....");
                var countries = await _companyCountryService.GetAllCountry();
                if (countries == null)
                {
                    NotFound("Country unavailable");
                }
                return Ok(countries);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPost("AddCountry")]
        public async Task<ActionResult<CompanyCountry>> AddCountry(CompanyCountryDto country)
        {
            try
            {
                _logger.LogInformation("Add Country Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyCountry>(country);
                await _companyCountryService.AddCountry(result);
                return Ok("Add Country Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateCountry/{id}")]
        public async Task<ActionResult> UpdateCountry(int id, CompanyCountryDto country)
        {
            try
            {
                _logger.LogInformation("Update Country Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyCountry>(country);
                result.CountryId = id;
                await _companyCountryService.UpdateCountry(result);
                return Ok("Update Country Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteCountry/{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            try
            {
                _logger.LogInformation("Delete Country Details....");
                await _companyCountryService.DeleteCountry(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetCountryById/{id}")]
        public async Task<ActionResult<CompanyCountry>> GetCountryById(int id)
        {
            try
            {
                _logger.LogInformation("Get CountryById Details....");
                var country = await _companyCountryService.GetCountryById(id);
                if (country == null || country.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("Country not Found");
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
        [HttpGet("GetStatesAndCitiesByCountry")]
        public async Task<ActionResult<LocationData>> GetStatesAndCitiesByCountry()
        {
            try
            {
                _logger.LogInformation("Get CountryById Details....");
                var country = await _companyCountryService.GetStatesAndCitiesByCountry();
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
