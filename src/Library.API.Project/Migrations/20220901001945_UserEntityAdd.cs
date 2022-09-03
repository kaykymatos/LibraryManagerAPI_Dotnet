using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Project.API.Migrations
{
    public partial class UserEntityAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Books_Table",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Author_Table",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Table_UserEntityId",
                table: "Books_Table",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Author_Table_UserEntityId",
                table: "Author_Table",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Table_UserEntity_UserEntityId",
                table: "Author_Table",
                column: "UserEntityId",
                principalTable: "UserEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Table_UserEntity_UserEntityId",
                table: "Books_Table",
                column: "UserEntityId",
                principalTable: "UserEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Table_UserEntity_UserEntityId",
                table: "Author_Table");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Table_UserEntity_UserEntityId",
                table: "Books_Table");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropIndex(
                name: "IX_Books_Table_UserEntityId",
                table: "Books_Table");

            migrationBuilder.DropIndex(
                name: "IX_Author_Table_UserEntityId",
                table: "Author_Table");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Books_Table");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Author_Table");
        }
    }
}
