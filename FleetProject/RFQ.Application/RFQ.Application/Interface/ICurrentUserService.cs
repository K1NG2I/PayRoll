using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Interface
{
    public interface ICurrentUserService
    {
        string? Email { get; }
        int? ProfileId { get; }
        int? CompanyId { get; }
        string? PersonName { get; }
        int? UserId { get; }
        int? LocationId { get; }

        IEnumerable<Claim>? Claims { get; }
        string? GetClaimValue(string claimType);
    }
}
