using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.API.Project.Migrations
{
    public partial class DatabaseModificationsForeignKeyBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_Author_Table_AuthorId",
                table: "BookModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel");

            migrationBuilder.RenameTable(
                name: "BookModel",
                newName: "Books_Table");

            migrationBuilder.RenameIndex(
                name: "IX_BookModel_AuthorId",
                table: "Books_Table",
                newName: "IX_Books_Table_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books_Table",
                table: "Books_Table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Table_Author_Table_AuthorId",
                table: "Books_Table",
                column: "AuthorId",
                principalTable: "Author_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Table_Author_Table_AuthorId",
                table: "Books_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books_Table",
                table: "Books_Table");

            migrationBuilder.RenameTable(
                name: "Books_Table",
                newName: "BookModel");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Table_AuthorId",
                table: "BookModel",
                newName: "IX_BookModel_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookModel",
                table: "BookModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookModel_Author_Table_AuthorId",
                table: "BookModel",
                column: "AuthorId",
                principalTable: "Author_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
