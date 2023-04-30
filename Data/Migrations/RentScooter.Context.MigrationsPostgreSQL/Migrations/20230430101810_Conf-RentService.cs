using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentScooter.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class ConfRentService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalRevenue",
                table: "rents",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRevenue",
                table: "rents");
        }
    }
}
