using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentScooter.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class ConfRentTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RentTime",
                table: "rents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnTime",
                table: "rents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentTime",
                table: "rents");

            migrationBuilder.DropColumn(
                name: "ReturnTime",
                table: "rents");
        }
    }
}
