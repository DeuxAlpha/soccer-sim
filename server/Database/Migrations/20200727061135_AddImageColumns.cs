using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddImageColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Competitions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Competitions");
        }
    }
}
