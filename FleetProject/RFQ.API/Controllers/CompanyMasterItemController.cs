using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Application.Provider;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using Microsoft.EntityFrameworkCore;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyMasterItemController : ControllerBase
    {
        private readonly ICompanyMasterItemService _companyMasterItemService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyMasterItemController> _logger;

        public CompanyMasterItemController(ICompanyMasterItemService companyMasterItemService,
                                          IMapper mapper, ILogger<CompanyMasterItemController> logger)
        {
            _companyMasterItemService = companyMasterItemService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("GetAllMasterItem")]
        public async Task<ActionResult<IEnumerable<CompanyMasterItemResponseDto>>> GetAllMasterItem([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting CompanyMasterItem Details...");
                var master = await _companyMasterItemService.GetAllMasterItem(pagingParam);
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterItemById/{id}")]
        public async Task<ActionResult<CompanyMasterItem>> GetMasterItemById(int id)
        {
            try
            {
                _logger.LogInformation("Get GetMasterItemById Details....");
                var master = await _companyMasterItemService.GetMasterItemById(id);
                if (master == null || master.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("GetMasterItem not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }


        [HttpPost("AddMasterItem")]
        public async Task<ActionResult> AddMasterItem(CompanyMasterItemDto masterItem)
        {
            try
            {
                _logger.LogInformation("Add MasterType Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyMasterItem>(masterItem);
                var response = await _companyMasterItemService.AddMasterItem(result);
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
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateCompanyMasterItem/{id}")]
        public async Task<ActionResult> UpdateCompanyMasterItem(int id, CompanyMasterItemDto masterItem)
        {
            try
            {
                _logger.LogInformation("Update CompanyMasterItem Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<CompanyMasterItem>(masterItem);
                result.ItemId = id;
                await _companyMasterItemService.UpdateMasterItem(result);
                return Ok("Update Item Successfully");
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                if (innerMessage.Contains("UNIQUE") || innerMessage.Contains("duplicate"))
                {
                    _logger.LogError(ex, "Error already exists adding Item.");
                    return Conflict("Item already exists");
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

        [HttpDelete("DeleteCompanyMasterItem/{id}")]
        public async Task<ActionResult> DeleteCompanyMasterItem(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterType Details....");
                await _companyMasterItemService.DeleteMasterItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }


        [HttpGet("GetDrpProductList")]
        public async Task<ActionResult> GetDrpProductList([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Get GetDrpProductList Details....");
                var ProductList = await _companyMasterItemService.GetDrpProductList(companyId);
                if (ProductList == null)
                {
                    return NotFound("GetDrpProductList not Found");
                }
                return Ok(ProductList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
