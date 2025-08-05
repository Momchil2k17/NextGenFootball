using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeamLineupEntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamStartingLineups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStartingLineups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamStartingLineups_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamStartingLineups_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamStartingLineupPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamStartingLineupId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStartingLineupPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamStartingLineupPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamStartingLineupPlayers_TeamStartingLineups_TeamStartingLineupId",
                        column: x => x.TeamStartingLineupId,
                        principalTable: "TeamStartingLineups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamStartingLineupPlayers_PlayerId",
                table: "TeamStartingLineupPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStartingLineupPlayers_TeamStartingLineupId",
                table: "TeamStartingLineupPlayers",
                column: "TeamStartingLineupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStartingLineups_CoachId",
                table: "TeamStartingLineups",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStartingLineups_TeamId",
                table: "TeamStartingLineups",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamStartingLineupPlayers");

            migrationBuilder.DropTable(
                name: "TeamStartingLineups");
        }
    }
}
