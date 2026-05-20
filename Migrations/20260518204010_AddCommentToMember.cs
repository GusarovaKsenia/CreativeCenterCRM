using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativeCenterCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Members",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Members");
        }
    }
}
