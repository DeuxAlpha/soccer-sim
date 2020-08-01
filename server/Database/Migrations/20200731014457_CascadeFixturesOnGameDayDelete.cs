using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class CascadeFixturesOnGameDayDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueFixtures_LeagueGameDays_LeagueName_Season_GameDayNumber",
                table: "LeagueFixtures");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueFixtures_LeagueGameDays_LeagueName_Season_GameDayNumber",
                table: "LeagueFixtures",
                columns: new[] { "LeagueName", "Season", "GameDayNumber" },
                principalTable: "LeagueGameDays",
                principalColumns: new[] { "LeagueName", "Season", "GameDayNumber" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueFixtures_LeagueGameDays_LeagueName_Season_GameDayNumber",
                table: "LeagueFixtures");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueFixtures_LeagueGameDays_LeagueName_Season_GameDayNumber",
                table: "LeagueFixtures",
                columns: new[] { "LeagueName", "Season", "GameDayNumber" },
                principalTable: "LeagueGameDays",
                principalColumns: new[] { "LeagueName", "Season", "GameDayNumber" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
