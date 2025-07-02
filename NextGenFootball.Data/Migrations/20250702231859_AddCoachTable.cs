using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCoachTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the coach."),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Unique identifier for the application user associated with the coach."),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "First name of the coach."),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Last name of the coach."),
                    Role = table.Column<int>(type: "int", nullable: false, comment: "Role of the coach, e.g., 'Head Coach', 'Assistant Coach'."),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "Phone number of the coach."),
                    TeamId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the team that the coach manages."),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "Image of the coach"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Soft delete flag indicating if the coach is deleted.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coaches_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coaches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Represents a football coach.");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_ApplicationUserId",
                table: "Coaches",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_TeamId",
                table: "Coaches",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaches");
        }
    }
}
