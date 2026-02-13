using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class Addtables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companyConfigrations",
                columns: table => new
                {
                    CompanyConfigrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SMSProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSAuthKey = table.Column<int>(type: "int", nullable: false),
                    WhatsAppProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsAppAuthKey = table.Column<int>(type: "int", nullable: false),
                    SMTPHost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPPort = table.Column<int>(type: "int", nullable: false),
                    SMTPUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyConfigrations", x => x.CompanyConfigrationId);
                });

            migrationBuilder.CreateTable(
                name: "companyMasterPackingType",
                columns: table => new
                {
                    PackingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyMasterPackingType", x => x.PackingId);
                });

            migrationBuilder.CreateTable(
                name: "masterAttachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceLinkId = table.Column<int>(type: "int", nullable: false),
                    AttachmentTypeId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterAttachments", x => x.AttachmentId);
                });

            migrationBuilder.CreateTable(
                name: "masterAttachmentTypes",
                columns: table => new
                {
                    AttachmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterAttachmentTypes", x => x.AttachmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MasterItem",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterItem", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "masterMessageTemplate",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    EmailTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmsTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsAppTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterMessageTemplate", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "masterParty",
                columns: table => new
                {
                    PartyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PartyTypeId = table.Column<int>(type: "int", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyCategoryId = table.Column<int>(type: "int", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsAppNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PANNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfBusiness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharVerified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTVarifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PANStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PANLinkedWithAdhar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PANVerifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterParty", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "masterPartyRoute",
                columns: table => new
                {
                    PartyRouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    FromCityId = table.Column<int>(type: "int", nullable: false),
                    FromStateId = table.Column<int>(type: "int", nullable: false),
                    ToStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterPartyRoute", x => x.PartyRouteId);
                });

            migrationBuilder.CreateTable(
                name: "masterVehicleType",
                columns: table => new
                {
                    VechicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterVehicleType", x => x.VechicleTypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyConfigrations");

            migrationBuilder.DropTable(
                name: "companyMasterPackingType");

            migrationBuilder.DropTable(
                name: "masterAttachments");

            migrationBuilder.DropTable(
                name: "masterAttachmentTypes");

            migrationBuilder.DropTable(
                name: "MasterItem");

            migrationBuilder.DropTable(
                name: "masterMessageTemplate");

            migrationBuilder.DropTable(
                name: "masterParty");

            migrationBuilder.DropTable(
                name: "masterPartyRoute");

            migrationBuilder.DropTable(
                name: "masterVehicleType");
        }
    }
}
