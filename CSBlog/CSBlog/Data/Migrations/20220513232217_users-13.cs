using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSBlog.Data.Migrations
{
    public partial class users13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "AspNetUsers");
        }
    }
}
