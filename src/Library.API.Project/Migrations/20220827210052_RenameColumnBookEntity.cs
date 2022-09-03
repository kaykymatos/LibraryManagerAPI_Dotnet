using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Project.API.Migrations
{
    public partial class RenameColumnBookEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookDescription",
                table: "Books_Table",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books_Table",
                newName: "BookDescription");
        }
    }
}
