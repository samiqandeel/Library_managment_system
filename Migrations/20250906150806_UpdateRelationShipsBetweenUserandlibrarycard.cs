using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library_management_system.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationShipsBetweenUserandlibrarycard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LibraryCards_UserId",
                table: "LibraryCards");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_UserId",
                table: "LibraryCards",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LibraryCards_UserId",
                table: "LibraryCards");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_UserId",
                table: "LibraryCards",
                column: "UserId",
                unique: true);
        }
    }
}
