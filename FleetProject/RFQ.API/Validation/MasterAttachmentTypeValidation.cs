using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class MasterAttachmentTypeValidation : AbstractValidator<MasterAttachmentTypeDto>
    {
        public MasterAttachmentTypeValidation()
        {
            RuleFor(master => master.AttachmentTypeName).NotEmpty().WithMessage("AttachmentTypeName is required.");
            RuleFor(master => master.LinkId).NotEmpty().WithMessage("LinkId is required.");
        }
    }
}
