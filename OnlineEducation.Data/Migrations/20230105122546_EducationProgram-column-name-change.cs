using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEducation.Data.Migrations
{
    public partial class EducationProgramcolumnnamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPrograms_EducationPrograms_MyProperty",
                table: "SubPrograms");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "SubPrograms",
                newName: "EducationProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_SubPrograms_MyProperty",
                table: "SubPrograms",
                newName: "IX_SubPrograms_EducationProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPrograms_EducationPrograms_EducationProgramId",
                table: "SubPrograms",
                column: "EducationProgramId",
                principalTable: "EducationPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPrograms_EducationPrograms_EducationProgramId",
                table: "SubPrograms");

            migrationBuilder.RenameColumn(
                name: "EducationProgramId",
                table: "SubPrograms",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_SubPrograms_EducationProgramId",
                table: "SubPrograms",
                newName: "IX_SubPrograms_MyProperty");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPrograms_EducationPrograms_MyProperty",
                table: "SubPrograms",
                column: "MyProperty",
                principalTable: "EducationPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
