using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeCare_Api.Migrations
{
    public partial class editIdTypeInPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patient",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patient",
                newName: "PatientId");
        }
    }
}
