using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class CompanyMasterItemValidation : AbstractValidator<CompanyMasterItemDto>
    {
        public CompanyMasterItemValidation()
        {
            RuleFor(company => company.ItemName).NotEmpty().WithMessage("ItemName is required.");
            RuleFor(company => company.CompanyId).NotEmpty().WithMessage("CompanyId is required.");
            RuleFor(company => company.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(company => company.CreatedBy).NotEmpty().WithMessage("CreatedBy is required.");
            RuleFor(company => company.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required.");
        }
    }
}
