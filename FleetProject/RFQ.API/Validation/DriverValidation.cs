using FluentValidation;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Validation
{
    public class DriverValidation : AbstractValidator<DriverDto>
    {
        public DriverValidation()
        {
            RuleFor(driver => driver.DriverTypeId).NotEmpty().WithMessage("DriverTypeId is required.");
            RuleFor(driver => driver.DriverName).NotEmpty().WithMessage("DriverName is required.");
            //RuleFor(driver => driver.DriverCode).NotEmpty().WithMessage("DriverCode is required."); 
            //RuleFor(driver => driver.LicenseNo).NotEmpty().WithMessage("LicenseNo is required."); 
            //RuleFor(driver => driver.DateOfBirth).NotEmpty().WithMessage("DateOfBirth is required."); 
            //RuleFor(driver => driver.LicenseIssueDate).NotEmpty().WithMessage("LicenseIssueDate is required."); 
            //RuleFor(driver => driver.LicenseIssueCityId).NotEmpty().WithMessage("LicenseIssueCityId is required."); 
            //RuleFor(driver => driver.LicenseExpDate).NotEmpty().WithMessage("LicenseExpDate is required."); 
            //RuleFor(driver => driver.MobNo).NotEmpty().Length(10).WithMessage("MobNo is required."); 
            //RuleFor(driver => driver.WhatsAppNo).NotEmpty().Length(10).WithMessage("WhatsAppNo is required."); 
            RuleFor(driver => driver.AddressLine).NotEmpty().WithMessage("AddressLine is required."); 
            RuleFor(driver => driver.CityId).NotEmpty().WithMessage("CityId is required."); 
            //RuleFor(driver => driver.PinCode).NotEmpty().WithMessage("PinCode is required."); 
            //RuleFor(driver => driver.DriverImagePath).NotEmpty().WithMessage("DriverImagePath is required."); 
            //RuleFor(driver => driver.LinkId).NotEmpty().WithMessage("LinkId is required."); 
            //RuleFor(driver => driver.CreatedBy).NotEmpty().WithMessage("CreatedBy is required."); 
            //RuleFor(driver => driver.UpdatedBy).NotEmpty().WithMessage("UpdatedBy is required."); 
        }
    }
}
