using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShare.Migrations
{
    /// <inheritdoc />
    public partial class ChnagedNameRequestStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Requests",
                newName: "RequestStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestStatus",
                table: "Requests",
                newName: "Status");
        }
    }
}
