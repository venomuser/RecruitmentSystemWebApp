using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class SalaryAmountCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_SalaryAmount_SalaryID",
                table: "Advertisements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryAmount",
                table: "SalaryAmount");

            migrationBuilder.DropColumn(
                name: "SalaryAmount",
                table: "Advertisements");

            migrationBuilder.RenameTable(
                name: "SalaryAmount",
                newName: "SalaryAmounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryAmounts",
                table: "SalaryAmounts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "SalaryAmounts",
                columns: new[] { "Id", "SalaryExplanation" },
                values: new object[,]
                {
                    { 1, "1 الی 2 میلیون تومان" },
                    { 2, "2 الی 3 میلیون تومان" },
                    { 3, "3 الی 5 میلیون تومان" },
                    { 4, "5 الی 10 میلیون تومان" },
                    { 5, "10 الی 20 میلیون تومان" },
                    { 6, "20 الی 40 میلیون تومان" },
                    { 7, "40 الی 60 میلیون تومان" },
                    { 8, "60 الی 80 میلیون تومان" },
                    { 9, "80 الی 100 میلیون تومان" },
                    { 10, "100 میلیون و بالاتر" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_SalaryAmounts_SalaryID",
                table: "Advertisements",
                column: "SalaryID",
                principalTable: "SalaryAmounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_SalaryAmounts_SalaryID",
                table: "Advertisements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryAmounts",
                table: "SalaryAmounts");

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SalaryAmounts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameTable(
                name: "SalaryAmounts",
                newName: "SalaryAmount");

            migrationBuilder.AddColumn<string>(
                name: "SalaryAmount",
                table: "Advertisements",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryAmount",
                table: "SalaryAmount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_SalaryAmount_SalaryID",
                table: "Advertisements",
                column: "SalaryID",
                principalTable: "SalaryAmount",
                principalColumn: "Id");
        }
    }
}
