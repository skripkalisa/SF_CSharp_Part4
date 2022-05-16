using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSBlog.Data.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

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

            migrationBuilder.AddColumn<Guid>(
                name: "BlogUserId",
                table: "AspNetRoles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetRoles",
                type: "TEXT",
                maxLength: 16,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Login = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Registered = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_BlogUserId",
                table: "AspNetRoles",
                column: "BlogUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_BlogUsers_BlogUserId",
                table: "AspNetRoles",
                column: "BlogUserId",
                principalTable: "BlogUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_BlogUsers_BlogUserId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BlogUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_BlogUserId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "BlogUserId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetRoles");

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

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BlogUserId = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_AspNetUsers_BlogUserId",
                        column: x => x.BlogUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_BlogUserId",
                table: "UserRole",
                column: "BlogUserId");
        }
    }
}
