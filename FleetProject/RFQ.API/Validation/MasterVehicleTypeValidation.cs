using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class MasterVehicleTypeValidation : AbstractValidator<VehicleTypeDto>
    {
        public MasterVehicleTypeValidation()
        {
            RuleFor(rfq => rfq.CompanyId).NotEmpty().WithMessage("CompanyId is Required.");
            RuleFor(rfq => rfq.VehicleTypeName).NotEmpty().WithMessage("VehicleTypeName is Required.");
            RuleFor(rfq => rfq.CreatedBy).NotEmpty().WithMessage("CreatedBy is Required.");
            RuleFor(rfq => rfq.UpdatedBy).NotEmpty().WithMessage("UpdateBy is Required.");
        }
    }
}
