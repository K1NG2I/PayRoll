using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class RfqVendorValidation : AbstractValidator<RfqVendorDto>
    {
        public RfqVendorValidation()
        {
            RuleFor(rfq => rfq.RfqDetailsId).NotEmpty().WithMessage("RfqDetailsId is required.");
            RuleFor(rfq => rfq.VendorId).NotEmpty().WithMessage("VendorId is required.");
            RuleFor(rfq => rfq.VendorRating).NotEmpty().WithMessage("VendorRating is required.");
            RuleFor(rfq => rfq.MobNo).NotEmpty().Length(10).WithMessage("MobileNo is required.");
            RuleFor(rfq => rfq.WhatsAppNo).NotEmpty().WithMessage("WhatsAppNo is required.");
            RuleFor(rfq => rfq.Email).NotEmpty().EmailAddress().WithMessage("Email is required");
        }
    }
}
