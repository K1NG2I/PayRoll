using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "link_Group",
                columns: table => new
                {
                    LinkGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    LinkIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link_Group", x => x.LinkGroupId);
                });

            migrationBuilder.CreateTable(
                name: "link_Item",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingQuery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link_Item", x => x.LinkId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "link_Group");

            migrationBuilder.DropTable(
                name: "link_Item");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
