using FluentValidation;
using RFQ.Domain.Models;

namespace RFQ.Web.API.Validation
{
    public class MasterValidation : AbstractValidator<InternalMasterType>
    {
        public MasterValidation()
        {
            RuleFor(master => master.MasterTypeId).NotEmpty().WithMessage("MasterTypeId is required.");
            RuleFor(master => master.MasterTypeName).NotEmpty().WithMessage("MasterTypeName is required.");
        }
    }
}
