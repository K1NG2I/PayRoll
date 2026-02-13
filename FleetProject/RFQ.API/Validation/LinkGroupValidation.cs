using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class LinkGroupValidation : AbstractValidator<LinkGroupRequestDto>
    {
        public LinkGroupValidation()
        {
            RuleFor(link => link.LinkGroupName).NotEmpty().WithMessage("LinkGroupName is required.");
            RuleFor(link => link.SequenceNo).NotEmpty().WithMessage("SequenceNo is required.");
            RuleFor(link => link.LinkIcon).NotEmpty().WithMessage("LinkIcon is required.");
        }
    }
}
