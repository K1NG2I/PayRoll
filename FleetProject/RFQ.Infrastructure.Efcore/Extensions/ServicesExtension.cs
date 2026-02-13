using Microsoft.Extensions.DependencyInjection;
using RFQ.Domain.Interfaces;
using RFQ.Infrastructure.Efcore.Providers;


namespace RFQ.Infrastructure.Efcore.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddEfcoreInfrastrucureService(this IServiceCollection services)
        {
            services.AddScoped<IloginRepository, LoginRepository>();
            services.AddScoped<ILinkGroupRepository, LinkGroupRepository>();
            services.AddScoped<ILinkItemRepository, LinkItemRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IRfqRepository, RfqRepository>();
            services.AddScoped<IInternalMasterTypeRepository, InternalMasterTypeRepository>();
            services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
            services.AddScoped<ICompanyProfileRepository, CompanyProfileRepository>();
            services.AddScoped<ICompanyProfileRightRepository, CompanyProfileRightRepository>();
            services.AddScoped<ICompanyCountryRepository, CompanyCountryRepository>();
            services.AddScoped<ICompanyStateRepository, CompanyStateRepository>();
            services.AddScoped<ICompanyCityRepository, CompanyCityRepository>();
            services.AddScoped<IRfqRateRepository, RfqRateRepository>();
            services.AddScoped<IMasterAttachmentRepository, MasterAttachmentRepository>();
            services.AddScoped<ICompanyConfigurationRepository, CompanyConfigurationRepositroy>();
            services.AddScoped<IMasterAttachmentTypeRepository, MasterAttachmentTypeRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<ICompanyMasterItemRepository, CompanyMasterItemRepository>();
            services.AddScoped<ICompanyMasterPackingTypeRepository, CompanyMasterPackingTypeRepository>();
            services.AddScoped<IMasterMessageTemplateRepository, MasterMessageTemplateRepository>();
            services.AddScoped<IMasterPartyRouteRepository, MasterPartyRouteRepository>();
            services.AddScoped<IMasterPartyRepository, MasterPartyRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IMasterUserActivityLogRepository, MasterUserActivityLogRepository>();
            services.AddScoped<IMenuListRepository, MenuListRepository>();
            services.AddScoped<IInternalMasterRepository, InternalMasterRepository>();
            services.AddScoped<IFleetLynkAdo, FleetLynkAdo>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IRfqRecipientRepository, RfqRecipientRepository>();
            services.AddScoped<IMasterPartyVehicleTypeRepository, MasterPartyVehicleTypeRepository>();
            services.AddScoped<IVehicleIndentRepository, VehicleIndentRepository>();
            services.AddScoped<IRfqFinalRepository, RfqFinalRepository>();
            services.AddScoped<IVehiclePlacementRepository, VehiclePlacementRepository>();
            services.AddScoped<IRfqLinkRepository, RfqLinkRepository>();
            services.AddScoped<IRfqFinalRateRepository, RfqFinalRateRepository>();
            services.AddScoped<IBookingOrTripRepository, BookingOrTripRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IEWayBillRepository, EWayBillRepository>();
            services.AddScoped<IBookingInvoiceRepository, BookingInvoiceRepository>();
            services.AddScoped<ICommonRepositroy, CommonRepositroy>();
            services.AddScoped<IContactPersonDetailsRepository, ContactPersonDetailsRepository>();
            return services;
        }
    }
}
