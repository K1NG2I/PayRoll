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
    public class CompanyStateController : ControllerBase
    {
        private readonly ICompanyStateService _companyStateService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyStateController> _logger;

        public CompanyStateController(ICompanyStateService companyStateService, IMapper mapper, ILogger<CompanyStateController> logger)
        {
            _companyStateService = companyStateService;
            _mapper = mapper;
            _logger = logger;
        }

        //CompanyState

        [HttpGet("GetStateById/{id}")]
        public async Task<ActionResult<CompanyState>> GetStateById(int id)
        {
            try
            {
                _logger.LogInformation("Get StateById Details....");
                var state = await _companyStateService.GetStateById(id);
                if (state == null || state.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("State not Found");
                }
                return Ok(state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllState")]
        public async Task<ActionResult<IEnumerable<CompanyState>>> GetAllState()
        {
            try
            {
                _logger.LogInformation("Get All State Details....");
                var states = await _companyStateService.GetAllState();
                if (states == null)
                {
                    NotFound("State unavailable");
                }
                return Ok(states);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddState")]
        public async Task<ActionResult<CompanyState>> AddState(CompanyStateDto state)
        {
            try
            {
                _logger.LogInformation("Add State Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyState>(state);
                await _companyStateService.AddState(result);
                return Ok("Add State Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateState/{id}")]
        public async Task<ActionResult> UpdateState(int id, CompanyStateDto state)
        {
            try
            {
                _logger.LogInformation("Update State Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyState>(state);
                result.StateId = id;
                await _companyStateService.UpdateState(result);
                return Ok("Update State Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteState/{id}")]
        public async Task<ActionResult> DeleteState(int id)
        {
            try
            {
                _logger.LogInformation("Delete State Details....");
                await _companyStateService.DeleteState(id);
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
