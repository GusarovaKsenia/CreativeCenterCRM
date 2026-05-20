using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativeCenterCRM.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentWithClubAndMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Payments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClubId",
                table: "Payments",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clubs_ClubId",
                table: "Payments",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clubs_ClubId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ClubId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Payments");
        }
    }
}
