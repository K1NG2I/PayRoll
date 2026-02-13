using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class AddTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "internalMaster",
                columns: table => new
                {
                    InternalMasterId = table.Column<int>(type: "int", nullable: false),
                    MasterTypeId = table.Column<int>(type: "int", nullable: false),
                    InternalMasterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "internalMasterTypes",
                columns: table => new
                {
                    MasterTypeId = table.Column<int>(type: "int", nullable: false),
                    MasterTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "rate",
                columns: table => new
                {
                    RfqRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqDetailId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TotalHireCost = table.Column<int>(type: "int", nullable: false),
                    DetentionPerDay = table.Column<int>(type: "int", nullable: false),
                    DetentionFreeDay = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rate", x => x.RfqRateId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "internalMaster");

            migrationBuilder.DropTable(
                name: "internalMasterTypes");

            migrationBuilder.DropTable(
                name: "rate");
        }
    }
}
