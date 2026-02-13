using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rfqDetails");

            migrationBuilder.DropTable(
                name: "rfqStop");

            migrationBuilder.DropTable(
                name: "rfqVendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rfq",
                table: "rfq");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rate",
                table: "rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_masterUserActivityLogs",
                table: "masterUserActivityLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_masterPartyRoute",
                table: "masterPartyRoute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company_State",
                table: "company_State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company_country",
                table: "company_country");

            migrationBuilder.RenameTable(
                name: "rfq",
                newName: "com_trn_rfq");

            migrationBuilder.RenameTable(
                name: "rate",
                newName: "com_trn_rfq_rate");

            migrationBuilder.RenameTable(
                name: "masterUserActivityLogs",
                newName: "com_mst_user_activity_log");

            migrationBuilder.RenameTable(
                name: "masterPartyRoute",
                newName: "com_mst_party_route");

            migrationBuilder.RenameTable(
                name: "company_State",
                newName: "com_mst_state");

            migrationBuilder.RenameTable(
                name: "company_country",
                newName: "com_mst_country");

            migrationBuilder.RenameColumn(
                name: "VehicleReqNo",
                table: "com_trn_rfq",
                newName: "VehicleReqOn");

            migrationBuilder.RenameColumn(
                name: "RfqNoPrefix",
                table: "com_trn_rfq",
                newName: "ToLongitude");

            migrationBuilder.RenameColumn(
                name: "RfqExpiresOn",
                table: "com_trn_rfq",
                newName: "ExpiryDate");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "com_trn_rfq",
                newName: "ToLocationState");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "com_trn_rfq",
                newName: "VehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "RfqDetailId",
                table: "com_trn_rfq_rate",
                newName: "RfqId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "com_trn_rfq_rate",
                newName: "DetentionFreeDays");

            migrationBuilder.RenameColumn(
                name: "DetentionFreeDay",
                table: "com_trn_rfq_rate",
                newName: "AvailVehicleCount");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_vehicle_type",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "com_mst_vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "com_mst_user",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "com_mst_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "com_mst_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "com_mst_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                table: "com_mst_user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "com_mst_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "com_mst_user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "com_mst_user",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "com_mst_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfBusiness",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TradeName",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PartyName",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PartyCategoryId",
                table: "com_mst_party",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PANStatus",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PANNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PANLinkedWithAdhar",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MobNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LegalName",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GSTStatus",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GSTNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNo",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_party",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AadharVerified",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GSTAddress",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PANCardName",
                table: "com_mst_party",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_location",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "com_mst_location",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppNo",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MobNo",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LicenseNo",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenseIssueDate",
                table: "com_mst_driver",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LicenseIssueCityId",
                table: "com_mst_driver",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenseExpDate",
                table: "com_mst_driver",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DriverImagePath",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DriverCode",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "com_mst_driver",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "com_mst_driver",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DLIssuingRto",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VarifiedOn",
                table: "com_mst_driver",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppProvider",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppAuthKey",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SMTPUsername",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SMTPPort",
                table: "com_mst_company_config",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SMTPPassword",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SMTPHost",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SMSProvider",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SMSAuthKey",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_company_config",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "com_mst_company_config",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentCompanyId",
                table: "com_mst_company",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RfqNo",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DetentionFreeDays",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DetentionPerDay",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FromLatitude",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FromLocation",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FromLocationCity",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FromLocationState",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FromLongitude",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IndentId",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxCosting",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackingTypeId",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecialInstruction",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToLatitude",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToLocation",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToLocationCity",
                table: "com_trn_rfq",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleCount",
                table: "com_trn_rfq",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogDateTime",
                table: "com_mst_user_activity_log",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_trn_rfq",
                table: "com_trn_rfq",
                column: "RfqId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_trn_rfq_rate",
                table: "com_trn_rfq_rate",
                column: "RfqRateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_user_activity_log",
                table: "com_mst_user_activity_log",
                column: "UserActivityLogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_party_route",
                table: "com_mst_party_route",
                column: "PartyRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_state",
                table: "com_mst_state",
                column: "StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_com_mst_country",
                table: "com_mst_country",
                column: "CountryId");

            migrationBuilder.CreateTable(
                name: "com_mst_party_vehicle_type",
                columns: table => new
                {
                    PartyVehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_mst_party_vehicle_type", x => x.PartyVehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlacementId = table.Column<int>(type: "int", nullable: false),
                    EWayBillStateId = table.Column<int>(type: "int", nullable: true),
                    BusinessVerticalId = table.Column<int>(type: "int", nullable: true),
                    FromLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLatitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLongitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLatitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLongitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverMobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackingTypeId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceValue = table.Column<int>(type: "int", nullable: true),
                    EWayBillNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EWayBillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EWayBillExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsignerId = table.Column<int>(type: "int", nullable: true),
                    ConsignerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeId = table.Column<int>(type: "int", nullable: true),
                    ConsigneeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransitDays = table.Column<int>(type: "int", nullable: true),
                    EDD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    PackingTypeId = table.Column<int>(type: "int", nullable: true),
                    TotalPacket = table.Column<int>(type: "int", nullable: true),
                    ActualWeight = table.Column<int>(type: "int", nullable: true),
                    ChargedWeight = table.Column<int>(type: "int", nullable: true),
                    TotalFreight = table.Column<int>(type: "int", nullable: true),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_booking", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_booking_invoice",
                columns: table => new
                {
                    BookingInvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceValue = table.Column<int>(type: "int", nullable: true),
                    EWayBillNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EWayBillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EWayBillExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_booking_invoice", x => x.BookingInvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_delivery",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnloadDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveredPackets = table.Column<int>(type: "int", nullable: true),
                    DeliveredWeight = table.Column<int>(type: "int", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_delivery", x => x.DeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_indent",
                columns: table => new
                {
                    IndentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IndentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleReqOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    FromLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromLocationState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromLocationCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToLocationState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToLocationCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    RequiredVehicles = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsignerId = table.Column<int>(type: "int", nullable: true),
                    ConsignerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeId = table.Column<int>(type: "int", nullable: true),
                    ConsigneeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickUpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    PackingTypeId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_indent", x => x.IndentId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_placement",
                columns: table => new
                {
                    PlacementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacementNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PlacementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndentId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    TrackingTypeId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerVendorId = table.Column<int>(type: "int", nullable: true),
                    BrokerVendorId = table.Column<int>(type: "int", nullable: true),
                    TotalHireAmount = table.Column<int>(type: "int", nullable: true),
                    AdvancePayable = table.Column<int>(type: "int", nullable: true),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_placement", x => x.PlacementId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_rfq_final",
                columns: table => new
                {
                    RfqFinalIdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RfqStatusId = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    BillingRate = table.Column<int>(type: "int", nullable: false),
                    DetentionPerDay = table.Column<int>(type: "int", nullable: false),
                    DetentionFreeDays = table.Column<int>(type: "int", nullable: false),
                    MarginAmount = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_rfq_final", x => x.RfqFinalIdId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_rfq_final_rate",
                columns: table => new
                {
                    RfqFinalRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqFinalId = table.Column<int>(type: "int", nullable: false),
                    RfqId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    AvailVehicleCount = table.Column<int>(type: "int", nullable: false),
                    AssignedVehicles = table.Column<int>(type: "int", nullable: false),
                    IsAssigned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_rfq_final_rate", x => x.RfqFinalRateId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_rfq_link",
                columns: table => new
                {
                    RfqRateLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    SharedLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_rfq_link", x => x.RfqRateLinkId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_rfq_rate_history",
                columns: table => new
                {
                    RfqRateHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    AvailVehicleCount = table.Column<int>(type: "int", nullable: false),
                    TotalHireCost = table.Column<int>(type: "int", nullable: false),
                    DetentionPerDay = table.Column<int>(type: "int", nullable: false),
                    DetentionFreeDays = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_rfq_rate_history", x => x.RfqRateHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "com_trn_rfq_recipient",
                columns: table => new
                {
                    RfqRecipientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorRating = table.Column<int>(type: "int", nullable: false),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsAppNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_com_trn_rfq_recipient", x => x.RfqRecipientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "com_mst_party_vehicle_type");

            migrationBuilder.DropTable(
                name: "com_trn_booking");

            migrationBuilder.DropTable(
                name: "com_trn_booking_invoice");

            migrationBuilder.DropTable(
                name: "com_trn_delivery");

            migrationBuilder.DropTable(
                name: "com_trn_indent");

            migrationBuilder.DropTable(
                name: "com_trn_placement");

            migrationBuilder.DropTable(
                name: "com_trn_rfq_final");

            migrationBuilder.DropTable(
                name: "com_trn_rfq_final_rate");

            migrationBuilder.DropTable(
                name: "com_trn_rfq_link");

            migrationBuilder.DropTable(
                name: "com_trn_rfq_rate_history");

            migrationBuilder.DropTable(
                name: "com_trn_rfq_recipient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_trn_rfq_rate",
                table: "com_trn_rfq_rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_trn_rfq",
                table: "com_trn_rfq");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_user_activity_log",
                table: "com_mst_user_activity_log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_state",
                table: "com_mst_state");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_party_route",
                table: "com_mst_party_route");

            migrationBuilder.DropPrimaryKey(
                name: "PK_com_mst_country",
                table: "com_mst_country");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "com_mst_vehicle");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "com_mst_party");

            migrationBuilder.DropColumn(
                name: "GSTAddress",
                table: "com_mst_party");

            migrationBuilder.DropColumn(
                name: "PANCardName",
                table: "com_mst_party");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "com_mst_location");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "com_mst_driver");

            migrationBuilder.DropColumn(
                name: "DLIssuingRto",
                table: "com_mst_driver");

            migrationBuilder.DropColumn(
                name: "VarifiedOn",
                table: "com_mst_driver");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "com_mst_company_config");

            migrationBuilder.DropColumn(
                name: "DetentionFreeDays",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "DetentionPerDay",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "FromLatitude",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "FromLocation",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "FromLocationCity",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "FromLocationState",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "FromLongitude",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "IndentId",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "MaxCosting",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "PackingTypeId",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "SpecialInstruction",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "ToLatitude",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "ToLocation",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "ToLocationCity",
                table: "com_trn_rfq");

            migrationBuilder.DropColumn(
                name: "VehicleCount",
                table: "com_trn_rfq");

            migrationBuilder.RenameTable(
                name: "com_trn_rfq_rate",
                newName: "rate");

            migrationBuilder.RenameTable(
                name: "com_trn_rfq",
                newName: "rfq");

            migrationBuilder.RenameTable(
                name: "com_mst_user_activity_log",
                newName: "masterUserActivityLogs");

            migrationBuilder.RenameTable(
                name: "com_mst_state",
                newName: "company_State");

            migrationBuilder.RenameTable(
                name: "com_mst_party_route",
                newName: "masterPartyRoute");

            migrationBuilder.RenameTable(
                name: "com_mst_country",
                newName: "company_country");

            migrationBuilder.RenameColumn(
                name: "RfqId",
                table: "rate",
                newName: "RfqDetailId");

            migrationBuilder.RenameColumn(
                name: "DetentionFreeDays",
                table: "rate",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "AvailVehicleCount",
                table: "rate",
                newName: "DetentionFreeDay");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "rfq",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "VehicleReqOn",
                table: "rfq",
                newName: "VehicleReqNo");

            migrationBuilder.RenameColumn(
                name: "ToLongitude",
                table: "rfq",
                newName: "RfqNoPrefix");

            migrationBuilder.RenameColumn(
                name: "ToLocationState",
                table: "rfq",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "rfq",
                newName: "RfqExpiresOn");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_vehicle_type",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "com_mst_user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "com_mst_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "com_mst_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "com_mst_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                table: "com_mst_user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "com_mst_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "com_mst_user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "com_mst_user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "com_mst_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "PartyCategoryId",
                table: "com_mst_party",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
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

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_party",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
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
                name: "CompanyId",
                table: "com_mst_location",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_item",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppNo",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobNo",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LicenseNo",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenseIssueDate",
                table: "com_mst_driver",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LicenseIssueCityId",
                table: "com_mst_driver",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LicenseExpDate",
                table: "com_mst_driver",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DriverImagePath",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DriverCode",
                table: "com_mst_driver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "com_mst_driver",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppProvider",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppAuthKey",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SMTPUsername",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SMTPPort",
                table: "com_mst_company_config",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SMTPPassword",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SMTPHost",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SMSProvider",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SMSAuthKey",
                table: "com_mst_company_config",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "com_mst_company_config",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentCompanyId",
                table: "com_mst_company",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RfqNo",
                table: "rfq",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogDateTime",
                table: "masterUserActivityLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_rate",
                table: "rate",
                column: "RfqRateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rfq",
                table: "rfq",
                column: "RfqId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_masterUserActivityLogs",
                table: "masterUserActivityLogs",
                column: "UserActivityLogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company_State",
                table: "company_State",
                column: "StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_masterPartyRoute",
                table: "masterPartyRoute",
                column: "PartyRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company_country",
                table: "company_country",
                column: "CountryId");

            migrationBuilder.CreateTable(
                name: "rfqDetails",
                columns: table => new
                {
                    RfqDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetentionFreeDay = table.Column<int>(type: "int", nullable: false),
                    DetentionPerDay = table.Column<int>(type: "int", nullable: false),
                    FromLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLocLat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLocLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    MaxCosting = table.Column<int>(type: "int", nullable: false),
                    PackingTypeId = table.Column<int>(type: "int", nullable: false),
                    RfqId = table.Column<int>(type: "int", nullable: false),
                    RfqOnId = table.Column<int>(type: "int", nullable: false),
                    SpecialInstruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocLat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQty = table.Column<int>(type: "int", nullable: false),
                    VehicleCount = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rfqDetails", x => x.RfqDetailId);
                });

            migrationBuilder.CreateTable(
                name: "rfqStop",
                columns: table => new
                {
                    RfqStopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqStopDetailId = table.Column<int>(type: "int", nullable: false),
                    StopLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StopLocationLat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StopLocationLong = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rfqStop", x => x.RfqStopId);
                });

            migrationBuilder.CreateTable(
                name: "rfqVendor",
                columns: table => new
                {
                    RfqVendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RfqDetailsId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    VendorRating = table.Column<int>(type: "int", nullable: false),
                    WhatsAppNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rfqVendor", x => x.RfqVendorId);
                });
        }
    }
}
