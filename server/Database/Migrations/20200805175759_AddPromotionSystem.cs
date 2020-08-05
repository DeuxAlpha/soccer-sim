using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddPromotionSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromotionSystems",
                columns: table => new
                {
                    Season = table.Column<string>(maxLength: 10, nullable: false),
                    LeagueName = table.Column<string>(maxLength: 255, nullable: false),
                    PromotedTeamsStart = table.Column<int>(nullable: false),
                    PromotedTeamsEnd = table.Column<int>(nullable: false),
                    PromotionPlayOffTeamsStart = table.Column<int>(nullable: false),
                    PromotionPlayOffTeamsEnd = table.Column<int>(nullable: false),
                    RelegatedTeamsStart = table.Column<int>(nullable: false),
                    RelegatedTeamsEnd = table.Column<int>(nullable: false),
                    RelegationPlayOffTeamsStart = table.Column<int>(nullable: false),
                    RelegationPlayOffTeamsEnd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionSystems", x => new { x.LeagueName, x.Season });
                    table.ForeignKey(
                        name: "FK_PromotionSystems_Leagues_LeagueName_Season",
                        columns: x => new { x.LeagueName, x.Season },
                        principalTable: "Leagues",
                        principalColumns: new[] { "Name", "Season" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionSystems");
        }
    }
}
