using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    ShotOnGoalRate = table.Column<double>(nullable: false, defaultValue: 0.40000000000000002)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
