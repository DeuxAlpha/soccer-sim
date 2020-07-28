using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => new { x.Name, x.Season });
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 3, nullable: false),
                    AttackStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    DefenseStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    GoalieStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    PotentialPositiveShift = table.Column<double>(nullable: false, defaultValue: 10.0),
                    PotentialPositiveChance = table.Column<double>(nullable: false, defaultValue: 0.10000000000000001),
                    PotentialNegativeShift = table.Column<double>(nullable: false, defaultValue: 10.0),
                    PotentialNegativeChance = table.Column<double>(nullable: false, defaultValue: 0.10000000000000001),
                    MaxPace = table.Column<int>(nullable: false, defaultValue: 40),
                    ShotOnGoalRate = table.Column<double>(nullable: false, defaultValue: 0.40000000000000002),
                    CountryStrengthModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    ContinentName = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => new { x.Name, x.Season });
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentName_Season",
                        columns: x => new { x.ContinentName, x.Season },
                        principalTable: "Continents",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 10, nullable: true),
                    Level = table.Column<int>(nullable: false, defaultValue: 1),
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => new { x.Name, x.Season });
                    table.ForeignKey(
                        name: "FK_Divisions_Countries_CountryName_Season",
                        columns: x => new { x.CountryName, x.Season },
                        principalTable: "Countries",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 10, nullable: true),
                    ShotAccuracyModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    PaceModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    MaxHomeAdvantage = table.Column<double>(nullable: false, defaultValue: 0.0),
                    MaxAwayDisadvantage = table.Column<double>(nullable: false, defaultValue: 0.0),
                    DivisionName = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => new { x.Name, x.Season });
                    table.ForeignKey(
                        name: "FK_Leagues_Divisions_DivisionName_Season",
                        columns: x => new { x.DivisionName, x.Season },
                        principalTable: "Divisions",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueGameDays",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    LeagueName = table.Column<string>(maxLength: 255, nullable: false),
                    GameDayNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueGameDays", x => new { x.LeagueName, x.Season, x.GameDayNumber });
                    table.ForeignKey(
                        name: "FK_LeagueGameDays_Leagues_LeagueName_Season",
                        columns: x => new { x.LeagueName, x.Season },
                        principalTable: "Leagues",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(maxLength: 255, nullable: true),
                    Abbreviation = table.Column<string>(maxLength: 3, nullable: false),
                    AttackStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    DefenseStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    GoalieStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    PotentialPositiveShift = table.Column<double>(nullable: false, defaultValue: 0.0),
                    PotentialPositiveChance = table.Column<double>(nullable: false, defaultValue: 0.0),
                    PotentialNegativeShift = table.Column<double>(nullable: false, defaultValue: 0.0),
                    PotentialNegativeChance = table.Column<double>(nullable: false, defaultValue: 0.0),
                    MaxPace = table.Column<int>(nullable: false, defaultValue: 40),
                    ShotOnGoalRate = table.Column<double>(nullable: false, defaultValue: 0.40000000000000002),
                    LeagueName = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => new { x.Name, x.Season });
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueName_Season",
                        columns: x => new { x.LeagueName, x.Season },
                        principalTable: "Leagues",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueFixtures",
                columns: table => new
                {
                    HomeTeamName = table.Column<string>(maxLength: 255, nullable: false),
                    AwayTeamName = table.Column<string>(maxLength: 255, nullable: false),
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    LeagueName = table.Column<string>(maxLength: 255, nullable: false),
                    GameDayNumber = table.Column<int>(nullable: false),
                    HalfFieldLength = table.Column<int>(nullable: false, defaultValue: 100),
                    ActionsPerMinute = table.Column<int>(nullable: false, defaultValue: 4),
                    MaxOvertime = table.Column<int>(nullable: false, defaultValue: 8),
                    ShotAccuracyModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    PaceModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    MaxHomeAdvantage = table.Column<double>(nullable: false, defaultValue: 0.0),
                    MaxAwayDisadvantage = table.Column<double>(nullable: false, defaultValue: 0.0),
                    HomeAttackStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    HomeDefenseStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    HomeGoalKeeperStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    HomePotentialPositiveShift = table.Column<double>(nullable: false, defaultValue: 0.0),
                    HomePotentialPositiveChance = table.Column<double>(nullable: false, defaultValue: 0.0),
                    HomePotentialNegativeShift = table.Column<double>(nullable: false, defaultValue: 0.0),
                    HomePotentialNegativeChance = table.Column<double>(nullable: false, defaultValue: 0.0),
                    HomeMaxPace = table.Column<int>(nullable: false, defaultValue: 40),
                    HomeShotOnGoalRate = table.Column<double>(nullable: false, defaultValue: 0.40000000000000002),
                    AwayAttackStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    AwayDefenseStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    AwayGoalKeeperStrength = table.Column<double>(nullable: false, defaultValue: 600.0),
                    AwayPotentialPositiveShift = table.Column<double>(nullable: false, defaultValue: 0.0),
                    AwayPotentialPositiveChance = table.Column<double>(nullable: false, defaultValue: 0.0),
                    AwayPotentialNegativeShift = table.Column<double>(nullable: false, defaultValue: 0.0),
                    AwayPotentialNegativeChance = table.Column<double>(nullable: false, defaultValue: 0.0),
                    AwayMaxPace = table.Column<int>(nullable: false, defaultValue: 40),
                    AwayShotOnGoalRate = table.Column<double>(nullable: false, defaultValue: 0.40000000000000002)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueFixtures", x => new { x.LeagueName, x.Season, x.GameDayNumber, x.HomeTeamName, x.AwayTeamName });
                    table.ForeignKey(
                        name: "FK_LeagueFixtures_Teams_AwayTeamName_Season",
                        columns: x => new { x.AwayTeamName, x.Season },
                        principalTable: "Teams",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueFixtures_Teams_HomeTeamName_Season",
                        columns: x => new { x.HomeTeamName, x.Season },
                        principalTable: "Teams",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueFixtures_LeagueGameDays_LeagueName_Season_GameDayNumber",
                        columns: x => new { x.LeagueName, x.Season, x.GameDayNumber },
                        principalTable: "LeagueGameDays",
                        principalColumns: new[] { "LeagueName", "Season", "GameDayNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentName_Season",
                table: "Countries",
                columns: new[] { "ContinentName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_CountryName_Season",
                table: "Divisions",
                columns: new[] { "CountryName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueFixtures_AwayTeamName_Season",
                table: "LeagueFixtures",
                columns: new[] { "AwayTeamName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueFixtures_HomeTeamName_Season",
                table: "LeagueFixtures",
                columns: new[] { "HomeTeamName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_DivisionName_Season",
                table: "Leagues",
                columns: new[] { "DivisionName", "Season" });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueName_Season",
                table: "Teams",
                columns: new[] { "LeagueName", "Season" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueFixtures");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "LeagueGameDays");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
