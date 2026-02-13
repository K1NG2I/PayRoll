using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyMasterPackingTypeValidation : AbstractValidator<CompanyMasterPackingTypeDto>
    {
        public CompanyMasterPackingTypeValidation()
        {
            RuleFor(company => company.PackingName).NotEmpty().WithMessage("PackingName is required.");
            RuleFor(company => company.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
