using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RenameFixtureTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueFixtures_Teams_AwayTeamName_Season",
                table: "LeagueFixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueFixtures_Teams_HomeTeamName_Season",
                table: "LeagueFixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueFixtures_LeagueGameDays_LeagueName_Season_GameDayNumber",
                table: "LeagueFixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueGameDays_Leagues_LeagueName_Season",
                table: "LeagueGameDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeagueGameDays",
                table: "LeagueGameDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeagueFixtures",
                table: "LeagueFixtures");

            migrationBuilder.RenameTable(
                name: "LeagueGameDays",
                newName: "GameDays");

            migrationBuilder.RenameTable(
                name: "LeagueFixtures",
                newName: "Fixtures");

            migrationBuilder.RenameIndex(
                name: "IX_LeagueFixtures_HomeTeamName_Season",
                table: "Fixtures",
                newName: "IX_Fixtures_HomeTeamName_Season");

            migrationBuilder.RenameIndex(
                name: "IX_LeagueFixtures_AwayTeamName_Season",
                table: "Fixtures",
                newName: "IX_Fixtures_AwayTeamName_Season");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDays",
                table: "GameDays",
                columns: new[] { "LeagueName", "Season", "GameDayNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fixtures",
                table: "Fixtures",
                columns: new[] { "LeagueName", "Season", "GameDayNumber", "HomeTeamName", "AwayTeamName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Teams_AwayTeamName_Season",
                table: "Fixtures",
                columns: new[] { "AwayTeamName", "Season" },
                principalTable: "Teams",
                principalColumns: new[] { "Name", "Season" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Teams_HomeTeamName_Season",
                table: "Fixtures",
                columns: new[] { "HomeTeamName", "Season" },
                principalTable: "Teams",
                principalColumns: new[] { "Name", "Season" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_GameDays_LeagueName_Season_GameDayNumber",
                table: "Fixtures",
                columns: new[] { "LeagueName", "Season", "GameDayNumber" },
                principalTable: "GameDays",
                principalColumns: new[] { "LeagueName", "Season", "GameDayNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDays_Leagues_LeagueName_Season",
                table: "GameDays",
                columns: new[] { "LeagueName", "Season" },
                principalTable: "Leagues",
                principalColumns: new[] { "Name", "Season" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_AwayTeamName_Season",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_HomeTeamName_Season",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_GameDays_LeagueName_Season_GameDayNumber",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDays_Leagues_LeagueName_Season",
                table: "GameDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDays",
                table: "GameDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fixtures",
                table: "Fixtures");

            migrationBuilder.RenameTable(
                name: "GameDays",
                newName: "LeagueGameDays");

            migrationBuilder.RenameTable(
                name: "Fixtures",
                newName: "LeagueFixtures");

            migrationBuilder.RenameIndex(
                name: "IX_Fixtures_HomeTeamName_Season",
                table: "LeagueFixtures",
                newName: "IX_LeagueFixtures_HomeTeamName_Season");

            migrationBuilder.RenameIndex(
                name: "IX_Fixtures_AwayTeamName_Season",
                table: "LeagueFixtures",
                newName: "IX_LeagueFixtures_AwayTeamName_Season");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeagueGameDays",
                table: "LeagueGameDays",
                columns: new[] { "LeagueName", "Season", "GameDayNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeagueFixtures",
                table: "LeagueFixtures",
                columns: new[] { "LeagueName", "Season", "GameDayNumber", "HomeTeamName", "AwayTeamName" });

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueFixtures_Teams_AwayTeamName_Season",
                table: "LeagueFixtures",
                columns: new[] { "AwayTeamName", "Season" },
                principalTable: "Teams",
                principalColumns: new[] { "Name", "Season" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueFixtures_Teams_HomeTeamName_Season",
                table: "LeagueFixtures",
                columns: new[] { "HomeTeamName", "Season" },
                principalTable: "Teams",
                principalColumns: new[] { "Name", "Season" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueFixtures_LeagueGameDays_LeagueName_Season_GameDayNumber",
                table: "LeagueFixtures",
                columns: new[] { "LeagueName", "Season", "GameDayNumber" },
                principalTable: "LeagueGameDays",
                principalColumns: new[] { "LeagueName", "Season", "GameDayNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueGameDays_Leagues_LeagueName_Season",
                table: "LeagueGameDays",
                columns: new[] { "LeagueName", "Season" },
                principalTable: "Leagues",
                principalColumns: new[] { "Name", "Season" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
