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
                    Year = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 10, nullable: true),
                    ShotAccuracyModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    PaceModifier = table.Column<double>(nullable: false, defaultValue: 1.0),
                    MaxHomeAdvantage = table.Column<double>(nullable: false, defaultValue: 0.0),
                    MaxAwayDisadvantage = table.Column<double>(nullable: false, defaultValue: 0.0),
                    CompetitionType = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => new { x.Name, x.Year });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
