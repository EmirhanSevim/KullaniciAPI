using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KullanıcılarAPI.Migrations
{
    /// <inheritdoc />
    public partial class denemee2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Categories_CategoryId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_CategoryId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Bookmarks");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "Bookmarks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_categoryId",
                table: "Bookmarks",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Categories_categoryId",
                table: "Bookmarks",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Categories_categoryId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_categoryId",
                table: "Bookmarks");

            migrationBuilder.AlterColumn<string>(
                name: "categoryId",
                table: "Bookmarks",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Bookmarks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_CategoryId",
                table: "Bookmarks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Categories_CategoryId",
                table: "Bookmarks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
