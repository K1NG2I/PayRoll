using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class RfqValidation : AbstractValidator<RfqDto>
    {
        public RfqValidation()
        {
            RuleFor(rfq => rfq.CompanyId).NotEmpty().WithMessage("CompanyId is required.");
            //RuleFor(rfq => rfq.CustomerId).NotEmpty().WithMessage("CustomerId is required.");
            //RuleFor(rfq => rfq.RfqNoPrefix).NotEmpty().WithMessage("RfqNoPrefix is required.");
            RuleFor(rfq => rfq.RfqNo).NotEmpty().WithMessage("RfqNo is required.");
            RuleFor(rfq => rfq.RfqDate).NotEmpty().WithMessage("RfqDate is required.");
            //RuleFor(rfq => rfq.RfqSubject).NotEmpty().WithMessage("RfqSubject is required.");
            //RuleFor(rfq => rfq.RfqExpiresOn).NotEmpty().WithMessage("RfqExpiresOn is required.");
            //RuleFor(rfq => rfq.VehicleReqNo).NotEmpty().WithMessage("RfqVehicleReqNo is required.");
            RuleFor(rfq => rfq.RfqPriorityId).NotEmpty().WithMessage("RfqPriorityId is requried.");
            //RuleFor(rfq => rfq.Remarks).NotEmpty().WithMessage("Remarks is required.");
            RuleFor(rfq => rfq.LinkId).NotEmpty().WithMessage("LinkId is required.");
            RuleFor(rfq => rfq.CreatedBy).NotEmpty().WithMessage("CreatedBy is required");
            RuleFor(rfq => rfq.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required");

        }
    }
}
