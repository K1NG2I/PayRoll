using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
using RFQ.Domain.Enums;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MasterPartyController : ControllerBase
    {
        private readonly IMasterPartyService _masterPartyService;
        private readonly IMapper _mapper;
        private readonly ILogger<MasterPartyController> _logger;
        private readonly IInternalMasterService _internalMasterService;
        public MasterPartyController(IMasterPartyService masterPartyService, IMapper mapper, ILogger<MasterPartyController> logger, IInternalMasterService internalMasterService)
        {
            _masterPartyService = masterPartyService;
            _mapper = mapper;
            _logger = logger;
            _internalMasterService = internalMasterService;

        }

        [HttpPost("GetAllCustomer")]
        public async Task<ActionResult> GetAllCustomer([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllCustomer Details...");
                var result = await _masterPartyService.GetAllCustomer(pagingParam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("GetAllVendor")]
        public async Task<ActionResult> GetAllVendor([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllVendor Details...");
                var result = await _masterPartyService.GetAllVendor(pagingParam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterParty/{id}")]
        public async Task<ActionResult<MasterParty>> GetMasterPartyById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterParty Details....");
                var master = await _masterPartyService.GetMasterPartyById(id);
                if (master == null || master.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("MasterParty not Found");
                }
                return Ok(master);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddMasterParty")]
        public async Task<ActionResult> AddMasterParty([FromBody] MasterPartyDto masterParty)
        {
            try
            {
                _logger.LogInformation("Add MasterParty Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var partyRequest = _mapper.Map<MasterParty>(masterParty);
                var vendorVehicleTypeRequest = _mapper.Map<List<MasterPartyVehicleType>>(masterParty.VendorVehicleTypes);
                var vendorRouteRequest = _mapper.Map<List<MasterPartyRoute>>(masterParty.VendorApplicableRoutes);
                var result = await _masterPartyService.AddMasterParty(partyRequest, vendorVehicleTypeRequest, vendorRouteRequest);
                return Ok(result);
            }
            catch (DbUpdateException dbEx) when (
        dbEx.InnerException?.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase) == true ||
        dbEx.InnerException?.Message.Contains("duplicate", StringComparison.OrdinalIgnoreCase) == true)
            {
                _logger.LogError(dbEx, "Duplicate record found. Party details already exist.");
                return Conflict(new CommanResponseDto
                {
                    Data = null,
                    Message = "Duplicate record found. Party details already exist.",
                    StatusCode = 409
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while adding MasterParty");
                return StatusCode(500, new CommanResponseDto
                {
                    Data = null,
                    Message = "Unexpected error while adding MasterParty",
                    StatusCode = 500
                });
            }
        }

        [HttpPut("UpdateMasterParty/{id}")]
        public async Task<ActionResult> UpdateMasterParty(int id, MasterPartyDto masterParty)
        {
            try
            {
                _logger.LogInformation("Update masterParty Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var partyUpadateRequest = _mapper.Map<MasterParty>(masterParty);
                partyUpadateRequest.PartyId = id;
                var vendorVehicleTypeUpdateRequest = _mapper.Map<List<MasterPartyVehicleType>>(masterParty.VendorVehicleTypes);
                var vendorRouteUpdateRequest = _mapper.Map<List<MasterPartyRoute>>(masterParty.VendorApplicableRoutes);
                var result = await _masterPartyService.UpdateMasterParty(partyUpadateRequest, vendorVehicleTypeUpdateRequest, vendorRouteUpdateRequest);
                if (result == null)
                    throw new Exception("MasterParty not found");
                else
                    return Ok("Update MasterParty Successfully");
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                if (innerMessage.Contains("UNIQUE") || innerMessage.Contains("duplicate"))
                {
                    _logger.LogError(ex, "Error already exists adding company.");
                    return Conflict($" masterParty already exists.");
                }
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeleteMasterParty/{id}")]
        public async Task<ActionResult> DeleteMasterParty(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterParty Details....");
                await _masterPartyService.DeleteMasterParty(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAllInternalMaster")]
        public async Task<ActionResult<IEnumerable<InternalMaster>>> GetAllInternalMaster()
        {
            try
            {
                _logger.LogInformation("Get All Internal Master");
                var internalMaster = await _internalMasterService.GetAllInternalMaster();
                if (internalMaster == null)
                {
                    return NotFound("Internal Master Not Found");
                }
                return Ok(internalMaster);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetDrpCustomerList")]
        public async Task<ActionResult> GetDrpCustomerList([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Requesting GetDrpCustomerList Details...");
                var result = await _masterPartyService.GetDrpCustomerList(companyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }


        [HttpGet("GetAllVendorList")]
        public async Task<ActionResult> GetAllVendorList([FromQuery] int companyId)
        {
            try
            {
                _logger.LogInformation("Requesting GetAllVendorList Details...");
                var result = await _masterPartyService.GetAllVendorList(companyId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetAutoCustomerCode/{UserId}")]
        public async Task<ActionResult> GetAutoCustomerCode(int UserId)
        {
            try
            {
                _logger.LogInformation("Requesting GetAutoCustomerCode Details...");
                var result = await _masterPartyService.GetAutoCustomerCode(UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}

