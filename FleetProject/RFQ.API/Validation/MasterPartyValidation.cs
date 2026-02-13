using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class MasterPartyValidation : AbstractValidator<MasterPartyDto>
    {
        public MasterPartyValidation()
        {
            RuleFor(master => master.CompanyId).NotEmpty().WithMessage("CompanyId is required.");
            RuleFor(master => master.PartyTypeId).NotEmpty().WithMessage("PartyTypeId is required.");
            RuleFor(master => master.PartyName).NotEmpty().WithMessage("PartyName is required.");
            RuleFor(master => master.PartyCategoryId).NotEmpty().WithMessage("PartyCategoryId is required.");
            RuleFor(master => master.AddressLine).NotEmpty().WithMessage("AddressLine is required.");
            RuleFor(master => master.CityId).NotEmpty().WithMessage("CityId is required.");
            RuleFor(master => master.PinCode).NotEmpty().WithMessage("PinCode is required.");
            RuleFor(master => master.WhatsAppNo).NotEmpty().Length(10).WithMessage("WhatsAppNo is required.");
            RuleFor(master => master.PANNo).NotEmpty().WithMessage("PANNo is required.");
            RuleFor(master => master.LinkId).NotEmpty().WithMessage("LinkId is required.");
            RuleFor(master => master.CreatedBy).NotEmpty().WithMessage("CreatedBy is required.");
            RuleFor(master => master.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required.");

        }
    }
}
