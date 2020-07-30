using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RemoveFixtureColumnRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HomeShotOnGoalRate",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.40000000000000002);

            migrationBuilder.AlterColumn<double>(
                name: "HomePotentialPositiveShift",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "HomePotentialPositiveChance",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "HomePotentialNegativeShift",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "HomePotentialNegativeChance",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "HomeMaxPace",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 40);

            migrationBuilder.AlterColumn<double>(
                name: "HomeGoalKeeperStrength",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 600.0);

            migrationBuilder.AlterColumn<double>(
                name: "HomeDefenseStrength",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 600.0);

            migrationBuilder.AlterColumn<double>(
                name: "HomeAttackStrength",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 600.0);

            migrationBuilder.AlterColumn<double>(
                name: "AwayShotOnGoalRate",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.40000000000000002);

            migrationBuilder.AlterColumn<double>(
                name: "AwayPotentialPositiveShift",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "AwayPotentialPositiveChance",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "AwayPotentialNegativeShift",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "AwayPotentialNegativeChance",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "AwayMaxPace",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 40);

            migrationBuilder.AlterColumn<double>(
                name: "AwayGoalKeeperStrength",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 600.0);

            migrationBuilder.AlterColumn<double>(
                name: "AwayDefenseStrength",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 600.0);

            migrationBuilder.AlterColumn<double>(
                name: "AwayAttackStrength",
                table: "LeagueFixtures",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 600.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HomeShotOnGoalRate",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.40000000000000002,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HomePotentialPositiveShift",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HomePotentialPositiveChance",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HomePotentialNegativeShift",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HomePotentialNegativeChance",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HomeMaxPace",
                table: "LeagueFixtures",
                type: "int",
                nullable: false,
                defaultValue: 40,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HomeGoalKeeperStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 600.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HomeDefenseStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 600.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HomeAttackStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 600.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AwayShotOnGoalRate",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.40000000000000002,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AwayPotentialPositiveShift",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AwayPotentialPositiveChance",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AwayPotentialNegativeShift",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AwayPotentialNegativeChance",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwayMaxPace",
                table: "LeagueFixtures",
                type: "int",
                nullable: false,
                defaultValue: 40,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AwayGoalKeeperStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 600.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AwayDefenseStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 600.0,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AwayAttackStrength",
                table: "LeagueFixtures",
                type: "float",
                nullable: false,
                defaultValue: 600.0,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
