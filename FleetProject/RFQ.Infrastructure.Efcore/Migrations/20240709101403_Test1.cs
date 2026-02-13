using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFQ.Infrastructure.Efcore.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Register");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Register_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Register_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Register_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Register_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
