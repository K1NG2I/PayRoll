using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class LoginValidation : AbstractValidator<LoginDto>
    {
        public LoginValidation()
        {
            RuleFor(login => login.LoginId).NotEmpty().WithMessage("LoginId is required.");
            RuleFor(login => login.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}
