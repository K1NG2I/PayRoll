using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyUserController : ControllerBase
    {
        private readonly ICompanyUserService _companyUserService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyUserController> _logger;

        public CompanyUserController(ICompanyUserService companyUserService, IMapper mapper, ILogger<CompanyUserController> logger)
        {
            _companyUserService = companyUserService;
            _mapper = mapper;
            _logger = logger;
        }

        //CompanyUser

        [HttpPost("GetUserAll")]
        public async Task<ActionResult> GetUserAll([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting User Details....");
                var result = await _companyUserService.GetAllUser(pagingParam);
                if (result == null)
                {
                    NotFound("User list unavailable");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<CompanyUser>> GetUserById(int id)
        {
            try
            {
                _logger.LogInformation("Get UserById Details....");
                var user = await _companyUserService.GetUserById(id);
                if (user == null || user.StatusId == (int)EStatus.Deleted)
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

        [HttpPost("AddUser")]
        public async Task<ActionResult<CompanyUser>> AddUser(CompanyUserDto user)
        {
            try
            {
                _logger.LogInformation("Add User Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyUser>(user);
                await _companyUserService.AddUser(result);
                return Ok("Add User Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult> UpdateUser(int id, CompanyUserDto user)
        {
            try
            {
                _logger.LogInformation("Update User Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyUser>(user);
                result.UserId = id;
                await _companyUserService.UpdateUser(result);
                return Ok("Update User Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Delete User Details....");
                await _companyUserService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("UpdateUserPassword")]
        public async Task<ActionResult> UpdateUserPassword(UpdateUserPasswordDto user)
        {
            try
            {
                _logger.LogInformation("Update UpdateUserPassword....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<UpdateUserPasswordDto>(user);
                bool check = await _companyUserService.UpdateUserPassWord(result);
                return Ok(check);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetByLoginIdAsync/{id}")]
        public async Task<ActionResult<CompanyUser>> GetByLoginIdAsync(string id)
        {
            try
            {
                _logger.LogInformation("Get GetByLoginIdAsync Details....");
                var user = await _companyUserService.GetByLoginIdAsync(id);
                if (user == null || user.StatusId == (int)EStatus.Deleted)
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
    }
}
