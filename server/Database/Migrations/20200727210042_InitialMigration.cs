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
                    Year = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => new { x.Name, x.Year });
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Year = table.Column<string>(maxLength: 4, nullable: false),
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
                    table.PrimaryKey("PK_Countries", x => new { x.Name, x.Year });
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentName_Year",
                        columns: x => new { x.ContinentName, x.Year },
                        principalTable: "Continents",
                        principalColumns: new[] { "Name", "Year" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Year = table.Column<string>(maxLength: 4, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 10, nullable: true),
                    Level = table.Column<int>(nullable: false, defaultValue: 1),
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => new { x.Name, x.Year });
                    table.ForeignKey(
                        name: "FK_Divisions_Countries_CountryName_Year",
                        columns: x => new { x.CountryName, x.Year },
                        principalTable: "Countries",
                        principalColumns: new[] { "Name", "Year" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Year = table.Column<string>(maxLength: 4, nullable: false),
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
                    table.PrimaryKey("PK_Competitions", x => new { x.Name, x.Year });
                    table.ForeignKey(
                        name: "FK_Competitions_Divisions_DivisionName_Year",
                        columns: x => new { x.DivisionName, x.Year },
                        principalTable: "Divisions",
                        principalColumns: new[] { "Name", "Year" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Year = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(maxLength: 255, nullable: true),
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
                    LeagueName = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => new { x.Name, x.Year });
                    table.ForeignKey(
                        name: "FK_Teams_Competitions_LeagueName_Year",
                        columns: x => new { x.LeagueName, x.Year },
                        principalTable: "Competitions",
                        principalColumns: new[] { "Name", "Year" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_DivisionName_Year",
                table: "Competitions",
                columns: new[] { "DivisionName", "Year" });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentName_Year",
                table: "Countries",
                columns: new[] { "ContinentName", "Year" });

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_CountryName_Year",
                table: "Divisions",
                columns: new[] { "CountryName", "Year" });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueName_Year",
                table: "Teams",
                columns: new[] { "LeagueName", "Year" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
