using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library_management_system.Migrations
{
    /// <inheritdoc />
    public partial class addrealtionshipBetweenuserandcart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Books_BookId",
                table: "BorrowedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Users_UserId",
                table: "BorrowedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks");

            migrationBuilder.RenameTable(
                name: "BorrowedBooks",
                newName: "BuyedBooks");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowedBooks_UserId_BookId_BuyDate",
                table: "BuyedBooks",
                newName: "IX_BuyedBooks_UserId_BookId_BuyDate");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowedBooks_BookId",
                table: "BuyedBooks",
                newName: "IX_BuyedBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyedBooks",
                table: "BuyedBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyedBooks_Books_BookId",
                table: "BuyedBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyedBooks_Users_UserId",
                table: "BuyedBooks",
                column: "UserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyedBooks_Books_BookId",
                table: "BuyedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyedBooks_Users_UserId",
                table: "BuyedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyedBooks",
                table: "BuyedBooks");

            migrationBuilder.RenameTable(
                name: "BuyedBooks",
                newName: "BorrowedBooks");

            migrationBuilder.RenameIndex(
                name: "IX_BuyedBooks_UserId_BookId_BuyDate",
                table: "BorrowedBooks",
                newName: "IX_BorrowedBooks_UserId_BookId_BuyDate");

            migrationBuilder.RenameIndex(
                name: "IX_BuyedBooks_BookId",
                table: "BorrowedBooks",
                newName: "IX_BorrowedBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowedBooks",
                table: "BorrowedBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Books_BookId",
                table: "BorrowedBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Users_UserId",
                table: "BorrowedBooks",
                column: "UserId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
