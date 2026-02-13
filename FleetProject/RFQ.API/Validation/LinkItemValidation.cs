using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class LinkItemValidation : AbstractValidator<LinkItemRequestDto>
    {
        public LinkItemValidation()
        {
            RuleFor(link => link.LinkName).NotEmpty().WithMessage("LinkName is required.");
            RuleFor(link => link.ListingQuery).NotEmpty().WithMessage("ListingQuery is required.");
            RuleFor(link => link.LinkGroupId).NotEmpty().WithMessage("GroupId is required");
            RuleFor(link => link.LinkIcon).NotEmpty().WithMessage("LinkIcon is required.");
            RuleFor(link => link.SequenceNo).NotEmpty().WithMessage("SequenceNo is required.");
            RuleFor(link => link.LinkUrl).NotEmpty().WithMessage("LinkUrl is required.");
            RuleFor(link => link.AddUrl).NotEmpty().WithMessage("AddUrl is required");
            RuleFor(link => link.EditUrl).NotEmpty().WithMessage("EditUrl is required.");
            RuleFor(link => link.CancelUrl).NotEmpty().WithMessage("CancelUrl is required.");
        }
    }
}
