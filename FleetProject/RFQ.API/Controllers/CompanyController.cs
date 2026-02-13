using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetCompanyById/{companyId}")]
        public async Task<ActionResult<Company>> GetCompanyById(int companyId)
        {
            try
            {
                _logger.LogInformation("Get CompanyById Details....");
                var company = await _companyService.GetCompanyById(companyId);
                if (company == null || company.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("Company not Found");
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPost("GetAllCompany")]
        public async Task<ActionResult> GetAllCompany([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Get All Company Details....");
                var company = await _companyService.GetAllCompany(pagingParam);
                if (company == null)
                {
                    NotFound("Company unavailable");
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("GetAllFranchise")]
        public async Task<ActionResult> GetAllFranchise([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllFranchise Details...");
                var result = await _companyService.GetAllFranchise(pagingParam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllCompanyAndFranchise")]
        public async Task<ActionResult> GetAllCompanyAndFranchise()
        {
            try
            {
                _logger.LogInformation("Requesting GetAllCompanyAndFranchise Details...");
                var result = await _companyService.GetAllCompanyAndFranchise();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddCompany")]
        public async Task<ActionResult<Company>> AddCompany([FromBody] CompanyDto company)
        {
            try
            {
                _logger.LogInformation("Add Company Details....");
                var companyRequest = _mapper.Map<Company>(company);
                var result = await _companyService.AddCompany(companyRequest);
                return Ok(result);
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                if (innerMessage.Contains("UNIQUE") || innerMessage.Contains("duplicate"))
                {
                    _logger.LogError(ex, "Error already exists adding company.");
                    return Conflict($"{company.CompanyName} already exists.");
                }
                else
                    throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding company.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("UpdateCompany/{id}")]
        public async Task<ActionResult> UpdateCompany(int id, CompanyDto company)
        {
            try
            {
                _logger.LogInformation("Update Company Details....");
                if (company == null)
                {
                    return BadRequest();
                }
                var result = _mapper.Map<Company>(company);
                result.CompanyId = id;
                await _companyService.UpdateCompany(id, result);
                return Ok("Update Company Successfully");
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                if (innerMessage.Contains("UNIQUE") || innerMessage.Contains("duplicate"))
                {
                    _logger.LogError(ex, "Error already exists adding company.");
                    return Conflict($"{company.CompanyName} already exists.");
                }
                else
                    throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("DeleteCompany/{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            try
            {
                _logger.LogInformation("Delete Company Details....");
                await _companyService.DeleteCompany(id);
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
