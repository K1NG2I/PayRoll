using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class DeliveryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeliveryController> _logger;
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IMapper mapper, ILogger<DeliveryController> logger, IDeliveryService deliveryService)
        {
            _mapper = mapper;
            _logger = logger;
            _deliveryService = deliveryService;
        }

        [HttpPost("AddDelivery")]
        public async Task<ActionResult> AddDelivery([FromBody] DeliveryRequestDto deliveryRequestDto)
        {
            try
            {
                _logger.LogInformation("Add Delivery Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var delivery = _mapper.Map<Delivery>(deliveryRequestDto);
                var result = await _deliveryService.AddDelivery(delivery);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GenerateDocumentNo")]
        public async Task<ActionResult> GenerateDocumentNo()
        {
            try
            {
                var nextDocumentNo = await _deliveryService.GenerateDocumentNo();
                if (nextDocumentNo == null)
                {
                    return NotFound("nextDocumentNo  was not found.");
                }
                return Ok(nextDocumentNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating the LR Number.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("GetAllDelivery")]
        public async Task<ActionResult> GetAllDelivery([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Get All Delivery Details....");
                var indent = await _deliveryService.GetAllDelivery(pagingParam);
                if (indent == null)
                {
                    NotFound("Delivery unavailable");
                }
                return Ok(indent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetDeliveryById/{id}")]
        public async Task<ActionResult<Delivery>> GetDeliveryById(int id)
        {
            try
            {
                _logger.LogInformation("Get BookingOrTripById Details....");
                var deliveryById = await _deliveryService.GetDeliveryById(id);
                if (deliveryById == null || deliveryById.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("DeliveryById not Found");
                }
                return Ok(deliveryById);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }

        }

        [HttpPut("UpdateDelivery/{id}")]
        public async Task<ActionResult> UpdateDelivery(int id, DeliveryRequestDto deliveryRequestDto)
        {
            try
            {
                _logger.LogInformation("Update Delivery Details....");
                if (deliveryRequestDto == null)
                {
                    return BadRequest();
                }
                var result = _mapper.Map<Delivery>(deliveryRequestDto);
                result.BookingId = id;
                await _deliveryService.UpdateDelivery(result);
                return Ok("Update Delivery Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpDelete("DeleteDelivery/{id}")]
        public async Task<ActionResult> DeleteDelivery(int id)
        {
            try
            {
                _logger.LogInformation("Delete Delivery Details....");
                await _deliveryService.DeleteDelivery(id);
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
