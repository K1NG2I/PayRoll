using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using RFQ.Infrastructure.Efcore;

namespace RFQ.Web.API.Filter
{
    public class AuthenticationFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _rights;

        public AuthenticationFilter(string rights)
        {
            _rights = rights;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user != null && !user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var profileIdClaims = user.Claims.FirstOrDefault(c => c.Type == "profileid")?.Value;
            if (string.IsNullOrEmpty(profileIdClaims) || !int.TryParse(profileIdClaims, out var profileId))
            {
                context.Result = new ForbidResult();
                return;
            }

            var dbContext = context.HttpContext.RequestServices.GetService<FleetLynkDbContext>();

            var profileRight = await dbContext.companyProfileRights.FirstOrDefaultAsync(x => x.ProfileId == profileId);

            if (profileRight == null)
            {
                context.Result = new NotFoundResult();
                return;
            }

            var hasPermission = _rights switch
            {
                "IsAdd" => profileRight.IsAdd,
                "IsEdit" => profileRight.IsEdit,
                "IsView" => profileRight.IsView,
                "IsCancel" => profileRight.IsCancel,
                _ => false
            };

            if (!hasPermission)
            {
                context.Result = new UnauthorizedResult();

            }
        }
    }
}
