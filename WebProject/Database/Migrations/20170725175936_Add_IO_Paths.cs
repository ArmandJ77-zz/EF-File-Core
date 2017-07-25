using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Add_IO_Paths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "FileConfigurations",
                newName: "OutputPath");

            migrationBuilder.AddColumn<string>(
                name: "InputPath",
                table: "FileConfigurations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputPath",
                table: "FileConfigurations");

            migrationBuilder.RenameColumn(
                name: "OutputPath",
                table: "FileConfigurations",
                newName: "Path");
        }
    }
}
