using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativeCenterCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatsToSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentSeats",
                table: "Schedules",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxSeats",
                table: "Schedules",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentSeats",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "MaxSeats",
                table: "Schedules");
        }
    }
}
