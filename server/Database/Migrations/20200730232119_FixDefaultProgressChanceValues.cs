using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class FixDefaultProgressChanceValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinProgressChance",
                table: "Leagues",
                nullable: false,
                defaultValue: 0.29999999999999999,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 30.0);

            migrationBuilder.AlterColumn<double>(
                name: "MaxProgressChance",
                table: "Leagues",
                nullable: false,
                defaultValue: 0.69999999999999996,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 70.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinProgressChance",
                table: "Leagues",
                type: "float",
                nullable: false,
                defaultValue: 30.0,
                oldClrType: typeof(double),
                oldDefaultValue: 0.29999999999999999);

            migrationBuilder.AlterColumn<double>(
                name: "MaxProgressChance",
                table: "Leagues",
                type: "float",
                nullable: false,
                defaultValue: 70.0,
                oldClrType: typeof(double),
                oldDefaultValue: 0.69999999999999996);
        }
    }
}
