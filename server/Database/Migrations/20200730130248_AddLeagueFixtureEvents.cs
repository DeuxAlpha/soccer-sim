using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddLeagueFixtureEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwayPossession",
                table: "LeagueFixtures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomePossession",
                table: "LeagueFixtures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LeagueFixtureEvents",
                columns: table => new
                {
                    HomeTeamName = table.Column<string>(maxLength: 255, nullable: false),
                    AwayTeamName = table.Column<string>(maxLength: 255, nullable: false),
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    LeagueName = table.Column<string>(maxLength: 255, nullable: false),
                    GameDayNumber = table.Column<int>(nullable: false),
                    Minute = table.Column<int>(nullable: false),
                    AddedMinute = table.Column<int>(nullable: true),
                    IsGoal = table.Column<bool>(nullable: false),
                    IsShotOnGoal = table.Column<bool>(nullable: false),
                    EventTeamName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueFixtureEvents", x => new { x.LeagueName, x.Season, x.GameDayNumber, x.HomeTeamName, x.AwayTeamName });
                    table.ForeignKey(
                        name: "FK_LeagueFixtureEvents_Teams_EventTeamName_Season",
                        columns: x => new { x.EventTeamName, x.Season },
                        principalTable: "Teams",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueFixtureEvents_LeagueFixtures_LeagueName_Season_GameDayNumber_HomeTeamName_AwayTeamName",
                        columns: x => new { x.LeagueName, x.Season, x.GameDayNumber, x.HomeTeamName, x.AwayTeamName },
                        principalTable: "LeagueFixtures",
                        principalColumns: new[] { "LeagueName", "Season", "GameDayNumber", "HomeTeamName", "AwayTeamName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueFixtureEvents_EventTeamName_Season",
                table: "LeagueFixtureEvents",
                columns: new[] { "EventTeamName", "Season" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueFixtureEvents");

            migrationBuilder.DropColumn(
                name: "AwayPossession",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomePossession",
                table: "LeagueFixtures");
        }
    }
}
