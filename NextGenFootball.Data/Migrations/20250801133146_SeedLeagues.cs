using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedLeagues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "AgeGroup", "Description", "ImageUrl", "Name", "Region", "SeasonId" },
                values: new object[,]
                {
                    { 1, "U15", "", "https://marketplace.canva.com/EAGFNmKiY9s/1/0/1600w/canva-blue-soccer-sports-logo-rQrjayPQsF0.jpg", "Елитна юношеска група до 15 г.", 5, 1 },
                    { 2, "U16", "", "https://i.pinimg.com/736x/d4/c7/65/d4c765fb353b3901676a1bdbda3f9706.jpg", "Елитна юношеска група до 16г.", 5, 1 },
                    { 3, "U17", "", "https://img.freepik.com/premium-vector/ball-with-three-spotting-stripe-football-league-logo_8296-13.jpg", "Елитна юношеска група до 17г.", 5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
