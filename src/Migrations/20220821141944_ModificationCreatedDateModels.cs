using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.API.Migrations
{
    public partial class ModificationCreatedDateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookModel_Author_Table_AuthorId",
                table: "BookModel");

            migrationBuilder.DropIndex(
                name: "IX_BookModel_AuthorId",
                table: "BookModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BookModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Author_Table",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BookModel");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Author_Table");

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
    }
}
