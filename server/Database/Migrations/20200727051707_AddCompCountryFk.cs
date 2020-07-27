using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddCompCountryFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Competitions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CountryName_Year",
                table: "Competitions",
                columns: new[] { "CountryName", "Year" });

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Countries_CountryName_Year",
                table: "Competitions",
                columns: new[] { "CountryName", "Year" },
                principalTable: "Countries",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Countries_CountryName_Year",
                table: "Competitions");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_CountryName_Year",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Competitions");
        }
    }
}
