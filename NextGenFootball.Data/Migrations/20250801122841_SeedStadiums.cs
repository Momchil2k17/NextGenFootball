using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedStadiums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Address", "Capacity", "Description", "ImageUrl", "Name", "Surface" },
                values: new object[,]
                {
                    { 1, "38, Evlogi and Hristo Georgiev Blvd., Sofia, Bulgaria", 44000, "National stadium located in Sofia.", "https://visitsofia.bg/images/vegas_media/category30000/object1137/bc9eda16929341c44a00f67d99a530c1.jpg", "Vasil Levski National Stadium", 0 },
                    { 2, "43 Vasil Levski Blvd., Razgrad, 7200, Bulgaria", 10222, "Home of Ludogorets Razgrad.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzvhxZ44u7BOCWfpkzkPiLGH-Qas9boXXs1w&s", "Ludogorets Arena", 0 },
                    { 3, "47 Todorini Kukli Str., Sofia", 25000, "Levski Sofia's stadium.", "https://sportenkalendar.bg/uploads/pages/stadion-georgi-asparuhov-639798c914d0a486224316.jpg", "Stadion Georgi Asparuhov", 0 },
                    { 4, "ul. \"Beroe\" 10, 6000 Mitropolit Metodiy Kusev, Stara Zagora, Bulgaria", 12000, "Located in Stara Zagora.", "https://media.bgclubs.eu/images/stadiums/112/thumbnails/d6ae5e07b3c651e3e701cda939794851.jpg", "Stadion Beroe", 0 },
                    { 5, "Hristo Botev 10 Iztochen Blvd 4017 Plovdiv ", 18000, "Home of Botev Plovdiv.", "https://pimkbuild.bg/wp-content/uploads/2023/07/stadion-3.jpg", "Stadion Hristo Botev", 0 },
                    { 6, "Lokomotiv Trakia Stadium", 13500, "Lokomotiv Plovdiv stadium.", "https://upload.wikimedia.org/wikipedia/commons/7/7d/Lokomotiv_Stadium_2022.jpg", "Stadion Lokomotiv", 0 },
                    { 7, "Stadium Ivaylo Veliko Tarnovo", 18000, "Located in Veliko Tarnovo.","https://sportenkalendar.bg/zali/stadion-ivajlo", "Stadion Ivaylo", 0 },
                    { 8, "1 Koloman Str., Krasno selo", 25000, "Home of Slavia Sofia.", "https://static.bnr.bg/gallery/cr/medium/4161fc0a6d52093f9345b9b7bbe11457.JPG", "Stadion Slavia", 0 },
                    { 9, "Ticha Stadium", 8500, "Cherno More Varna's stadium.", "https://media.bgclubs.eu/images/stadiums/110/thumbnails/f0f8d88415e703b90b7ad27fbab55f88.jpg", "Stadion Ticha", 0 },
                    { 10, "Stadium \"Druzhba\"", 12000, "Located in Dobrich.", "https://pronewsdobrich.bg//i/2024/09/17/461251.jpg", "Stadion Druzhba", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
