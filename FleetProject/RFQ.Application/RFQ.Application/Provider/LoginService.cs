using RFQ.Application.Interface;
using RFQ.Domain.Interfaces;

namespace RFQ.Application.Provider
{
    public class LoginService : ILoginService
    {
        private readonly IloginRepository _loginRepository;

        public LoginService(IloginRepository iloginRepository)
        {
            _loginRepository = iloginRepository;
        }
    }
}
