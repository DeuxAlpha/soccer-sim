using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddLeagueFkToFixtures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_LeagueFixtures_Leagues_LeagueName_Season",
                table: "LeagueFixtures",
                columns: new[] { "LeagueName", "Season" },
                principalTable: "Leagues",
                principalColumns: new[] { "Name", "Season" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueFixtures_Leagues_LeagueName_Season",
                table: "LeagueFixtures");
        }
    }
}
