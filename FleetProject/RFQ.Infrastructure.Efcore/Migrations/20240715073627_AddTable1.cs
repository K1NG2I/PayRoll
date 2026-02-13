using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class AddTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsAppNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PANNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCompanyId = table.Column<int>(type: "int", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "rfq",
                columns: table => new
                {
                    RfqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RfqNoPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RfqNo = table.Column<int>(type: "int", nullable: false),
                    RfqDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RfqSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RfqExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RfqTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleReqNo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RfqPriorityId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rfq", x => x.RfqId);
                });

            migrationBuilder.CreateTable(
                name: "rfqDetails",
                columns: table => new
                {
                    RfqDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqId = table.Column<int>(type: "int", nullable: false),
                    FromLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLocLat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLocLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocLat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RfqOnId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleCount = table.Column<int>(type: "int", nullable: false),
                    TotalQty = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    MaxCosting = table.Column<int>(type: "int", nullable: false),
                    DetentionPerDay = table.Column<int>(type: "int", nullable: false),
                    DetentionFreeDay = table.Column<int>(type: "int", nullable: false),
                    PackingTypeId = table.Column<int>(type: "int", nullable: false),
                    SpecialInstruction = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    RfqDetailsId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    VendorRating = table.Column<int>(type: "int", nullable: false),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsAppNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rfqVendor", x => x.RfqVendorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "rfq");

            migrationBuilder.DropTable(
                name: "rfqDetails");

            migrationBuilder.DropTable(
                name: "rfqStop");

            migrationBuilder.DropTable(
                name: "rfqVendor");
        }
    }
}
