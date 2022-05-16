using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSBlog.Data.Migrations
{
    public partial class article_crud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_BlogUsers_AuthorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_BlogUsers_BlogUserId",
                table: "UserRole");

            migrationBuilder.DropTable(
                name: "BlogUsers");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Articles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_AspNetUsers_BlogUserId",
                table: "UserRole",
                column: "BlogUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_BlogUserId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Articles");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BlogUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Login = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Registered = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_BlogUsers_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "BlogUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_BlogUsers_BlogUserId",
                table: "UserRole",
                column: "BlogUserId",
                principalTable: "BlogUsers",
                principalColumn: "Id");
        }
    }
}
