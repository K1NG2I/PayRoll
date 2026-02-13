using Microsoft.AspNetCore.Http;
using RFQ.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Provider
{
    public class CurrentUserService : ICurrentUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public string? Email => GetClaimValue(ClaimTypes.Email) ?? GetClaimValue("email");
        public int? ProfileId => TryParseInt(GetClaimValue("profileid"));
        public int? CompanyId => TryParseInt(GetClaimValue("companyid"));
        public string? PersonName => GetClaimValue(ClaimTypes.Name) ?? GetClaimValue("personname");
        public int? UserId => TryParseInt(GetClaimValue("userid"));
        public int? LocationId => TryParseInt(GetClaimValue("locationid"));

        public IEnumerable<Claim>? Claims => User?.Claims;

        public string? GetClaimValue(string claimType)
        {
            return User?.FindFirst(claimType)?.Value;
        }

        private static int? TryParseInt(string? value)
        {
            return int.TryParse(value, out var result) ? result : (int?)null;
        }
    }
}
