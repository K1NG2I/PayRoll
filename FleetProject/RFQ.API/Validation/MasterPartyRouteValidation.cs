using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class MasterPartyRouteValidation : AbstractValidator<MasterPartyRouteDto>
    {
        public MasterPartyRouteValidation()
        {
            RuleFor(master => master.PartyId).NotEmpty().WithMessage("PartyId is required.");
            RuleFor(master => master.FromCityId).NotEmpty().WithMessage("FromCityId is required.");
            RuleFor(master => master.FromStateId).NotEmpty().WithMessage("FromStateId is required.");
            RuleFor(master => master.ToStateId).NotEmpty().WithMessage("ToStateId is required.");
        }
    }
}
