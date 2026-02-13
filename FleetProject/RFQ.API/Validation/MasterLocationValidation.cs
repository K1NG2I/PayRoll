using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class MasterLocationValidation : AbstractValidator<MasterLocationDto>
    {
        public MasterLocationValidation()
        {
            RuleFor(master => master.CompanyId).NotEmpty().WithMessage("CompanyId is required.");
            RuleFor(master => master.LocationName).NotEmpty().WithMessage("LocationName is required.");
            RuleFor(master => master.AddressLine).NotEmpty().WithMessage("AddressLine is required.");
            RuleFor(master => master.CityId).NotEmpty().WithMessage("CityId is required.");
            RuleFor(master => master.PinCode).NotEmpty().WithMessage("PinCode is required.");
            RuleFor(master => master.WhatsAppNo).NotEmpty().WithMessage("WhatsAppNo is required.");
            RuleFor(master => master.LinkId).NotEmpty().WithMessage("LinkId is required.");
            RuleFor(master => master.CreatedBy).NotEmpty().WithMessage("CreatedBy is required.");
            RuleFor(master => master.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required.");
        }
    }
}
