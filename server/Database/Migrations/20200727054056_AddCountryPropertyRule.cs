using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddCountryPropertyRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PotentialNegativeChance",
                table: "Countries",
                nullable: false,
                defaultValue: 0.10000000000000001,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PotentialNegativeChance",
                table: "Countries",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValue: 0.10000000000000001);
        }
    }
}
