using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class MasterMessageTemplateValidation : AbstractValidator<MasterMessageTemplateDto>
    {
        public MasterMessageTemplateValidation()
        {
            RuleFor(master => master.CompanyId).NotEmpty().WithMessage("CompanyId is required.");
            RuleFor(master => master.EventTypeId).NotEmpty().WithMessage("EventTypeId is required.");
            RuleFor(master => master.EmailTemplate).NotEmpty().WithMessage("EmailTemplate is required.");
            RuleFor(master => master.SmsTemplate).NotEmpty().WithMessage("SmsTemplate is required.");
            RuleFor(master => master.WhatsAppTemplate).NotEmpty().WithMessage("WhatsAppTemplate is required.");
        }
    }
}
