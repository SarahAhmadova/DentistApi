using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicApp.Migrations
{
    public partial class addAppointAccept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "ClientAppointment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "ClientAppointment");
        }
    }
}
