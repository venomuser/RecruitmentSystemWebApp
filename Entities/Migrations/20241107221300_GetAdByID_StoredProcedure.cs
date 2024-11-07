using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class GetAdByID_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string GetAdById_Stored_Proc = @"CREATE PROCEDURE [dbo].[GetAdvertisementById] (@Id uniqueidentifier)
            AS BEGIN
            SELECT * FROM [dbo].[Advertisements] WHERE [dbo].[Advertisements].Id = @Id
            END";
            migrationBuilder.Sql(GetAdById_Stored_Proc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string GetAdById_Stored_Proc = @"DROP PROCEDURE [dbo].[GetAdvertisementById]";
            migrationBuilder.Sql(GetAdById_Stored_Proc);
        }
    }
}
