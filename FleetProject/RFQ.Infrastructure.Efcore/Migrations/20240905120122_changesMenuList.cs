using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class changesMenuList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "menuLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ViewUrl",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewUrl",
                table: "menuLists");

            migrationBuilder.AlterColumn<string>(
                name: "StatusId",
                table: "menuLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
