using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LinkController : ControllerBase
    {

        private readonly ILinkItemService _linkItemService;
        private readonly IMapper _mapper;
        private readonly ILogger<LinkController> _logger;

        public LinkController(ILinkService linkService, ILinkItemService linkItemService, IMapper mapper,
                              ILogger<LinkController> logger)
        {

            _linkItemService = linkItemService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllLinkItem")]
        public async Task<ActionResult<IEnumerable<LinkItem>>> GetAllLinkItem()
        {
            try
            {
                _logger.LogInformation("Requesting LinkItem Details...");
                var links = await _linkItemService.GetAllLinkItem();
                return Ok(links);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GetAllLinkItem");
                return StatusCode(500, new { message = "An error occurred while fetching link items." });
            }
        }

        [HttpGet("GetLinkItemById/{id}")]
        public async Task<ActionResult<LinkItem>> GetLinkItemById(int id)
        {
            try
            {
                _logger.LogInformation("Reqest for LinkItemById....");
                var item = await _linkItemService.GetLinkItemById(id);
                if (item == null || item.StatusId == (int)EStatus.Deleted)
                {
                    return NotFound("LinkId Not Found");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                _logger.LogInformation("Error Occured");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddLinkItem")]
        public async Task<ActionResult> AddLinkItem(LinkItemRequestDto link)
        {
            try
            {
                _logger.LogInformation("Reqest for AddLinkItem....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<LinkItem>(link);
                await _linkItemService.AddLinkItem(result);
                return Ok("Add Link Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateLinkItem/{id}")]
        public async Task<ActionResult> UpdateLinkItem(int id, [FromBody] LinkItemRequestDto link)
        {
            try
            {
                _logger.LogInformation("Reqest for UpdateLinkItem....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<LinkItem>(link);
                result.LinkId = id;
                await _linkItemService.UpdateLinkItem(result);
                return Ok("Update Item SuccessFully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteLinkItemById/{id}")]
        public async Task<ActionResult> DeleteLinkItem(int id)
        {
            try
            {
                _logger.LogInformation("Reqest for DeleteLinkItem....");
                await _linkItemService.DeleteLinkItem(id);
                return Ok("Delete Item SuccessFully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetLinkItemList")]
        public async Task<ActionResult<IEnumerable<LinkItemListResponseDto>>> GetLinkItemList()
        {
            try
            {
                _logger.LogInformation("Requesting LinkItem Details...");

                var links = await _linkItemService.GetLinkItemList();
                return Ok(links);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GetAllLinkItem");
                return StatusCode(500, new { message = "An error occurred while fetching link items." });
            }
        }
    }
}
