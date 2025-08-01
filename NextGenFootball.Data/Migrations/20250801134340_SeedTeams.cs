using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "AgeGroup", "Description", "ImageUrl", "LeagueId", "Name", "Region", "StadiumId" },
                values: new object[,]
                {
                    { 1, "U15", "CSKA Sofia's youth team, based in Sofia.", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/CSKA_Sofia_logo.svg/471px-CSKA_Sofia_logo.svg.png", 1, "CSKA Sofia U15", 3, 1 },
                    { 2, "U15", "Ludogorets Razgrad's youth team.", "https://upload.wikimedia.org/wikipedia/en/e/eb/PFC_Ludogorets_Razgrad_logo.png", 1, "Ludogorets Razgrad U15", 1, 2 },
                    { 3, "U15", "Levski Sofia's U15 team.", "https://upload.wikimedia.org/wikipedia/en/5/51/PFC_Levski_Sofia.svg", 1, "Levski Sofia U15", 3, 3 },
                    { 4, "U15", "Beroe Stara Zagora's U15 team.", "https://upload.wikimedia.org/wikipedia/commons/d/df/BeroeLogo.png", 1, "Beroe Stara Zagora U15", 4, 4 },
                    { 5, "U15", "Botev Plovdiv's youth team.", "https://upload.wikimedia.org/wikipedia/en/thumb/8/87/PFC_Botev_Plovdiv.svg/640px-PFC_Botev_Plovdiv.svg.png", 1, "Botev Plovdiv U15", 4, 5 },
                    { 6, "U15", "Lokomotiv Plovdiv's U15 squad.", "https://upload.wikimedia.org/wikipedia/en/1/12/PFC_Lokomotiv_Plovdiv.png", 1, "Lokomotiv Plovdiv U15", 4, 6 },
                    { 7, "U15", "Etar Veliko Tarnovo's U15 team.", "https://etarvt.bg/wp-content/uploads/2017/03/etar.png", 1, "Etar Veliko Tarnovo U15", 2, 7 },
                    { 8, "U15", "Slavia Sofia's U15 team.", "https://upload.wikimedia.org/wikipedia/commons/a/a3/Slavia-Sofia.png", 1, "Slavia Sofia U15", 3, 8 },
                    { 9, "U15", "Cherno More Varna U15 squad.", "https://seeklogo.com/images/F/fk-cherno-more-varna-logo-FF1CA3BA17-seeklogo.com.gif", 1, "Cherno More Varna U15", 1, 9 },
                    { 10, "U15", "Dobrudzha Dobrich U15 youth team.", "https://upload.wikimedia.org/wikipedia/en/0/09/FC_Dobrudzha_Dobrich_2018_emblem.png", 1, "Dobrudzha Dobrich U15", 1, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
