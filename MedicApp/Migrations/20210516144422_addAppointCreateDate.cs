using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicApp.Migrations
{
    public partial class addAppointCreateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "ClientAppointment",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "ClientAppointment");
        }
    }
}
