using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyProfileValidation : AbstractValidator<CompanyProfileDto>
    {
        public CompanyProfileValidation()
        {
            RuleFor(company => company.ProfileName).NotEmpty().WithMessage("ProfileName is required.");
            RuleFor(company => company.CompanyTypeId).NotEmpty().WithMessage("CompanyTypeId is required.");
        }
    }
}
