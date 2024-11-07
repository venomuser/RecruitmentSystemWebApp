using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Salary_And_Cooperation_Addition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalaryAmount",
                table: "Advertisements",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryID",
                table: "Advertisements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfCooperation",
                table: "Advertisements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalaryAmount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryExplanation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAmount", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_SalaryID",
                table: "Advertisements",
                column: "SalaryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_SalaryAmount_SalaryID",
                table: "Advertisements",
                column: "SalaryID",
                principalTable: "SalaryAmount",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_SalaryAmount_SalaryID",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "SalaryAmount");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_SalaryID",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "SalaryAmount",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "SalaryID",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "TypeOfCooperation",
                table: "Advertisements");
        }
    }
}
