using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSBlog.Data.Migrations
{
    public partial class views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserRole_UserRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserRoleId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "AspNetUsers",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserRole",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_AspNetUsers_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_UserId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AspNetUsers",
                newName: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserRoleId",
                table: "AspNetUsers",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserRole_UserRoleId",
                table: "AspNetUsers",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
