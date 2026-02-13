using RFQ.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ.Application.Helper
{
    public static class UserIdentityContext
    {
        private static ICurrentUserService? _currentUserService;

        public static void Initialize(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public static string? Email => _currentUserService?.Email;
        public static int? UserId => _currentUserService?.UserId;
        public static int? CompanyId => _currentUserService?.CompanyId;
        public static int? ProfileId => _currentUserService?.ProfileId;
        public static int? LocationId => _currentUserService?.LocationId;
        public static string? PersonName => _currentUserService?.PersonName;
    }
}
