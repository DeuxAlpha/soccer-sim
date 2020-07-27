using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PotentialNegativeChance = table.Column<double>(nullable: false),
                    MaxPace = table.Column<int>(nullable: false, defaultValue: 40),
                    ShotOnGoalRate = table.Column<double>(nullable: false, defaultValue: 0.40000000000000002)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => new { x.Name, x.Year });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
