using Microsoft.Extensions.DependencyInjection;
using RFQ.Application.Helper;
using RFQ.Application.Interface;
using RFQ.Application.Provider;

namespace RFQ.Application.Extension
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILinkService, LinkGroupService>();
            services.AddScoped<ILinkItemService, LinkItemService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRfqService, RfqService>();
            services.AddScoped<IInternalMasterTypeService, InternalMasterTypeService>();
            services.AddScoped<ICompanyCountryService, CompanyCountryService>();
            services.AddScoped<ICompanyUserService, CompanyUserService>();
            services.AddScoped<ICompanyStateService, CompanyStateService>();
            services.AddScoped<ICompanyCityService, CompanyCityService>();
            services.AddScoped<ICompanyProfileService, CompanyProfileService>();
            services.AddScoped<ICompanyProfileRightService, CompanyProfileRightService>();
            services.AddScoped<IRfqRateService, RfqRateService>();
            services.AddScoped<IMasterAttachmentService, MasterAttachmentService>();
            services.AddScoped<ICompanyConfigurationService, CompanyConfigurationService>();
            services.AddScoped<IMasterAttachmentTypeService, MasterAttachmentTypeService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<ICompanyMasterItemService, CompanyMasterItemService>();
            services.AddScoped<ICompanyMasterPackingTypeService, CompanyMasterPackingTypeService>();
            services.AddScoped<IMasterMessageTemplateService, MasterMessageTemplateService>();
            services.AddScoped<IMasterPartyRouteService, MasterPartyRouteService>();
            services.AddScoped<IMasterPartyService, MasterPartyService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IMasterUserActivityLogService, MasterUserActivityLogService>();
            services.AddScoped<IPasswordHasher, PasswordHasherService>();
            services.AddScoped<IMenuListService, MenuListService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IInternalMasterService, InternalMasterService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IRfqRecipientService, RfqRecipientService>();
            services.AddScoped<IMasterPartyVehicleTypeService, MasterPartyVehicleTypeService>();
            services.AddScoped<IVehicleIndentService, VehicleIndentService>();
            services.AddScoped<IRfqFinalService, RfqFinalService>();
            services.AddScoped<IVehiclePlacementService, VehiclePlacementService>();
            services.AddScoped<IRfqLinkService, RfqLinkService>();
            services.AddScoped<IRfqFinalRateService, RfqFinalRateService>();
            services.AddScoped<IBookingOrTripService, BookingOrTripService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IEWayBillService, EWayBillService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IBookingInvoiceService, BookingInvoiceService>();
            services.AddScoped<LinkItemContextHelper>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IContactPersonDetailsService, ContactPersonDetailsService>();

            return services;
        }
    }
}
