using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPlayers1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ApplicationUserId", "Assists", "DateOfBirth", "FirstName", "Goals", "ImageUrl", "LastName", "MinutesPlayed", "PhoneNumber", "Position", "PositionEnum", "PreferredFoot", "RedCards", "SeasonId", "TeamId", "YellowCards" },
                values: new object[,]
                {
                    { new Guid("03aba06b-99bf-4895-be6c-fe90e1f4f009"), null, 0, new DateTime(2002, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanislav", 0, "https://img.a.transfermarkt.technology/portrait/header/486813-1691069350.png?lm=1", "Shopov", 0, null, "Central Midfield", 3, 3, 0, 1, 1, 0 },
                    { new Guid("0b9716e8-2d49-4747-8b53-65e6dc4788e7"), null, 0, new DateTime(1998, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tobias", 0, "https://img.a.transfermarkt.technology/portrait/header/329714-1691069272.png?lm=1", "Heintz", 0, null, "Right Winger", 4, 2, 0, 1, 1, 0 },
                    { new Guid("1ded2fcf-8953-4076-9675-8f908f324644"), null, 0, new DateTime(1998, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brayan", 0, "https://img.a.transfermarkt.technology/portrait/header/778476-1708593480.png?lm=1", "Moreno", 0, null, "Left Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("3c6d4a43-777a-4c58-897c-7ee1e85ec6b2"), null, 0, new DateTime(2001, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dimitar", 0, "https://img.a.transfermarkt.technology/portrait/header/198418-1624290529.png?lm=1", "Evtimov", 0, null, "Goalkeeper", 1, 2, 0, 1, 1, 0 },
                    { new Guid("51344bb3-c79d-4adb-9d0c-2dbd97c83b02"), null, 0, new DateTime(1999, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian", 0, "https://img.a.transfermarkt.technology/portrait/header/585356-1689009993.png?lm=1", "Cordoba", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("6ac67eb3-7fa0-45b3-a101-c4be645922bb"), null, 0, new DateTime(1993, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thibaut", 0, "https://img.a.transfermarkt.technology/portrait/header/188501-1624290803.png?lm=1", "Vion", 0, null, "Left Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("6e498cd3-461d-4c95-925c-498dcee39bdd"), null, 0, new DateTime(1994, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Menno", 0, "https://img.a.transfermarkt.technology/portrait/header/182578-1624290727.png?lm=1", "Koch", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("71d6e1f7-e74c-4109-b550-69057a601341"), null, 0, new DateTime(1990, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gustavo", 0, "https://img.a.transfermarkt.technology/portrait/header/136574-1624290491.png?lm=1", "Busatto", 0, null, "Goalkeeper", 1, 2, 0, 1, 1, 0 },
                    { new Guid("74725050-c2d7-468d-86c0-fe6257e18ce0"), null, 0, new DateTime(1997, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lazar", 0, "https://img.a.transfermarkt.technology/portrait/header/257466-1735137816.png?lm=1", "Tufegdzic", 0, null, "Central Attacking Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("7e09dcd0-c560-4f9b-b25c-b7c63229ae81"), null, 0, new DateTime(1999, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", 0, "https://img.a.transfermarkt.technology/portrait/header/550466-1624290844.png?lm=1", "Turitsov", 0, null, "Right Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("861fc92c-35ab-4223-8f87-d561eb7958c2"), null, 0, new DateTime(1996, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan", 0, "https://img.a.transfermarkt.technology/portrait/header/234345-1691069138.png?lm=1", "Lindseth", 0, null, "Central Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("90e741a3-726f-478a-a754-e45add15e468"), null, 0, new DateTime(1997, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enes", 0, "https://img.a.transfermarkt.technology/portrait/header/329055-1689009945.png?lm=1", "Mahmutovic", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("9a3cdf99-023b-4007-8ec1-ef9d092340eb"), null, 0, new DateTime(1992, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amos", 0, "https://img.a.transfermarkt.technology/portrait/header/203540-1624292062.png?lm=1", "Youga", 0, null, "Defensive Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("9e8db81b-7b28-4053-8271-b10f04a8bc2c"), null, 0, new DateTime(1993, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurgen", 0, "https://img.a.transfermarkt.technology/portrait/header/188660-1624290573.png?lm=1", "Mattheij", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("b90dc02b-82c5-4c73-b27d-6758c005ec0c"), null, 0, new DateTime(1999, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcelino", 0, "https://img.a.transfermarkt.technology/portrait/header/572043-1691069387.png?lm=1", "Carreazo", 0, null, "Right Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("c1089a98-334a-4009-8f0a-973aeb2cf11d"), null, 0, new DateTime(1996, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 0, "https://img.a.transfermarkt.technology/portrait/header/265481-1718722697.jpg?lm=1", "Estrada", 0, null, "Left Winger", 4, 2, 0, 1, 1, 0 },
                    { new Guid("eba5f54f-c2bd-41e2-8887-3a05dfbbd23e"), null, 0, new DateTime(1994, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duckens", 0, "https://img.a.transfermarkt.technology/portrait/header/345763-1712923993.png?lm=1", "Nazon", 0, null, "Center Forward", 4, 2, 0, 1, 1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("03aba06b-99bf-4895-be6c-fe90e1f4f009"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("0b9716e8-2d49-4747-8b53-65e6dc4788e7"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("1ded2fcf-8953-4076-9675-8f908f324644"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("3c6d4a43-777a-4c58-897c-7ee1e85ec6b2"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("51344bb3-c79d-4adb-9d0c-2dbd97c83b02"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("6ac67eb3-7fa0-45b3-a101-c4be645922bb"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("6e498cd3-461d-4c95-925c-498dcee39bdd"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("71d6e1f7-e74c-4109-b550-69057a601341"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("74725050-c2d7-468d-86c0-fe6257e18ce0"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("7e09dcd0-c560-4f9b-b25c-b7c63229ae81"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("861fc92c-35ab-4223-8f87-d561eb7958c2"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("90e741a3-726f-478a-a754-e45add15e468"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("9a3cdf99-023b-4007-8ec1-ef9d092340eb"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("9e8db81b-7b28-4053-8271-b10f04a8bc2c"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("b90dc02b-82c5-4c73-b27d-6758c005ec0c"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("c1089a98-334a-4009-8f0a-973aeb2cf11d"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("eba5f54f-c2bd-41e2-8887-3a05dfbbd23e"));
        }
    }
}
