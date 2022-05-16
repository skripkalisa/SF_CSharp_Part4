using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSBlog.Data.Migrations
{
    public partial class dbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AuthorId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Articles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AuthorId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
