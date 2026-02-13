using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFQ.Application.Interface;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyConfigurationController : ControllerBase
    {
        private readonly ICompanyConfigurationService _companyConfigurationService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyConfigurationController> _logger;

        public CompanyConfigurationController(ICompanyConfigurationService companyConfigurationService, IMapper mapper,
                                                    ILogger<CompanyConfigurationController> logger)
        {
            _companyConfigurationService = companyConfigurationService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("GetAllCompanyConfiguration")]
        public async Task<ActionResult<IEnumerable<CompanyConfigrationResponseDto>>> GetAllCompanyConfiguration([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting CompanyConfiguration Details...");
                var master = await _companyConfigurationService.GetAllCompanyConfiguration(pagingParam);
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpGet("GetCompanyConfiguration/{id}")]
        public async Task<ActionResult<CompanyConfigration>> GetCompanyConfiguration(int id)
        {
            try
            {
                _logger.LogInformation("Get CompanyConfigurationById Details....");
                var master = await _companyConfigurationService.GetCompanyConfigurationId(id);
                if (master == null)
                {
                    return NotFound("CompanyConfiguration not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPost("AddCompanyConfiguration")]
        public async Task<ActionResult<CompanyConfigration>> AddCompanyConfiguration(CompanyConfigurationDto companyMaster)
        {
            try
            {
                _logger.LogInformation("Add CompanyConfiguration Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyConfigration>(companyMaster);
                await _companyConfigurationService.AddCompanyConfiguration(result);
                return Ok("Add CompanyConfiguration Successfully..");
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                if (innerMessage.Contains("UNIQUE") || innerMessage.Contains("duplicate"))
                {
                    _logger.LogError(ex, "Error already exists adding company.");
                    return Conflict("Duplicate Record Found");
                }
                else
                    throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateCompanyConfiguration/{id}")]
        public async Task<ActionResult> UpdateCompanyConfiguration(int id, CompanyConfigurationDto companyMaster)
        {
            try
            {
                _logger.LogInformation("Update CompanyConfiguration Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyConfigration>(companyMaster);
                result.CompanyConfigId = id;
                await _companyConfigurationService.UpdateCompanyConfiguration(result);
                return Ok("Update CompanyConfiguration Successfully");
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                if (innerMessage.Contains("UNIQUE") || innerMessage.Contains("duplicate"))
                {
                    _logger.LogError(ex, "Error already exists adding company.");
                    return Conflict("Duplicate Record Found");
                }
                else
                    throw;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

        [HttpDelete("DeleteCompanyConfiguration/{companyConfigId}")]
        public async Task<ActionResult> DeleteCompanyConfiguration(int companyConfigId)
        {
            try
            {
                _logger.LogInformation("Delete CompanyConfiguration Details....");
                await _companyConfigurationService.DeleteCompanyConfiguration(companyConfigId);
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
