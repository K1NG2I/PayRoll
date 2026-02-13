using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class MasterAttachmentValidation : AbstractValidator<MasterAttachmentDto>
    {
        public MasterAttachmentValidation()
        {
            RuleFor(master => master.AttachmentName).NotEmpty().WithMessage("AttachmentName is required.");
            RuleFor(master => master.AttachmentPath).NotEmpty().WithMessage("AttachmentPath is required");
            RuleFor(master => master.ReferenceLinkId).NotEmpty().WithMessage("ReferenceLinkId is required");
            RuleFor(master => master.AttachmentTypeId).NotEmpty().WithMessage("AttachmentTypeId is required");
            RuleFor(master => master.TransactionId).NotEmpty().WithMessage("TransactionId is required");
        }
    }
}
