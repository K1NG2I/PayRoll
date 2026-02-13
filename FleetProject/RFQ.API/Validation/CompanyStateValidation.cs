using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyStateValidation : AbstractValidator<CompanyStateDto>
    {
        public CompanyStateValidation()
        {
            RuleFor(company => company.Code).NotEmpty().WithMessage("CompanyCode is required.");
            RuleFor(company => company.StateName).NotEmpty().WithMessage("StateName is required.");
            RuleFor(company => company.CountryId).NotEmpty().WithMessage("Country is required.");
            RuleFor(company => company.NsdlCode).NotEmpty().WithMessage("NsdlCode is required.");
            RuleFor(company => company.CreatedBy).NotEmpty().WithMessage("CreatedBy is required.");
            RuleFor(company => company.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required.");
        }
    }
}
