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
    public class CompanyMasterPackingTypeController : ControllerBase
    {
        private readonly ICompanyMasterPackingTypeService _companyMasterPackingTypeService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyMasterPackingTypeController> _logger;

        public CompanyMasterPackingTypeController(ICompanyMasterPackingTypeService companyMasterPackingTypeService, IMapper mapper, ILogger<CompanyMasterPackingTypeController> logger)
        {
            _companyMasterPackingTypeService = companyMasterPackingTypeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetMasterPackingType")]
        public async Task<ActionResult<IEnumerable<CompanyMasterPackingType>>> GetMasterPackingTypeAll()
        {
            try
            {
                _logger.LogInformation("Get All Master Packing Type Details....");
                var user = await _companyMasterPackingTypeService.GetAllMasterPackingType();
                if (user == null)
                {
                    NotFound("MasterPackingType list unavailable");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterPackingTypeById/{id}")]
        public async Task<ActionResult<CompanyMasterPackingType>> GetMasterPackingTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterPackingTypeById Details....");
                var user = await _companyMasterPackingTypeService.GetMasterPackingTypeById(id);
                if (user == null)
                {
                    return NotFound("MasterPackingType not Found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddMasterPackingType")]
        public async Task<ActionResult<CompanyMasterPackingType>> AddMasterPackingType(CompanyMasterPackingTypeDto masterPackingType)
        {
            try
            {
                _logger.LogInformation("Add MasterPackingType Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyMasterPackingType>(masterPackingType);
                await _companyMasterPackingTypeService.AddMasterPackingType(result);
                return Ok("Add MasterPackingType Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateMasterPackingType/{id}")]
        public async Task<ActionResult> UpdateProfile(int id, CompanyMasterPackingTypeDto masterPackingType)
        {
            try
            {
                _logger.LogInformation("Update MasterPackingType Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyMasterPackingType>(masterPackingType);
                result.PackingId = id;
                await _companyMasterPackingTypeService.UpdatemasterPackingType(result);
                return Ok("Update MasterPackingType Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteMasterPackingType/{id}")]
        public async Task<ActionResult> DeleteMasterPackingType(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterPackingType Details....");
                await _companyMasterPackingTypeService.DeletemasterPackingType(id);
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
