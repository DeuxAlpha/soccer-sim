using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class ExtendLeagueFixtureEventKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LeagueFixtureEvents",
                table: "LeagueFixtureEvents");

            migrationBuilder.AlterColumn<int>(
                name: "AddedMinute",
                table: "LeagueFixtureEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeagueFixtureEvents",
                table: "LeagueFixtureEvents",
                columns: new[] { "LeagueName", "Season", "GameDayNumber", "HomeTeamName", "AwayTeamName", "Minute", "AddedMinute" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LeagueFixtureEvents",
                table: "LeagueFixtureEvents");

            migrationBuilder.AlterColumn<int>(
                name: "AddedMinute",
                table: "LeagueFixtureEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeagueFixtureEvents",
                table: "LeagueFixtureEvents",
                columns: new[] { "LeagueName", "Season", "GameDayNumber", "HomeTeamName", "AwayTeamName" });
        }
    }
}
