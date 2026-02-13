using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.RequestDto;
using System.Threading.Tasks;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommonService _commonService;
        private readonly ILogger<CommonController> _logger;
        
        public CommonController(IMapper mapper, ILogger<CommonController> logger, ICommonService commonService)
        {
            _mapper = mapper;
            _logger = logger;
            _commonService = commonService;
        }

        [HttpPost("GetAutoGenerateCode")]
        public async Task<IActionResult> GetAutoGenerateCode(AutoGenerateCodeRequestDto requestDto)
        {
            try
            {
                var result =await _commonService.GetAutoGenerateCode(requestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
