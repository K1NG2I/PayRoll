using AutoMapper;
using RFQ.Domain.RequestDto;
using RFQ.Domain.Models;
using RFQ.Domain.ResponseDto;

namespace RFQ.Web.API.MapperProfile
{
    public class AutoMappersRegister : Profile
    {
        public AutoMappersRegister()
        {
            CreateMap<LinkGroup, LinkGroupRequestDto>();
            CreateMap<LinkGroupRequestDto, LinkGroup>();
            CreateMap<LinkItemRequestDto, LinkItem>();
            CreateMap<LinkItem, LinkItemRequestDto>();
            CreateMap<CompanyUser, CompanyUserDto>();
            CreateMap<CompanyUserDto, CompanyUser>();
            CreateMap<CompanyProfile, CompanyProfileDto>();
            CreateMap<CompanyProfileDto, CompanyProfile>();
            CreateMap<CompanyProfileRight, CompanyProfileRightDto>();
            CreateMap<CompanyProfileRightDto, CompanyProfileRight>();
            CreateMap<CompanyCountry, CompanyCountryDto>();
            CreateMap<CompanyCountryDto, CompanyCountry>();
            CreateMap<CompanyState, CompanyStateDto>();
            CreateMap<CompanyStateDto, CompanyState>();
            CreateMap<CompanyCity, CompanyCityDto>();
            CreateMap<CompanyCityDto, CompanyCity>();
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<Rfq, RfqDto>();
            CreateMap<RfqDto, Rfq>();
            CreateMap<RfqRate, RfqRateDto>();
            CreateMap<RfqRateDto, RfqRate>();
            CreateMap<CompanyUser, LoginDto>();
            CreateMap<LoginDto, CompanyUser>();
            CreateMap<MasterAttachment, MasterAttachmentDto>();
            CreateMap<MasterAttachmentDto, MasterAttachment>();
            CreateMap<CompanyConfigurationDto, CompanyConfigration>();
            CreateMap<CompanyConfigration, CompanyConfigurationDto>();
            CreateMap<MasterAttachmentType, MasterAttachmentTypeDto>();
            CreateMap<MasterAttachmentTypeDto, MasterAttachmentType>();
            CreateMap<VehicleType, VehicleTypeDto>();
            CreateMap<VehicleTypeDto, VehicleType>();
            CreateMap<CompanyMasterItem, CompanyMasterItemDto>();
            CreateMap<CompanyMasterItemDto, CompanyMasterItem>();
            CreateMap<CompanyMasterPackingTypeDto, CompanyMasterPackingType>();
            CreateMap<CompanyMasterPackingType, CompanyMasterPackingTypeDto>();
            CreateMap<MasterMessageTemplateDto, MasterMessageTemplate>();
            CreateMap<MasterMessageTemplate, MasterMessageTemplateDto>();
            CreateMap<MasterPartyRouteDto, MasterPartyRoute>();
            CreateMap<MasterPartyRoute, MasterPartyRouteDto>();
            CreateMap<MasterPartyDto, MasterParty>();
            CreateMap<MasterParty, MasterPartyDto>();
            CreateMap<MasterLocationDto, MasterLocation>();
            CreateMap<MasterLocation, MasterLocationDto>();
            CreateMap<MasterUserActivityLogDto, MasterUserActivityLog>();
            CreateMap<MasterUserActivityLog, MasterUserActivityLogDto>();
            CreateMap<MenuListDto, MenuList>();
            CreateMap<MenuList, MenuListDto>();
            CreateMap<Driver, DriverDto>();
            CreateMap<DriverDto, Driver>();
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();
            CreateMap<RfqRecipient, RfqRecipientRequestDto>();
            CreateMap<RfqRecipientRequestDto, RfqRecipient>();
            CreateMap<MasterPartyVehicleType, MasterPartyVehicleTypeDto>();
            CreateMap<MasterPartyVehicleTypeDto, MasterPartyVehicleType>();
            CreateMap<VehiclePlacement, VehiclePlacementDto>();
            CreateMap<VehiclePlacementDto, VehiclePlacement>();
            CreateMap<VehicleIndent,VehicleIndentDto>();
            CreateMap<VehicleIndentDto,VehicleIndent>();
            CreateMap<RfqFinalDto,RfqFinal>();
            CreateMap<RfqFinal,RfqFinalDto>();
            CreateMap<RfqLink, RfqLinkDto>();
            CreateMap<RfqLinkDto, RfqLink>();
            CreateMap<RfqRateHistory, RfqRate>();
            CreateMap<RfqRate, RfqRateHistory>();
            CreateMap<RfqFinalRate, RfqFinalRateDto>();
            CreateMap<RfqFinalRateDto, RfqFinalRate>();
            CreateMap<CompanyProfileRightRequestDto, CompanyProfileRight>();
            CreateMap<CompanyProfileRight, CompanyProfileRightRequestDto>();
            CreateMap<Rfq,RfqDrpListResponseDto>();
            CreateMap<BookingOrTripRequestDto, BookingOrTrip>();
            CreateMap<BookingOrTrip, BookingOrTripRequestDto>();
            CreateMap<DeliveryRequestDto, Delivery>();
            CreateMap<Delivery, DeliveryRequestDto>();
            CreateMap<BookingOrTrip, BookingOrTripRequestDto>();
            CreateMap<BookingInvoice, BookingInvoiceRequestDto>();
        }
    
    }
}
