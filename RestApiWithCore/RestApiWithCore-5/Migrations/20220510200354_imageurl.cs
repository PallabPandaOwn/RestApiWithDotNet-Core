using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiWithCore_5.Migrations
{
    public partial class imageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "language",
                table: "Songs",
                newName: "Language");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Songs",
                newName: "language");
        }
    }
}
