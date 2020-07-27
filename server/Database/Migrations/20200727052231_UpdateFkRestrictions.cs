using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class UpdateFkRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Countries_CountryName_Year",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamCompetitions_Competitions_CompetitionName_Year",
                table: "TeamCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamCompetitions_Teams_TeamName_Year",
                table: "TeamCompetitions");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Countries_CountryName_Year",
                table: "Competitions",
                columns: new[] { "CountryName", "Year" },
                principalTable: "Countries",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamCompetitions_Competitions_CompetitionName_Year",
                table: "TeamCompetitions",
                columns: new[] { "CompetitionName", "Year" },
                principalTable: "Competitions",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamCompetitions_Teams_TeamName_Year",
                table: "TeamCompetitions",
                columns: new[] { "TeamName", "Year" },
                principalTable: "Teams",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Countries_CountryName_Year",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamCompetitions_Competitions_CompetitionName_Year",
                table: "TeamCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamCompetitions_Teams_TeamName_Year",
                table: "TeamCompetitions");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Countries_CountryName_Year",
                table: "Competitions",
                columns: new[] { "CountryName", "Year" },
                principalTable: "Countries",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamCompetitions_Competitions_CompetitionName_Year",
                table: "TeamCompetitions",
                columns: new[] { "CompetitionName", "Year" },
                principalTable: "Competitions",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamCompetitions_Teams_TeamName_Year",
                table: "TeamCompetitions",
                columns: new[] { "TeamName", "Year" },
                principalTable: "Teams",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
