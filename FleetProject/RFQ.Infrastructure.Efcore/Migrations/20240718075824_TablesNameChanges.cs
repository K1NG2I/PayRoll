using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class TablesNameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyConfigrations");

            migrationBuilder.CreateTable(
                name: "companyMasterConfigrations",
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
                    table.PrimaryKey("PK_companyMasterConfigrations", x => x.CompanyConfigrationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyMasterConfigrations");

            migrationBuilder.CreateTable(
                name: "companyConfigrations",
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
                    table.PrimaryKey("PK_companyConfigrations", x => x.CompanyConfigrationId);
                });
        }
    }
}
