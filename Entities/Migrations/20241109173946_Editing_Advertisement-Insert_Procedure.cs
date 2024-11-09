using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Editing_AdvertisementInsert_Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"ALTER PROCEDURE [dbo].[InsertAdvertisement]
              (@Id uniqueidentifier, @CityId bigint, @Gender nvarchar(40),
               @MilitaryServiceStatus nvarchar(50), @LeastYearsOfExperience int,
               @LeastAcademicDegree nvarchar(50), @Description nvarchar(700), @Title nvarchar(100),
               @JobCategoryId uniqueidentifier, @IsVerified bit, @CompanyId uniqueidentifier,
               @NotVerificationDescription nvarchar(700), @SalaryID int, @TypeOfCooperation nvarchar(50), @EditionStatus uniqueidentifier)
               AS BEGIN

               INSERT INTO [dbo].[Advertisements] (Id, CityId, Gender, MilitaryServiceStatus,
               LeastYearsOfExperience, LeastAcademicDegree, Description, Title, JobCategoryId,
               IsVerified, CompanyId, NotVerificationDescription, SalaryID, TypeOfCooperation, EditionStatus)
               VALUES (@Id, @CityId, @Gender, @MilitaryServiceStatus, @LeastYearsOfExperience,
               @LeastAcademicDegree, @Description, @Title, @JobCategoryId, @IsVerified, @CompanyId,
               @NotVerificationDescription, @SalaryID, @TypeOfCooperation, @EditionStatus)
 
               END";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"ALTER PROCEDURE [dbo].[InsertAdvertisement]
              (@Id uniqueidentifier, @CityId bigint, @Gender nvarchar(40),
               @MilitaryServiceStatus nvarchar(50), @LeastYearsOfExperience int,
               @LeastAcademicDegree nvarchar(50), @Description nvarchar(700), @Title nvarchar(100),
               @JobCategoryId uniqueidentifier, @IsVerified bit, @CompanyId uniqueidentifier,
               @NotVerificationDescription nvarchar(700), @SalaryID int, @TypeOfCooperation nvarchar(50))
               AS BEGIN

               INSERT INTO [dbo].[Advertisements] (Id, CityId, Gender, MilitaryServiceStatus,
               LeastYearsOfExperience, LeastAcademicDegree, Description, Title, JobCategoryId,
               IsVerified, CompanyId, NotVerificationDescription, SalaryID, TypeOfCooperation)
               VALUES (@Id, @CityId, @Gender, @MilitaryServiceStatus, @LeastYearsOfExperience,
               @LeastAcademicDegree, @Description, @Title, @JobCategoryId, @IsVerified, @CompanyId,
               @NotVerificationDescription, @SalaryID, @TypeOfCooperation)
 
               END";

            migrationBuilder.Sql(procedure);
        }
    }
}
