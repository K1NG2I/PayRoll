using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyProfileRightValidation : AbstractValidator<CompanyProfileRightDto>
    {
        public CompanyProfileRightValidation()
        {
            RuleFor(company => company.ProfileId).NotEmpty().WithMessage("ProfileId is required.");
            RuleFor(company => company.LinkId).NotEmpty().WithMessage("LinkId is required.");
            RuleFor(company => company.IsAdd).NotEmpty().WithMessage("IsAdd is required.");
            RuleFor(company => company.IsEdit).NotEmpty().WithMessage("IsEdit is required.");
            RuleFor(company => company.IsView).NotEmpty().WithMessage("IsView is required.");
            RuleFor(company => company.IsCancel).NotEmpty().WithMessage("IsCancel is required.");
        }
    }
}
