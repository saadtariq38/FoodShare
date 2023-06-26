using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShare.Migrations
{
    /// <inheritdoc />
    public partial class removedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
