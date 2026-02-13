using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuListController : ControllerBase
    {
        private readonly IMenuListService _menuListService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyCityController> _logger;

        public MenuListController(IMenuListService menuListService, IMapper mapper, ILogger<CompanyCityController> logger)
        {
            _menuListService = menuListService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetMenu/{profileId}")]
        public async Task<ActionResult<IEnumerable<MenuListResponseDto>>> GetMenu(int profileId)
        {
            try
            {
                _logger.LogInformation("Get Menu Details....");
                var menu = await _menuListService.GetMenu(profileId);
                if (menu == null)
                {
                    NotFound("menu unavailable");
                }
                return Ok(menu);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
