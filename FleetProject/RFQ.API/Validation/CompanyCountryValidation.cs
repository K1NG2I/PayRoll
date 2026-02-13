using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyCountryValidation : AbstractValidator<CompanyCountryDto>
    {
        public CompanyCountryValidation()
        {
            RuleFor(company => company.Code).NotEmpty().WithMessage("Code is required.");
            RuleFor(company => company.CountryName).NotEmpty().WithMessage("CountryName is required");
            RuleFor(company => company.CreatedBy).NotEmpty().WithMessage("CreatedBy is required.");
            RuleFor(company => company.UpdatedBy).NotEmpty().WithMessage("UpdateBy is required.");
        }
    }
}
