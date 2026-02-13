using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyProfileController : ControllerBase
    {
        private readonly ICompanyProfileService _companyProfileService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyProfileController> _logger;

        public CompanyProfileController(ICompanyProfileService companyProfileService, IMapper mapper, ILogger<CompanyProfileController> logger)
        {
            _companyProfileService = companyProfileService;
            _mapper = mapper;
            _logger = logger;
        }

        //CompanyProfile 
        [HttpGet("GetProfileAll")]
        public async Task<ActionResult<IEnumerable<CompanyProfile>>> GetProfileAll()
        {
            try
            {
                _logger.LogInformation("Get All Profile Details....");
                var user = await _companyProfileService.GetAllProfile();
                if (user == null)
                {
                    NotFound("Profile list unavailable");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetProfileById/{id}")]
        public async Task<ActionResult<CompanyProfile>> GetProfileById(int id)
        {
            try
            {
                _logger.LogInformation("Get ProfileById Details....");
                var user = await _companyProfileService.GetProfileById(id);
                if (user == null)
                {
                    return NotFound("User not Found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddProfile")]
        public async Task<ActionResult<CompanyProfile>> AddProfile(CompanyProfileDto Profile)
        {
            try
            {
                _logger.LogInformation("Add Profile Details....");
                var result = _mapper.Map<CompanyProfile>(Profile);
                await _companyProfileService.AddProfile(result);
                return Ok("Add Profile Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateProfile/{id}")]
        public async Task<ActionResult> UpdateProfile(int id, CompanyProfileDto user)
        {
            try
            {
                _logger.LogInformation("Update Profile Details....");
                if (user == null)
                {
                    return BadRequest();
                }
                var result = _mapper.Map<CompanyProfile>(user);
                result.ProfileId = id;
                await _companyProfileService.UpdateProfile(result);
                return Ok("Update Profile Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpDelete("DeleteProfile/{profileId}")]
        public async Task<ActionResult> DeleteProfile(int profileId)
        {
            try
            {
                _logger.LogInformation("Delete Profile Details....");
                await _companyProfileService.DeleteProfile(profileId);
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
