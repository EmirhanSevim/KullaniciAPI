using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KullanicilarAPI.Migrations
{
    /// <inheritdoc />
    public partial class Changingkullanicitouserr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Kullanıcılar_userId",
                table: "Bookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanıcılar",
                table: "Kullanıcılar");

            migrationBuilder.RenameTable(
                name: "Kullanıcılar",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Users_userId",
                table: "Bookmarks",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Users_userId",
                table: "Bookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Kullanıcılar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanıcılar",
                table: "Kullanıcılar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Kullanıcılar_userId",
                table: "Bookmarks",
                column: "userId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id");
        }
    }
}
