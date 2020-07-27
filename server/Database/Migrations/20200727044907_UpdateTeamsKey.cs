using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class UpdateTeamsKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Teams",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                columns: new[] { "Name", "Year" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "ID");
        }
    }
}
