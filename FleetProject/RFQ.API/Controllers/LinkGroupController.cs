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
    public class LinkGroupController : ControllerBase
    {
        private readonly ILinkService _linkService;
        private readonly IMapper _mapper;
        private readonly ILogger<LinkGroupController> _logger;

        public LinkGroupController(ILinkService linkService, IMapper mapper, ILogger<LinkGroupController> logger)
        {
            _linkService = linkService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAllLinkGroup")]
        public async Task<ActionResult<IEnumerable<LinkGroup>>> GetAllLinkGroup()
        {
            try
            {
                _logger.LogInformation("Requesting LinkGroup Details...");
                var groups = await _linkService.GetAllLinkGroup();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetLinkGroupById/{id}")]
        public async Task<ActionResult<LinkGroup>> GetLinkGroupById(int id)
        {
            try
            {
                _logger.LogInformation("Reqest for GroupById....");
                var group = await _linkService.GetLinkGroupById(id);
                if (group == null)
                {
                    BadRequest();
                }
                return Ok(group);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddLinkGroup")]
        public async Task<ActionResult> AddLinkGroup(LinkGroupRequestDto link)
        {
            try
            {
                _logger.LogInformation("Reqest for AddLinkGroup....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<LinkGroup>(link);
                await _linkService.AddLinkGroup(result);
                return Ok("Add Group Successfully");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("UpdateLinkGroup/{id}")]
        public async Task<ActionResult> UpdateLinkGroup(int id, [FromBody] LinkGroupRequestDto link)
        {
            try
            {
                _logger.LogInformation("Reqest for UpdateLinkGroup....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<LinkGroup>(link);
                result.LinkGroupId = id;
                await _linkService.UpdateLinkGroup(result);
                return Ok("Update Group SuccessFully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteLinkGroupById/{id}")]
        public async Task<ActionResult> DeleteLinkGroup(int id)
        {
            try
            {
                _logger.LogInformation("Reqest for DeleteLinkGroup....");
                await _linkService.DeleteLinkGroup(id);
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
