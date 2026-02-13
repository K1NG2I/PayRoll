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
    public class RfqLinkController : ControllerBase
    {
        private readonly IRfqLinkService _rfqLinkService;
        private readonly IMapper _mapper;
        private readonly ILogger<RfqLinkController> _logger;
        public RfqLinkController(IRfqLinkService rfqLinkService,IMapper mapper,ILogger<RfqLinkController> logger)
        {
            _rfqLinkService = rfqLinkService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("AddRfqLink")]
        public async Task<IActionResult> AddRfqLink(List<RfqLinkDto> rfqLinkDtos)
        {
            try
            {
                _logger.LogInformation("Add Rfq Link Details....");
                if (rfqLinkDtos == null || !rfqLinkDtos.Any())
                {
                    return BadRequest("Rfq Links cannot be null or empty");
                }
                var rfqLinks = _mapper.Map<List<RfqLink>>(rfqLinkDtos);
                rfqLinkDtos.ForEach(link => link.CreatedOn = DateTime.Now);
                var result = await _rfqLinkService.AddRfqLink(rfqLinks);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding RFQ links");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
