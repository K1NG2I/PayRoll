using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RFQ.Infrastructure.Efcore;
using System.Threading.Tasks;

namespace RFQ.Web.API.Controllers
{
    [Route("/simple-login")]
    public class SimpleLoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly FleetLynkDbContext _context;

        public SimpleLoginController(IConfiguration configuration, FleetLynkDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var html = @"<!doctype html>
<html>
  <head>
    <meta charset='utf-8'>
    <title>Simple Login</title>
  </head>
  <body>
    <h2>Simple Login</h2>
    <form method='post' action='/simple-login'>
      <label>Username: <input name='username' /></label><br/>
      <label>Password: <input name='password' type='password' /></label><br/>
      <button type='submit'>Login</button>
    </form>
  </body>
</html>";
            return Content(html, "text/html");
        }

        [HttpPost]
        public async Task<IActionResult> IndexPost([FromForm] string username, [FromForm] string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return Content("Username and password are required.");
            }

            // Check against com_mst_user table (CompanyUser entity)
            var user = await _context.company_user
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.LoginId == username && u.Password == password);

            if (user != null)
            {
                return Content($"Login successful for user: {username}");
            }

            return Content("Invalid username or password");
        }
    }
}
