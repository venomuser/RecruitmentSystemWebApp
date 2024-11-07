using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Removing_Invalid_Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvalidDescription",
                table: "Advertisements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvalidDescription",
                table: "Advertisements",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: true);
        }
    }
}
