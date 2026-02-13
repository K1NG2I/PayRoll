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
    public class CompanyProfileRightController : ControllerBase
    {
        private readonly ICompanyProfileRightService _companyProfileRightService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyProfileController> _logger;

        public CompanyProfileRightController(ICompanyProfileRightService companyProfileRightService, IMapper mapper, ILogger<CompanyProfileController> logger)
        {
            _companyProfileRightService = companyProfileRightService;
            _mapper = mapper;
            _logger = logger;
        }

        //CompanyProfileRights

        [HttpGet("GetProfileRightsAll")]
        public async Task<ActionResult<IEnumerable<CompanyProfileRight>>> GetProfileRightsAll()
        {
            try
            {
                _logger.LogInformation("Get ProfileRights Details....");
                var rights = await _companyProfileRightService.GetAllProfileRight();
                if (rights == null)
                {
                    NotFound("ProfileRights unavailable");
                }
                return Ok(rights);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetProfileRightsById/{id}")]
        public async Task<ActionResult<CompanyProfileRight>> GetProfileRightsById(int id)
        {
            try
            {
                _logger.LogInformation("Get ProfileRightsById Details....");
                var rights = await _companyProfileRightService.GetProfileRightsById(id);
                if (rights == null)
                {
                    return NotFound("ProfileRights not Found");
                }
                return Ok(rights);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddProfileRights")]
        public async Task<ActionResult<CompanyProfileRight>> AddProfileRights(CompanyProfileRightDto profile)
        {
            try
            {
                _logger.LogInformation("Add ProfileRights Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyProfileRight>(profile);
                await _companyProfileRightService.AddProfileRight(result);
                return Ok("Add Profile Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateProfileRights/{id}")]
        public async Task<ActionResult> UpdateProfileRights(int id, CompanyProfileRightDto Profile)
        {
            _logger.LogInformation("Update ProfileRights Details....");
            if (!ModelState.IsValid)
            {
                var messages = ModelState
                  .SelectMany(modelState => modelState.Value.Errors)
                  .Select(err => err.ErrorMessage)
                  .ToList();

                return BadRequest(messages);
            }
            var result = _mapper.Map<CompanyProfileRight>(Profile);
            result.UserProfileRightId = id;
            await _companyProfileRightService.UpdateProfileRights(result);
            return Ok("Update ProfileRights Successfully");
        }

        //[HttpPut("DeleteProfileRights/{id}")]
        //public async Task<ActionResult> DeleteProfileRights(int id)
        //{
        //    _logger.LogInformation("Delete Profile Details....");
        //    await _companyProfileRightService.DeleteProfileRights(id);
        //    return Ok();
        //}

        [HttpGet("GetProfileRightsByProfileId/{profileId}")]
        public async Task<ActionResult<IEnumerable<CompanyProfileRight>>> GetProfileRightsByProfileId(int profileId)
        {
            try
            {
                _logger.LogInformation("Get ProfileRights Details....");
                var rights = await _companyProfileRightService.GetProfileRightsByProfileId(profileId);
                if (rights == null)
                {
                    NotFound("ProfileRights unavailable");
                }
                return Ok(rights);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddOrUpdateProfileRights")]
        public async Task<ActionResult<bool>> AddOrUpdateProfileRights(List<CompanyProfileRightRequestDto> profileList)
        {
            try
            {
                _logger.LogInformation("Add Or Update ProfileRights Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var res = await _companyProfileRightService.AddOrUpdateProfileRights(profileList);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
