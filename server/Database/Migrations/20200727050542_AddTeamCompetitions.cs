using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddTeamCompetitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamCompetitions",
                columns: table => new
                {
                    Year = table.Column<string>(maxLength: 4, nullable: false),
                    TeamName = table.Column<string>(maxLength: 255, nullable: false),
                    CompetitionName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCompetitions", x => new { x.Year, x.TeamName, x.CompetitionName });
                    table.ForeignKey(
                        name: "FK_TeamCompetitions_Competitions_CompetitionName_Year",
                        columns: x => new { x.CompetitionName, x.Year },
                        principalTable: "Competitions",
                        principalColumns: new[] { "Name", "Year" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCompetitions_Teams_TeamName_Year",
                        columns: x => new { x.TeamName, x.Year },
                        principalTable: "Teams",
                        principalColumns: new[] { "Name", "Year" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamCompetitions_CompetitionName_Year",
                table: "TeamCompetitions",
                columns: new[] { "CompetitionName", "Year" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamCompetitions_TeamName_Year",
                table: "TeamCompetitions",
                columns: new[] { "TeamName", "Year" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamCompetitions");
        }
    }
}
