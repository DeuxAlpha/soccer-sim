using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddCompetitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ShotAccuracyModifier = table.Column<double>(nullable: false),
                    PaceModifier = table.Column<double>(nullable: false),
                    MaxHomeAdvantage = table.Column<double>(nullable: false),
                    MaxAwayDisadvantage = table.Column<double>(nullable: false),
                    ActionsPerMinute = table.Column<int>(nullable: false),
                    MaxProgressChance = table.Column<double>(nullable: false),
                    MinProgressChance = table.Column<double>(nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 10, nullable: true),
                    CompetitionType = table.Column<string>(maxLength: 100, nullable: false),
                    TournamentOnNeutralGrounds = table.Column<bool>(nullable: false, defaultValue: false),
                    ContinentName = table.Column<string>(maxLength: 255, nullable: true),
                    CountryName = table.Column<string>(maxLength: 255, nullable: true),
                    DivisionName = table.Column<string>(maxLength: 255, nullable: true),
                    LeagueName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => new { x.Name, x.Season });
                    table.ForeignKey(
                        name: "FK_Competitions_Continents_ContinentName_Season",
                        columns: x => new { x.ContinentName, x.Season },
                        principalTable: "Continents",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Countries_CountryName_Season",
                        columns: x => new { x.CountryName, x.Season },
                        principalTable: "Countries",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Divisions_DivisionName_Season",
                        columns: x => new { x.DivisionName, x.Season },
                        principalTable: "Divisions",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Leagues_LeagueName_Season",
                        columns: x => new { x.LeagueName, x.Season },
                        principalTable: "Leagues",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionRounds",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    CompetitionName = table.Column<string>(maxLength: 255, nullable: false),
                    Round = table.Column<int>(nullable: false),
                    ReverseFixtureStructure = table.Column<string>(nullable: false, defaultValue: "Default"),
                    ComparisonRule = table.Column<string>(nullable: false, defaultValue: "Default")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionRounds", x => new { x.CompetitionName, x.Season, x.Round });
                    table.ForeignKey(
                        name: "FK_CompetitionRounds_Competitions_CompetitionName_Season",
                        columns: x => new { x.CompetitionName, x.Season },
                        principalTable: "Competitions",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionGroups",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    CompetitionName = table.Column<string>(maxLength: 255, nullable: false),
                    RoundNumber = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 100, nullable: false),
                    Rounds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionGroups", x => new { x.CompetitionName, x.Season, x.RoundNumber, x.GroupName });
                    table.ForeignKey(
                        name: "FK_CompetitionGroups_CompetitionRounds_CompetitionName_Season_RoundNumber",
                        columns: x => new { x.CompetitionName, x.Season, x.RoundNumber },
                        principalTable: "CompetitionRounds",
                        principalColumns: new[] { "CompetitionName", "Season", "Round" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionGameDays",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    CompetitionName = table.Column<string>(maxLength: 255, nullable: false),
                    RoundNumber = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 100, nullable: false),
                    GameDayNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionGameDays", x => new { x.CompetitionName, x.Season, x.RoundNumber, x.GroupName, x.GameDayNumber });
                    table.ForeignKey(
                        name: "FK_CompetitionGameDays_CompetitionGroups_CompetitionName_Season_RoundNumber_GroupName",
                        columns: x => new { x.CompetitionName, x.Season, x.RoundNumber, x.GroupName },
                        principalTable: "CompetitionGroups",
                        principalColumns: new[] { "CompetitionName", "Season", "RoundNumber", "GroupName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionFixtures",
                columns: table => new
                {
                    HomeTeamName = table.Column<string>(maxLength: 255, nullable: false),
                    AwayTeamName = table.Column<string>(maxLength: 255, nullable: false),
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    CompetitionName = table.Column<string>(maxLength: 255, nullable: false),
                    RoundNumber = table.Column<int>(nullable: false),
                    GameDayNumber = table.Column<int>(nullable: false),
                    HalfFieldLength = table.Column<int>(nullable: false, defaultValue: 100),
                    ActionsPerMinute = table.Column<int>(nullable: false, defaultValue: 4),
                    MaxOvertime = table.Column<int>(nullable: false, defaultValue: 8),
                    ShotAccuracyModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    PaceModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    MaxHomeAdvantage = table.Column<double>(nullable: false, defaultValue: 0.0),
                    MaxAwayDisadvantage = table.Column<double>(nullable: false, defaultValue: 0.0),
                    HomePossession = table.Column<int>(nullable: true),
                    AwayPossession = table.Column<int>(nullable: true),
                    GroupName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionFixtures", x => new { x.CompetitionName, x.Season, x.RoundNumber, x.GameDayNumber, x.HomeTeamName, x.AwayTeamName });
                    table.ForeignKey(
                        name: "FK_CompetitionFixtures_Teams_AwayTeamName_Season",
                        columns: x => new { x.AwayTeamName, x.Season },
                        principalTable: "Teams",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetitionFixtures_Competitions_CompetitionName_Season",
                        columns: x => new { x.CompetitionName, x.Season },
                        principalTable: "Competitions",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionFixtures_Teams_HomeTeamName_Season",
                        columns: x => new { x.HomeTeamName, x.Season },
                        principalTable: "Teams",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetitionFixtures_CompetitionGameDays_CompetitionName_Season_RoundNumber_GroupName_GameDayNumber",
                        columns: x => new { x.CompetitionName, x.Season, x.RoundNumber, x.GroupName, x.GameDayNumber },
                        principalTable: "CompetitionGameDays",
                        principalColumns: new[] { "CompetitionName", "Season", "RoundNumber", "GroupName", "GameDayNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionFixtureEvents",
                columns: table => new
                {
                    HomeTeamName = table.Column<string>(maxLength: 255, nullable: false),
                    AwayTeamName = table.Column<string>(maxLength: 255, nullable: false),
                    Minute = table.Column<int>(nullable: false),
                    AddedMinute = table.Column<int>(nullable: false),
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    CompetitionName = table.Column<string>(maxLength: 255, nullable: false),
                    RoundNumber = table.Column<int>(nullable: false),
                    GameDayNumber = table.Column<int>(nullable: false),
                    IsGoal = table.Column<bool>(nullable: false),
                    IsShotOnGoal = table.Column<bool>(nullable: false),
                    EventTeamName = table.Column<string>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionFixtureEvents", x => new { x.CompetitionName, x.Season, x.RoundNumber, x.GameDayNumber, x.HomeTeamName, x.AwayTeamName, x.Minute, x.AddedMinute });
                    table.ForeignKey(
                        name: "FK_CompetitionFixtureEvents_Teams_EventTeamName_Season",
                        columns: x => new { x.EventTeamName, x.Season },
                        principalTable: "Teams",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionFixtureEvents_CompetitionFixtures_CompetitionName_Season_RoundNumber_GameDayNumber_HomeTeamName_AwayTeamName",
                        columns: x => new { x.CompetitionName, x.Season, x.RoundNumber, x.GameDayNumber, x.HomeTeamName, x.AwayTeamName },
                        principalTable: "CompetitionFixtures",
                        principalColumns: new[] { "CompetitionName", "Season", "RoundNumber", "GameDayNumber", "HomeTeamName", "AwayTeamName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionFixtureEvents_EventTeamName_Season",
                table: "CompetitionFixtureEvents",
                columns: new[] { "EventTeamName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionFixtures_AwayTeamName_Season",
                table: "CompetitionFixtures",
                columns: new[] { "AwayTeamName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionFixtures_HomeTeamName_Season",
                table: "CompetitionFixtures",
                columns: new[] { "HomeTeamName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionFixtures_CompetitionName_Season_RoundNumber_GroupName_GameDayNumber",
                table: "CompetitionFixtures",
                columns: new[] { "CompetitionName", "Season", "RoundNumber", "GroupName", "GameDayNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_ContinentName_Season",
                table: "Competitions",
                columns: new[] { "ContinentName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CountryName_Season",
                table: "Competitions",
                columns: new[] { "CountryName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_DivisionName_Season",
                table: "Competitions",
                columns: new[] { "DivisionName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_LeagueName_Season",
                table: "Competitions",
                columns: new[] { "LeagueName", "Season" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionFixtureEvents");

            migrationBuilder.DropTable(
                name: "CompetitionFixtures");

            migrationBuilder.DropTable(
                name: "CompetitionGameDays");

            migrationBuilder.DropTable(
                name: "CompetitionGroups");

            migrationBuilder.DropTable(
                name: "CompetitionRounds");

            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
