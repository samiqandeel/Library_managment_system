using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library_management_system.Migrations
{
    /// <inheritdoc />
    public partial class added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Libraries_LibraryId",
                schema: "security",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                schema: "security",
                table: "Users",
                newName: "Libraryid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LibraryId",
                schema: "security",
                table: "Users",
                newName: "IX_Users_Libraryid");

            migrationBuilder.AlterColumn<int>(
                name: "Libraryid",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Libraries_Libraryid",
                schema: "security",
                table: "Users",
                column: "Libraryid",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Libraries_Libraryid",
                schema: "security",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Libraryid",
                schema: "security",
                table: "Users",
                newName: "LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Libraryid",
                schema: "security",
                table: "Users",
                newName: "IX_Users_LibraryId");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Libraries_LibraryId",
                schema: "security",
                table: "Users",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }
    }
}
