using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentScooter.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class ConfIsInUse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInUse",
                table: "scooters",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInUse",
                table: "scooters");
        }
    }
}
