using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSBlog.Data.Migrations
{
    public partial class users15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
