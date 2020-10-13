using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleTests.Migrations
{
    public partial class DescriptionOfStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Students");
        }
    }
}
