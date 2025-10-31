using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library_management_system.Migrations
{
    /// <inheritdoc />
    public partial class AddReaaltionShipsBetweenUserandLibrian : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Libraryid",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Libraryid",
                table: "Users",
                column: "Libraryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Libraries_Libraryid",
                table: "Users",
                column: "Libraryid",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Libraries_Libraryid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Libraryid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Libraryid",
                table: "Users");
        }
    }
}
