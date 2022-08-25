using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.API.Migrations
{
    public partial class AuthorForeigKkeyModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookModel_AuthorId",
                table: "BookModel",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookModel_Author_Table_AuthorId",
                table: "BookModel",
                column: "AuthorId",
                principalTable: "Author_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_Author_Table_AuthorId",
                table: "BookModel");

            migrationBuilder.DropIndex(
                name: "IX_BookModel_AuthorId",
                table: "BookModel");
        }
    }
}
