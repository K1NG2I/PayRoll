using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyUserValidation : AbstractValidator<CompanyUserDto>
    {
        public CompanyUserValidation()
        {
            RuleFor(user => user.CompanyId).NotEmpty().WithMessage("CompanyId is required.");
            //RuleFor(user => user.ProfileId).NotEmpty().WithMessage("PersonId is required.");
            //RuleFor(user => user.PersonName).NotEmpty().WithMessage("PersonName is required.");
            RuleFor(user => user.LoginId).NotEmpty().WithMessage("LoginId is required");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required.");
            //RuleFor(user => user.MobileNo).NotEmpty().WithMessage("MobileNo is required.").Length(10).WithMessage("Please Enter Valid Number");
            RuleFor(user => user.CreatedBy).NotEmpty().WithMessage("CreatedBy is required.");
            RuleFor(user => user.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required.");
        }
    }
}
