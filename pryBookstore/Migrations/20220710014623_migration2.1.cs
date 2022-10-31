using Microsoft.EntityFrameworkCore.Migrations;

namespace pryBookstore.Migrations
{
    public partial class migration21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_categoryID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_categoryID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "ID_CategoryId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ID_CategoryId",
                table: "Books",
                column: "ID_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_ID_CategoryId",
                table: "Books",
                column: "ID_CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_ID_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ID_CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ID_CategoryId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_categoryID",
                table: "Books",
                column: "categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_categoryID",
                table: "Books",
                column: "categoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
