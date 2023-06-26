using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShare.Migrations
{
    /// <inheritdoc />
    public partial class AddedShareDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Shares_ShareId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Shares_Allergens_AllergenId",
                table: "Shares");

            migrationBuilder.DropForeignKey(
                name: "FK_Shares_FoodTypes_FoodTypeId",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Shares_AllergenId",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Shares_FoodTypeId",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ShareId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_UserId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTypeId",
                table: "Shares",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AllergenId",
                table: "Shares",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FoodTypeId",
                table: "Shares",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AllergenId",
                table: "Shares",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shares_AllergenId",
                table: "Shares",
                column: "AllergenId");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_FoodTypeId",
                table: "Shares",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ShareId",
                table: "Requests",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Shares_ShareId",
                table: "Requests",
                column: "ShareId",
                principalTable: "Shares",
                principalColumn: "ShareId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_Allergens_AllergenId",
                table: "Shares",
                column: "AllergenId",
                principalTable: "Allergens",
                principalColumn: "AllergenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_FoodTypes_FoodTypeId",
                table: "Shares",
                column: "FoodTypeId",
                principalTable: "FoodTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
