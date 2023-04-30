using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentScooter.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class ConfPricePerMinute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PricePerMinute",
                table: "scooters",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerMinute",
                table: "scooters");
        }
    }
}
