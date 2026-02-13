using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Domain.Enums;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;
using RFQ.Domain.ResponseDto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICompanyUserService _companyUserService;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<LoginController> _logger;
        private readonly LinkItemContextHelper _linkItemContextHelper;
        public LoginController(IConfiguration config, ICompanyUserService companyUserService, IMapper mapper
            , IPasswordHasher passwordHasher, ILogger<LoginController> logger, LinkItemContextHelper linkItemContextHelper)
        {
            _config = config;
            _companyUserService = companyUserService;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _logger = logger;
            _linkItemContextHelper = linkItemContextHelper;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var message = ModelState.SelectMany(ModelState => ModelState.Value.Errors).Select(err => err.ErrorMessage).ToList();
                    return BadRequest(message);
                }

                IActionResult response = Unauthorized();
                var userResponse = await AuthenticateUser(login);
                if (userResponse.Data != null && userResponse.StatusCode == (int)EStatus.Deleted)
                {
                    var user = (CompanyUser)userResponse.Data; // cast back to user
                    var tokenString = await GenerateJSONWebToken(user);
                    userResponse.Data = tokenString;
                }
                return Ok(userResponse);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.StackTrace, "An error occurred while processing the login request.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        private async Task<string> GenerateJSONWebToken(CompanyUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("email", user.EmailId),
                new Claim("profileid",user.ProfileId.ToString()),
                new Claim("companyid",user.CompanyId.ToString()),
                new Claim("personname" ,user.PersonName),
                new Claim("userid" ,user.UserId.ToString()),
                new Claim("locationid",user.LocationId.ToString())
            };
            await _linkItemContextHelper.GetCurrentProfileLinksAsync(null);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddHours(12),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<CommanResponseDto> AuthenticateUser(LoginDto login)
        {
            var result = _mapper.Map<CompanyUser>(login);
            return await _companyUserService.GetAuthentication(result.LoginId, result.Password);
        }
    }
}
