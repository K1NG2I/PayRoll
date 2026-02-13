using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class RfqRateValidation : AbstractValidator<RfqRateDto>
    {
        public RfqRateValidation()
        {
            RuleFor(rfq => rfq.RfqId).NotEmpty().WithMessage("RfqDetailId is required.");
            RuleFor(rfq => rfq.VendorId).NotEmpty().WithMessage("VendorId is required.");
            RuleFor(rfq => rfq.TotalHireCost).NotEmpty().WithMessage("TotalHireCost is required.");
            RuleFor(rfq => rfq.DetentionPerDay).NotEmpty().WithMessage("DetentionPerDay is required.");
            RuleFor(rfq => rfq.DetentionFreeDays).NotEmpty().WithMessage("DetentionFreeDay is required.");
            RuleFor(rfq => rfq.UpdatedOn).NotEmpty().WithMessage("UpdatedOn is required.");
        }
    }
}
