using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RemoveRedundantFixtureData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayAttackStrength",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "AwayDefenseStrength",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "AwayGoalKeeperStrength",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "AwayMaxPace",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "AwayPotentialNegativeChance",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "AwayPotentialNegativeShift",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "AwayPotentialPositiveChance",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "AwayPotentialPositiveShift",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "AwayShotOnGoalRate",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomeAttackStrength",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomeDefenseStrength",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomeGoalKeeperStrength",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomeMaxPace",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomePotentialNegativeChance",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomePotentialNegativeShift",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomePotentialPositiveChance",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomePotentialPositiveShift",
                table: "LeagueFixtures");

            migrationBuilder.DropColumn(
                name: "HomeShotOnGoalRate",
                table: "LeagueFixtures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AwayAttackStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AwayDefenseStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AwayGoalKeeperStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwayMaxPace",
                table: "LeagueFixtures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AwayPotentialNegativeChance",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AwayPotentialNegativeShift",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AwayPotentialPositiveChance",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AwayPotentialPositiveShift",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AwayShotOnGoalRate",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomeAttackStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomeDefenseStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomeGoalKeeperStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeMaxPace",
                table: "LeagueFixtures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomePotentialNegativeChance",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomePotentialNegativeShift",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomePotentialPositiveChance",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomePotentialPositiveShift",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomeShotOnGoalRate",
                table: "LeagueFixtures",
                type: "float",
                nullable: true);
        }
    }
}
