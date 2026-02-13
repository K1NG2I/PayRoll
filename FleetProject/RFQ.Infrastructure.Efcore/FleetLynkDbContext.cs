using Microsoft.EntityFrameworkCore;
using RFQ.Domain.Models;


namespace RFQ.Infrastructure.Efcore
{
    public class FleetLynkDbContext : DbContext
    {
        public FleetLynkDbContext(DbContextOptions<FleetLynkDbContext> options)
            : base(options)
        {

        }
        public DbSet<LinkGroup> link_Group { get; set; }
        public DbSet<LinkItem> link_Item { get; set; }
        public DbSet<CompanyCity> company_city { get; set; }
        public DbSet<CompanyCountry> company_country { get; set; }
        public DbSet<CompanyProfile> company_profile { get; set; }
        public DbSet<CompanyProfileRight> companyProfileRights { get; set; }
        public DbSet<CompanyState> company_State { get; set; }
        public DbSet<CompanyUser> company_user { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<Rfq> rfq { get; set; }
        public DbSet<RfqRate> rate { get; set; }
        public DbSet<InternalMaster> internalMaster { get; set; }
        public DbSet<InternalMasterType> internalMasterTypes { get; set; }
        public DbSet<MasterAttachment> masterAttachments { get; set; }
        public DbSet<CompanyConfigration> companyConfigurations { get; set; }
        public DbSet<MasterAttachmentType> masterAttachmentTypes { get; set; }
        public DbSet<VehicleType> com_mst_vehicle_type { get; set; }
        public DbSet<CompanyMasterItem> MasterItem { get; set; }
        public DbSet<CompanyMasterPackingType> companyMasterPackingType { get; set; }
        public DbSet<MasterMessageTemplate> masterMessageTemplate { get; set; }
        public DbSet<MasterPartyRoute> masterPartyRoute { get; set; }
        public DbSet<MasterParty> masterParty { get; set; }
        public DbSet<MasterLocation> masterLocation { get; set; }
        public DbSet<MasterUserActivityLog> masterUserActivityLogs { get; set; }
        public DbSet<MenuList> menuLists { get; set; }
        public DbSet<Driver> com_mst_driver { get; set; }
        public DbSet<Vehicle> com_mst_vehicle { get; set; }
        public DbSet<RfqRecipient> rfqRecipient { get; set; }
        public DbSet<MasterPartyVehicleType> masterPartyVehicleType { get; set; }
        public DbSet<VehicleIndent> vehicleIndents { get; set; }
        public DbSet<RfqFinal> rfqFinals { get; set; }
        public DbSet<RfqFinalRate> rfqFinalRates { get; set; }
        public DbSet<RfqLink> rfqLinks { get; set; }
        public DbSet<RfqRateHistory> rfqRateHistories { get; set; }

        public DbSet<VehiclePlacement> vehiclePlacements { get; set; }
        public DbSet<BookingOrTrip> bookingOrTrips { get; set; }
        public DbSet<BookingInvoice> bookingInvoices { get; set; }
        public DbSet<Delivery> deliveries { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<ContactPersonDetails> contactPersonDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FleetLynkDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("database");
            }
        }


    }
}
