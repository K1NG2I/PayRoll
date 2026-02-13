using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class MasterUserActivitylogValidation : AbstractValidator<MasterUserActivityLogDto>
    {
        public MasterUserActivitylogValidation()
        {
            RuleFor(master => master.LogUid).NotEmpty().WithMessage("LogUid is required.");
            RuleFor(master => master.LogLinkId).NotEmpty().WithMessage("LogLinkId is required.");
            RuleFor(master => master.LogTypeId).NotEmpty().WithMessage("LogTypeId is required.");
            RuleFor(master => master.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(master => master.LogDateTime).NotEmpty().WithMessage("LogDateTime is required.");
            RuleFor(master => master.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
