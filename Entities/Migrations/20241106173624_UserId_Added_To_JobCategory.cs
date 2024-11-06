using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class UserId_Added_To_JobCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "JobCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobCategories_UserID",
                table: "JobCategories",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCategories_AspNetUsers_UserID",
                table: "JobCategories",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCategories_AspNetUsers_UserID",
                table: "JobCategories");

            migrationBuilder.DropIndex(
                name: "IX_JobCategories_UserID",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "JobCategories");
        }
    }
}
