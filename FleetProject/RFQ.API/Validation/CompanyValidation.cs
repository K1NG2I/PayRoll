using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyValidation : AbstractValidator<CompanyDto>
    {
        public CompanyValidation()
        {
            RuleFor(company => company.CompanyName).NotEmpty().WithMessage("CompanyName is required.");
            RuleFor(company => company.CompanyTypeId).NotEmpty().WithMessage("CompanyTypeId is required.");
            RuleFor(company => company.AddressLine).NotEmpty().WithMessage("AddressLine is required.");
            RuleFor(company => company.CityId).NotEmpty().WithMessage("CityId is required.");
            RuleFor(company => company.PinCode).NotEmpty().WithMessage("PinCode is required");
            RuleFor(company => company.WhatsAppNo).NotEmpty().Length(10).WithMessage("WhatsAppNo is required.");
            RuleFor(company => company.PANNo).NotEmpty().WithMessage("PANNo is required.");
            RuleFor(company => company.ParentCompanyId).NotEmpty().WithMessage("ParentCompanyId is required.");
            RuleFor(company => company.LinkId).NotEmpty().WithMessage("LinkId is required.");
            RuleFor(company => company.CreatedBy).NotEmpty().WithMessage("CreatedBy is required.");
            RuleFor(company => company.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required.");
        }
    }
}
