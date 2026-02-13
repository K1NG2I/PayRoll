using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyMasterConfigrationValidation : AbstractValidator<CompanyConfigurationDto>
    {
        public CompanyMasterConfigrationValidation()
        {
            RuleFor(company => company.CompanyId).NotEmpty().WithMessage("CompanyId is required."); 
        }
    }
}
