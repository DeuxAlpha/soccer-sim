using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddProgressChancesMinMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxProgressChance",
                table: "Leagues",
                nullable: false,
                defaultValue: 70.0);

            migrationBuilder.AddColumn<double>(
                name: "MinProgressChance",
                table: "Leagues",
                nullable: false,
                defaultValue: 30.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxProgressChance",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "MinProgressChance",
                table: "Leagues");
        }
    }
}
