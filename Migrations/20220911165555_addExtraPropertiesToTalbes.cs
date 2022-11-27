using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeCare_Api.Migrations
{
    public partial class addExtraPropertiesToTalbes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[FirstName] + ' ' + [LastName]");

            migrationBuilder.AddColumn<string>(
                name: "Reservation",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Title] + ' ' + [DayOfWeek]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Reservation",
                table: "Appointments");
        }
    }
}
