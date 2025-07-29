using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchEntityColumnsForTheReferees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Referees_RefereeId",
                table: "Matches");

            migrationBuilder.AddColumn<Guid>(
                name: "AssistantReferee1Id",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssistantReferee2Id",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AssistantReferee1Id",
                table: "Matches",
                column: "AssistantReferee1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AssistantReferee2Id",
                table: "Matches",
                column: "AssistantReferee2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Referees_AssistantReferee1Id",
                table: "Matches",
                column: "AssistantReferee1Id",
                principalTable: "Referees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Referees_AssistantReferee2Id",
                table: "Matches",
                column: "AssistantReferee2Id",
                principalTable: "Referees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Referees_RefereeId",
                table: "Matches",
                column: "RefereeId",
                principalTable: "Referees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Referees_AssistantReferee1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Referees_AssistantReferee2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Referees_RefereeId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AssistantReferee1Id",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AssistantReferee2Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AssistantReferee1Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AssistantReferee2Id",
                table: "Matches");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Referees_RefereeId",
                table: "Matches",
                column: "RefereeId",
                principalTable: "Referees",
                principalColumn: "Id");
        }
    }
}
