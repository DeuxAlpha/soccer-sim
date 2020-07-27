using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddCountryTeamFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Teams",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryName_Year",
                table: "Teams",
                columns: new[] { "CountryName", "Year" });

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Countries_CountryName_Year",
                table: "Teams",
                columns: new[] { "CountryName", "Year" },
                principalTable: "Countries",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Countries_CountryName_Year",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CountryName_Year",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Teams");
        }
    }
}
