using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlayerSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ApplicationUserId", "Assists", "DateOfBirth", "FirstName", "Goals", "ImageUrl", "LastName", "MinutesPlayed", "PhoneNumber", "Position", "PositionEnum", "PreferredFoot", "RedCards", "SeasonId", "TeamId", "YellowCards" },
                values: new object[,]
                {
                    { new Guid("0a2250ba-fd8f-4231-8663-3ae38f96cbc7"), null, 0, new DateTime(2001, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwan", 0, "https://img.a.transfermarkt.technology/portrait/header/973569-1691005715.png?lm=1", "Seco", 0, null, "Center Forward", 4, 2, 0, 1, 2, 0 },
                    { new Guid("0efa81c3-9bd7-49a1-a5ce-8afd283a6c6e"), null, 0, new DateTime(2002, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanislav", 0, "https://img.a.transfermarkt.technology/portrait/header/486813-1691069350.png?lm=1", "Shopov", 0, null, "Central Midfield", 3, 3, 0, 1, 1, 0 },
                    { new Guid("12f3e458-05e4-4f30-9c19-2ac67fbcc4d7"), null, 0, new DateTime(2000, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christian", 0, "https://img.a.transfermarkt.technology/portrait/header/463667-1754077287.png?lm=1", "Makoun", 0, null, "Center Back", 2, 2, 0, 1, 3, 0 },
                    { new Guid("19f2b08f-953f-4726-8406-f2df5f3ccfab"), null, 0, new DateTime(1994, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Menno", 0, "https://img.a.transfermarkt.technology/portrait/header/182578-1624290727.png?lm=1", "Koch", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("1f4fb01d-52e7-4639-84b8-74107835f401"), null, 0, new DateTime(1998, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tobias", 0, "https://img.a.transfermarkt.technology/portrait/header/329714-1691069272.png?lm=1", "Heintz", 0, null, "Right Winger", 4, 2, 0, 1, 1, 0 },
                    { new Guid("1fe6c1e4-2556-4cb3-ba89-5772044fff00"), null, 0, new DateTime(1995, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivier", 0, "https://img.a.transfermarkt.technology/portrait/header/504125-1753810743.png?lm=1", "Verdon", 0, null, "Center Back", 2, 2, 0, 1, 2, 0 },
                    { new Guid("24f78ede-17ac-4851-a123-89d68ac6653e"), null, 0, new DateTime(1990, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergio", 0, "https://img.a.transfermarkt.technology/portrait/header/79573-1753810372.png?lm=1", "Padt", 0, null, "Goalkeeper", 1, 2, 0, 1, 2, 0 },
                    { new Guid("258909b8-0a3a-40b9-ac3a-6949d29f02f5"), null, 0, new DateTime(1993, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anton", 0, "https://img.a.transfermarkt.technology/portrait/header/218441-1753810308.png?lm=1", "Nedyalkov", 0, null, "Left Back", 2, 1, 0, 1, 2, 0 },
                    { new Guid("2687a4ec-a2ba-4e9a-a7ae-821fc4c98de4"), null, 0, new DateTime(1992, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgi", 0, "https://img.a.transfermarkt.technology/portrait/header/134158-1732263336.png?lm=1", "Milanov", 0, null, "Central Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("2e0b3b97-c5a0-4336-ae22-ef17a87c2843"), null, 0, new DateTime(2001, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dimitar", 0, "https://img.a.transfermarkt.technology/portrait/header/198418-1624290529.png?lm=1", "Evtimov", 0, null, "Goalkeeper", 1, 2, 0, 1, 1, 0 },
                    { new Guid("3457b59a-8393-4d6d-b80f-08d471fcfe94"), null, 0, new DateTime(1996, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 0, "https://img.a.transfermarkt.technology/portrait/header/265481-1718722697.jpg?lm=1", "Estrada", 0, null, "Left Winger", 4, 2, 0, 1, 1, 0 },
                    { new Guid("3694f527-8277-4e09-b861-ba8276910273"), null, 0, new DateTime(1999, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", 0, "https://img.a.transfermarkt.technology/portrait/header/550466-1624290844.png?lm=1", "Turitsov", 0, null, "Right Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("3a90db90-008e-4a70-8421-5d1461558bc9"), null, 0, new DateTime(1995, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rick", 0, "https://img.a.transfermarkt.technology/portrait/header/645955-1720984771.png?lm=1", "Lourenço", 0, null, "Right Winger", 4, 2, 0, 1, 2, 0 },
                    { new Guid("3cbb83f0-81a8-4d20-bfd2-73a299d0099b"), null, 0, new DateTime(1994, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claude", 0, "https://img.a.transfermarkt.technology/portrait/header/280178-1721812558.png?lm=1", "Gonçalves", 0, null, "Defensive Midfield", 3, 2, 0, 1, 2, 0 },
                    { new Guid("49db4761-2849-4877-a4a5-05df5a94700e"), null, 0, new DateTime(1997, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enes", 0, "https://img.a.transfermarkt.technology/portrait/header/329055-1689009945.png?lm=1", "Mahmutovic", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("4d2554c9-1f25-4243-aef0-318ce220efbc"), null, 0, new DateTime(1999, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrian", 0, "https://img.a.transfermarkt.technology/portrait/header/820371-1680122620.png?lm=1", "Kraev", 0, null, "Central Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("539dab57-92ec-4899-9e3b-dfdf97295edc"), null, 0, new DateTime(1997, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bernard", 0, "https://img.a.transfermarkt.technology/portrait/header/422380-1720984240.png?lm=1", "Tekpetey", 0, null, "Left Winger", 4, 2, 0, 1, 2, 0 },
                    { new Guid("56b3ff5e-7fde-49a8-99da-dc76833396b3"), null, 0, new DateTime(1999, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian", 0, "https://img.a.transfermarkt.technology/portrait/header/585356-1689009993.png?lm=1", "Cordoba", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("5a8967a3-0261-42a0-9841-16e52732f934"), null, 0, new DateTime(1996, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan", 0, "https://img.a.transfermarkt.technology/portrait/header/234345-1691069138.png?lm=1", "Lindseth", 0, null, "Central Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("5ccd8183-2055-40bb-bd2f-5f75f09521e9"), null, 0, new DateTime(1997, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lazar", 0, "https://img.a.transfermarkt.technology/portrait/header/257466-1735137816.png?lm=1", "Tufegdzic", 0, null, "Central Attacking Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("68de397d-1790-4e81-ab59-84540ac236f9"), null, 0, new DateTime(2000, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominik", 0, "https://img.a.transfermarkt.technology/portrait/header/541287-1740597154.jpg?lm=1", "Yankov", 0, null, "Central Midfield", 3, 2, 0, 1, 2, 0 },
                    { new Guid("6f4757c6-e5ee-4560-a659-1246b05e49ee"), null, 0, new DateTime(1996, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiril", 0, "https://img.a.transfermarkt.technology/portrait/header/221540-1727967569.png?lm=1", "Despodov", 0, null, "Right Winger", 4, 2, 0, 1, 2, 0 },
                    { new Guid("7e46edaa-6e3a-46f8-9056-ccaee1774c6c"), null, 0, new DateTime(1997, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welton", 0, "https://img.a.transfermarkt.technology/portrait/header/858213-1680124417.png?lm=1", "Felix", 0, null, "Left Winger", 4, 2, 0, 1, 3, 0 },
                    { new Guid("8417ad24-60cd-45d3-bfc8-c5503d544361"), null, 0, new DateTime(1998, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brayan", 0, "https://img.a.transfermarkt.technology/portrait/header/778476-1708593480.png?lm=1", "Moreno", 0, null, "Left Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("85b7e6a3-54a3-4530-80a8-b91aa1b5b166"), null, 0, new DateTime(1996, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aslak", 0, "https://img.a.transfermarkt.technology/portrait/header/313944-1691003407.png?lm=1", "Fonn Witry", 0, null, "Right Back", 2, 2, 0, 1, 2, 0 },
                    { new Guid("8cb114c8-6038-4f83-8041-0dd3ac6af293"), null, 0, new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronaldo", 0, "https://img.a.transfermarkt.technology/portrait/header/328758-1733317063.jpg?lm=1", "Henrique", 0, null, "Right Winger", 4, 2, 0, 1, 3, 0 },
                    { new Guid("9778c700-13ec-4cec-8e08-daa9577cea67"), null, 0, new DateTime(1992, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amos", 0, "https://img.a.transfermarkt.technology/portrait/header/203540-1624292062.png?lm=1", "Youga", 0, null, "Defensive Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("995f9627-2d72-4ac7-b478-10807a1145f1"), null, 0, new DateTime(1996, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matías", 0, "https://img.a.transfermarkt.technology/portrait/header/503001-1720984447.png?lm=1", "Tissera", 0, null, "Center Forward", 4, 2, 0, 1, 2, 0 },
                    { new Guid("9b452ea7-95b7-40c6-9b77-0cf0daad83ce"), null, 0, new DateTime(2001, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Filip", 0, "https://cdn.soccerwiki.org/images/player/104559.png", "Krastev", 0, null, "Central Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("a034c70b-5dcb-4e27-9acd-5f2d7134a06c"), null, 0, new DateTime(1997, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kristian", 0, "https://img.a.transfermarkt.technology/portrait/header/351800-1754077260.png?lm=1", "Dimitrov", 0, null, "Center Back", 2, 1, 0, 1, 3, 0 },
                    { new Guid("a0415484-d6c7-4810-8c8c-7efc69d0ae9d"), null, 0, new DateTime(1990, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gustavo", 0, "https://img.a.transfermarkt.technology/portrait/header/136574-1624290491.png?lm=1", "Busatto", 0, null, "Goalkeeper", 1, 2, 0, 1, 1, 0 },
                    { new Guid("a2fb3e65-e3f4-4348-8335-5f4667e83c22"), null, 0, new DateTime(1993, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurgen", 0, "https://img.a.transfermarkt.technology/portrait/header/188660-1624290573.png?lm=1", "Mattheij", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("a916a6e8-fe05-4d6f-b0e4-967c07d74ff6"), null, 0, new DateTime(1990, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgi", 0, "https://img.a.transfermarkt.technology/portrait/header/198816-1754075148.png?lm=1", "Kostadinov", 0, null, "Defensive Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("aa6607cc-70df-40e0-921b-b65354175778"), null, 0, new DateTime(2003, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marin", 0, "https://img.a.transfermarkt.technology/portrait/header/675946-1754077435.png?lm=1", "Petkov", 0, null, "Right Winger", 4, 2, 0, 1, 3, 0 },
                    { new Guid("ae635af1-16f3-4e4d-91be-ffbaf359a4f8"), null, 0, new DateTime(1988, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikolay", 0, "https://img.a.transfermarkt.technology/portrait/header/24480-1681658070.png?lm=1", "Mihaylov", 0, null, "Goalkeeper", 1, 2, 0, 1, 3, 0 },
                    { new Guid("aec3888f-733b-43c3-8e0b-626b187dee5d"), null, 0, new DateTime(1990, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Igor", 0, "https://img.a.transfermarkt.technology/portrait/header/97335-1629575683.png?lm=1", "Plastun", 0, null, "Center Back", 2, 2, 0, 1, 2, 0 },
                    { new Guid("d0ba924f-2939-40fa-ae29-f611309f9f0a"), null, 0, new DateTime(2000, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Filip", 0, "https://img.a.transfermarkt.technology/portrait/header/396230-1753810681.png?lm=1", "Kaloc", 0, null, "Central Midfield", 3, 2, 0, 1, 2, 0 },
                    { new Guid("d5604c3f-3391-4198-af48-56160482d42d"), null, 0, new DateTime(1998, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darlan", 0, "https://img.a.transfermarkt.technology/portrait/header/570582-1691301973.png?lm=1", "Cruz", 0, null, "Defensive Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("e3f774bc-8018-4aef-922d-b74bb43cc6cd"), null, 0, new DateTime(2002, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Svetoslav", 0, "https://img.a.transfermarkt.technology/portrait/header/628038-1754077358.png?lm=1", "Vutsov", 0, null, "Goalkeeper", 1, 2, 0, 1, 3, 0 },
                    { new Guid("e8060642-8ceb-42b6-95af-d851c0f220b2"), null, 0, new DateTime(1998, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeremy", 0, "https://img.a.transfermarkt.technology/portrait/header/532858-1688876742.png?lm=1", "Petris", 0, null, "Right Back", 2, 2, 0, 1, 3, 0 },
                    { new Guid("ed18eeab-318b-42b7-9754-05c18bca3318"), null, 0, new DateTime(1993, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", 0, "https://img.a.transfermarkt.technology/portrait/header/239998-1754075190.png?lm=1", "Ohene", 0, null, "Center Forward", 4, 2, 0, 1, 3, 0 },
                    { new Guid("f0435b87-ff3b-4cca-af13-f12e0b6a01eb"), null, 0, new DateTime(1999, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcelino", 0, "https://img.a.transfermarkt.technology/portrait/header/572043-1691069387.png?lm=1", "Carreazo", 0, null, "Right Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("f70355d9-0782-48f8-bd22-81d0fc9d8608"), null, 0, new DateTime(1994, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duckens", 0, "https://img.a.transfermarkt.technology/portrait/header/345763-1712923993.png?lm=1", "Nazon", 0, null, "Center Forward", 4, 2, 0, 1, 1, 0 },
                    { new Guid("f74653ea-0c60-4a4d-b798-f5d780ff562e"), null, 0, new DateTime(1994, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dinis", 0, "https://img.a.transfermarkt.technology/portrait/header/329519-1753810578.png?lm=1", "Almeida", 0, null, "Center Back", 2, 2, 0, 1, 2, 0 },
                    { new Guid("f7fecf7c-38f1-4864-be64-cafd57e1c715"), null, 0, new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iliyan", 0, "https://img.a.transfermarkt.technology/portrait/header/310144-1680123802.png?lm=1", "Stefanov", 0, null, "Attacking Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("fa7a6506-2085-4d01-9182-a49e98b576c7"), null, 0, new DateTime(1997, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jakub", 0, "https://img.a.transfermarkt.technology/portrait/header/377243-1691005537.png?lm=1", "Piotrowski", 0, null, "Central Midfield", 3, 2, 0, 1, 2, 0 },
                    { new Guid("fea3badc-0c3e-4249-9272-a54e3ed4b2ff"), null, 0, new DateTime(1993, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thibaut", 0, "https://img.a.transfermarkt.technology/portrait/header/188501-1624290803.png?lm=1", "Vion", 0, null, "Left Back", 2, 2, 0, 1, 1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("0a2250ba-fd8f-4231-8663-3ae38f96cbc7"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("0efa81c3-9bd7-49a1-a5ce-8afd283a6c6e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("12f3e458-05e4-4f30-9c19-2ac67fbcc4d7"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("19f2b08f-953f-4726-8406-f2df5f3ccfab"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("1f4fb01d-52e7-4639-84b8-74107835f401"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("1fe6c1e4-2556-4cb3-ba89-5772044fff00"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("24f78ede-17ac-4851-a123-89d68ac6653e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("258909b8-0a3a-40b9-ac3a-6949d29f02f5"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("2687a4ec-a2ba-4e9a-a7ae-821fc4c98de4"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("2e0b3b97-c5a0-4336-ae22-ef17a87c2843"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("3457b59a-8393-4d6d-b80f-08d471fcfe94"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("3694f527-8277-4e09-b861-ba8276910273"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("3a90db90-008e-4a70-8421-5d1461558bc9"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("3cbb83f0-81a8-4d20-bfd2-73a299d0099b"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("49db4761-2849-4877-a4a5-05df5a94700e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("4d2554c9-1f25-4243-aef0-318ce220efbc"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("539dab57-92ec-4899-9e3b-dfdf97295edc"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("56b3ff5e-7fde-49a8-99da-dc76833396b3"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("5a8967a3-0261-42a0-9841-16e52732f934"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("5ccd8183-2055-40bb-bd2f-5f75f09521e9"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("68de397d-1790-4e81-ab59-84540ac236f9"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("6f4757c6-e5ee-4560-a659-1246b05e49ee"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("7e46edaa-6e3a-46f8-9056-ccaee1774c6c"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("8417ad24-60cd-45d3-bfc8-c5503d544361"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("85b7e6a3-54a3-4530-80a8-b91aa1b5b166"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("8cb114c8-6038-4f83-8041-0dd3ac6af293"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("9778c700-13ec-4cec-8e08-daa9577cea67"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("995f9627-2d72-4ac7-b478-10807a1145f1"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("9b452ea7-95b7-40c6-9b77-0cf0daad83ce"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a034c70b-5dcb-4e27-9acd-5f2d7134a06c"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a0415484-d6c7-4810-8c8c-7efc69d0ae9d"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a2fb3e65-e3f4-4348-8335-5f4667e83c22"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("a916a6e8-fe05-4d6f-b0e4-967c07d74ff6"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("aa6607cc-70df-40e0-921b-b65354175778"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("ae635af1-16f3-4e4d-91be-ffbaf359a4f8"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("aec3888f-733b-43c3-8e0b-626b187dee5d"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d0ba924f-2939-40fa-ae29-f611309f9f0a"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d5604c3f-3391-4198-af48-56160482d42d"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e3f774bc-8018-4aef-922d-b74bb43cc6cd"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e8060642-8ceb-42b6-95af-d851c0f220b2"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("ed18eeab-318b-42b7-9754-05c18bca3318"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f0435b87-ff3b-4cca-af13-f12e0b6a01eb"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f70355d9-0782-48f8-bd22-81d0fc9d8608"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f74653ea-0c60-4a4d-b798-f5d780ff562e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f7fecf7c-38f1-4864-be64-cafd57e1c715"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("fa7a6506-2085-4d01-9182-a49e98b576c7"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("fea3badc-0c3e-4249-9272-a54e3ed4b2ff"));
        }
    }
}
