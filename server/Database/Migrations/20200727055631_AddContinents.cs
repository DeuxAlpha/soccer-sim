using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddContinents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContinentName",
                table: "Competitions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Year = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => new { x.Name, x.Year });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_ContinentName_Year",
                table: "Competitions",
                columns: new[] { "ContinentName", "Year" });

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Continents_ContinentName_Year",
                table: "Competitions",
                columns: new[] { "ContinentName", "Year" },
                principalTable: "Continents",
                principalColumns: new[] { "Name", "Year" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Continents_ContinentName_Year",
                table: "Competitions");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_ContinentName_Year",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "ContinentName",
                table: "Competitions");
        }
    }
}
