using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSBlog.Data.Migrations
{
    public partial class usersviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
