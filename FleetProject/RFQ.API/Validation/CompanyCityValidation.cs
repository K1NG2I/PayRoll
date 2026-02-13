using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyCityValidation : AbstractValidator<CompanyCityDto>
    {
        public CompanyCityValidation()
        {
            RuleFor(company => company.Code).NotEmpty().WithMessage("Code is required.");
            RuleFor(company => company.CityName).NotEmpty().WithMessage("CityName is required");
            RuleFor(company => company.StateId).NotEmpty().WithMessage("StateId is required");
            RuleFor(company => company.CreatedBy).NotEmpty().WithMessage("CreatedBy is required");
            RuleFor(company => company.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required");
        }
    }
}
