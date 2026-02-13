using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class PendingUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyMasterConfigrations");

            migrationBuilder.DropTable(
                name: "masterVehicleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_masterParty",
                table: "masterParty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_masterLocation",
                table: "masterLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterItem",
                table: "MasterItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_masterAttachmentTypes",
                table: "masterAttachmentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_masterAttachments",
                table: "masterAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_link_Item",
                table: "link_Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_link_Group",
                table: "link_Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companyProfileRights",
                table: "companyProfileRights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companyMasterPackingType",
                table: "companyMasterPackingType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company_user",
                table: "company_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company_profile",
                table: "company_profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company_city",
                table: "company_city");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company",
                table: "company");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "link_Item");

            migrationBuilder.RenameTable(
                name: "masterParty",
                newName: "com_mst_party");

            migrationBuilder.RenameTable(
                name: "masterLocation",
                newName: "com_mst_location");

            migrationBuilder.RenameTable(
                name: "MasterItem",
                newName: "com_mst_item");

            migrationBuilder.RenameTable(
                name: "masterAttachmentTypes",
                newName: "com_mst_attachment_type");

            migrationBuilder.RenameTable(
                name: "masterAttachments",
                newName: "com_mst_attachment");

            migrationBuilder.RenameTable(
                name: "link_Item",
                newName: "com_mst_link_item");

            migrationBuilder.RenameTable(
                name: "link_Group",
                newName: "com_mst_link_group");

            migrationBuilder.RenameTable(
                name: "internalMaster",
                newName: "com_mst_internal_master");

            migrationBuilder.RenameTable(
                name: "companyProfileRights",
                newName: "com_mst_profile_right");

            migrationBuilder.RenameTable(
                name: "companyMasterPackingType",
                newName: "com_mst_packing_type");

            migrationBuilder.RenameTable(
                name: "company_user",
                newName: "com_mst_user");

            migrationBuilder.RenameTable(
                name: "company_profile",
                newName: "com_mst_profile");

            migrationBuilder.RenameTable(
                name: "company_city",
                newName: "com_mst_city");

            migrationBuilder.RenameTable(
                name: "company",
                newName: "com_mst_company");

            migrationBuilder.RenameColumn(
                name: "MasterTypeId",
                table: "com_mst_internal_master",
                newName: "InternalMasterTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "SequenceNo",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ListingQuery",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LinkUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LinkIcon",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LinkGroupName",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EditUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CancelUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AddUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LinkGroupIcon",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfBusiness",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TradeName",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "com_mst_party",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PartyName",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PANStatus",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PANNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PANLinkedWithAdhar",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LegalName",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GSTStatus",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GSTNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AadharVerified",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SequenceNo",
                table: "com_mst_link_item",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LinkGroupId",
                table: "com_mst_link_item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InternalMasterId",
                table: "com_mst_internal_master",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileName",
                table: "com_mst_profile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_party",
                table: "com_mst_party",
                column: "PartyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_location",
                table: "com_mst_location",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_item",
                table: "com_mst_item",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_attachment_type",
                table: "com_mst_attachment_type",
                column: "AttachmentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_attachment",
                table: "com_mst_attachment",
                column: "AttachmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_link_item",
                table: "com_mst_link_item",
                column: "LinkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_link_group",
                table: "com_mst_link_group",
                column: "LinkGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_internal_master",
                table: "com_mst_internal_master",
                column: "InternalMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_profile_right",
                table: "com_mst_profile_right",
                column: "UserProfileRightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_packing_type",
                table: "com_mst_packing_type",
                column: "PackingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_user",
                table: "com_mst_user",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_profile",
                table: "com_mst_profile",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_city",
                table: "com_mst_city",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_company",
                table: "com_mst_company",
                column: "CompanyId");

            migrationBuilder.CreateTable(
                name: "com_mst_company_config",
                columns: table => new
                {
                    CompanyConfigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SMSProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMSAuthKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsAppProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsAppAuthKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTPHost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTPPort = table.Column<int>(type: "int", nullable: false),
                    SMTPUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTPPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_mst_company_config", x => x.CompanyConfigId);
                });

            migrationBuilder.CreateTable(
                name: "com_mst_driver",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverTypeId = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseIssueCityId = table.Column<int>(type: "int", nullable: false),
                    LicenseExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsAppNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_mst_driver", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "com_mst_vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerVendorId = table.Column<int>(type: "int", nullable: false),
                    VehicleCategoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleCapacity = table.Column<int>(type: "int", nullable: false),
                    TrackingProviderId = table.Column<int>(type: "int", nullable: false),
                    VehicleStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlacklistStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RTORegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegdOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakeModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PUCExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FitnessExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermitNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermitExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Financer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerSerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NPNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NPExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceCo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnladenWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_mst_vehicle", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "com_mst_vehicle_type",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumKms = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_mst_vehicle_type", x => x.VehicleTypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "com_mst_company_config");

            migrationBuilder.DropTable(
                name: "com_mst_driver");

            migrationBuilder.DropTable(
                name: "com_mst_vehicle");

            migrationBuilder.DropTable(
                name: "com_mst_vehicle_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_user",
                table: "com_mst_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_profile_right",
                table: "com_mst_profile_right");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_profile",
                table: "com_mst_profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_party",
                table: "com_mst_party");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_packing_type",
                table: "com_mst_packing_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_location",
                table: "com_mst_location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_link_item",
                table: "com_mst_link_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_link_group",
                table: "com_mst_link_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_item",
                table: "com_mst_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_internal_master",
                table: "com_mst_internal_master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_company",
                table: "com_mst_company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_city",
                table: "com_mst_city");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_attachment_type",
                table: "com_mst_attachment_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_attachment",
                table: "com_mst_attachment");

            migrationBuilder.DropColumn(
                name: "LinkGroupIcon",
                table: "menuLists");

            migrationBuilder.DropColumn(
                name: "LinkGroupId",
                table: "com_mst_link_item");

            migrationBuilder.RenameTable(
                name: "com_mst_user",
                newName: "company_user");

            migrationBuilder.RenameTable(
                name: "com_mst_profile_right",
                newName: "companyProfileRights");

            migrationBuilder.RenameTable(
                name: "com_mst_profile",
                newName: "company_profile");

            migrationBuilder.RenameTable(
                name: "com_mst_party",
                newName: "masterParty");

            migrationBuilder.RenameTable(
                name: "com_mst_packing_type",
                newName: "companyMasterPackingType");

            migrationBuilder.RenameTable(
                name: "com_mst_location",
                newName: "masterLocation");

            migrationBuilder.RenameTable(
                name: "com_mst_link_item",
                newName: "link_Item");

            migrationBuilder.RenameTable(
                name: "com_mst_link_group",
                newName: "link_Group");

            migrationBuilder.RenameTable(
                name: "com_mst_item",
                newName: "MasterItem");

            migrationBuilder.RenameTable(
                name: "com_mst_internal_master",
                newName: "internalMaster");

            migrationBuilder.RenameTable(
                name: "com_mst_company",
                newName: "company");

            migrationBuilder.RenameTable(
                name: "com_mst_city",
                newName: "company_city");

            migrationBuilder.RenameTable(
                name: "com_mst_attachment_type",
                newName: "masterAttachmentTypes");

            migrationBuilder.RenameTable(
                name: "com_mst_attachment",
                newName: "masterAttachments");

            migrationBuilder.RenameColumn(
                name: "InternalMasterTypeId",
                table: "internalMaster",
                newName: "MasterTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "SequenceNo",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ListingQuery",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkIcon",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkGroupName",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EditUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancelUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileName",
                table: "company_profile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppNo",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfBusiness",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TradeName",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "masterParty",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PartyName",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PANStatus",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PANNo",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PANLinkedWithAdhar",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MobNo",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LegalName",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GSTStatus",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GSTNo",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNo",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AadharVerified",
                table: "masterParty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SequenceNo",
                table: "link_Item",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "link_Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "InternalMasterId",
                table: "internalMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company_user",
                table: "company_user",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companyProfileRights",
                table: "companyProfileRights",
                column: "UserProfileRightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company_profile",
                table: "company_profile",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_masterParty",
                table: "masterParty",
                column: "PartyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companyMasterPackingType",
                table: "companyMasterPackingType",
                column: "PackingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_masterLocation",
                table: "masterLocation",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_link_Item",
                table: "link_Item",
                column: "LinkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_link_Group",
                table: "link_Group",
                column: "LinkGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterItem",
                table: "MasterItem",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company",
                table: "company",
                column: "CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company_city",
                table: "company_city",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_masterAttachmentTypes",
                table: "masterAttachmentTypes",
                column: "AttachmentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_masterAttachments",
                table: "masterAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateTable(
                name: "companyMasterConfigrations",
                columns: table => new
                {
                    CompanyConfigrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SMSAuthKey = table.Column<int>(type: "int", nullable: false),
                    SMSProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPHost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPPort = table.Column<int>(type: "int", nullable: false),
                    SMTPUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsAppAuthKey = table.Column<int>(type: "int", nullable: false),
                    WhatsAppProvider = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyMasterConfigrations", x => x.CompanyConfigrationId);
                });

            migrationBuilder.CreateTable(
                name: "masterVehicleType",
                columns: table => new
                {
                    VechicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masterVehicleType", x => x.VechicleTypeId);
                });
        }
    }
}
