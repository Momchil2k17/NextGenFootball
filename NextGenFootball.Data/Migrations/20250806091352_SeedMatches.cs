using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AssistantReferee1Id", "AssistantReferee2Id", "AwayScore", "AwayTeamId", "Date", "HomeScore", "HomeTeamId", "LeagueId", "MatchReportId", "RefereeId", "Round", "StadiumId", "Status", "VideoUrl" },
                values: new object[,]
                {
                    { 1L, null, null, null, 2, new DateTime(2025, 8, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, null, null, 1, 1, 1, null },
                    { 2L, null, null, null, 4, new DateTime(2025, 8, 12, 15, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, null, null, 1, 3, 1, null },
                    { 3L, null, null, null, 6, new DateTime(2025, 8, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 1, null, null, 1, 5, 1, null },
                    { 4L, null, null, null, 8, new DateTime(2025, 8, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 1, null, null, 1, 7, 1, null },
                    { 5L, null, null, null, 10, new DateTime(2025, 8, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 1, null, null, 1, 9, 1, null },
                    { 6L, null, null, null, 3, new DateTime(2025, 8, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, null, null, 2, 2, 1, null },
                    { 7L, null, null, null, 5, new DateTime(2025, 8, 13, 15, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 1, null, null, 2, 4, 1, null },
                    { 8L, null, null, null, 7, new DateTime(2025, 8, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 1, null, null, 2, 6, 1, null },
                    { 9L, null, null, null, 9, new DateTime(2025, 8, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 1, null, null, 2, 8, 1, null },
                    { 10L, null, null, null, 1, new DateTime(2025, 8, 13, 18, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 1, null, null, 2, 10, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 10L);
        }
    }
}
