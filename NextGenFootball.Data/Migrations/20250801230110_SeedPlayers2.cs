using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPlayers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ApplicationUserId", "Assists", "DateOfBirth", "FirstName", "Goals", "ImageUrl", "LastName", "MinutesPlayed", "PhoneNumber", "Position", "PositionEnum", "PreferredFoot", "RedCards", "SeasonId", "TeamId", "YellowCards" },
                values: new object[,]
                {
                    { new Guid("0873c249-0017-4769-ad2a-54d031d9731a"), null, 0, new DateTime(1995, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivier", 0, "https://img.a.transfermarkt.technology/portrait/header/504125-1753810743.png?lm=1", "Verdon", 0, null, "Center Back", 2, 2, 0, 1, 2, 0 },
                    { new Guid("0a1d9bdf-ec89-41c3-97e1-752a1da2a611"), null, 0, new DateTime(1998, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeremy", 0, "https://img.a.transfermarkt.technology/portrait/header/532858-1688876742.png?lm=1", "Petris", 0, null, "Right Back", 2, 2, 0, 1, 3, 0 },
                    { new Guid("0d32ffe0-4cba-466a-b2c6-20176a232a8f"), null, 0, new DateTime(1999, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrian", 0, "https://img.a.transfermarkt.technology/portrait/header/820371-1680122620.png?lm=1", "Kraev", 0, null, "Central Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("0d692beb-72a2-4f13-ab51-8e0501e5335f"), null, 0, new DateTime(1997, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lazar", 0, "https://img.a.transfermarkt.technology/portrait/header/257466-1735137816.png?lm=1", "Tufegdzic", 0, null, "Central Attacking Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("1335091a-111c-4c5a-8bb1-9426efecba04"), null, 0, new DateTime(1993, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anton", 0, "https://img.a.transfermarkt.technology/portrait/header/218441-1753810308.png?lm=1", "Nedyalkov", 0, null, "Left Back", 2, 1, 0, 1, 2, 0 },
                    { new Guid("14101b7e-e0f9-466c-8dcf-2a8d3af2f9b3"), null, 0, new DateTime(2003, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marin", 0, "https://img.a.transfermarkt.technology/portrait/header/675946-1754077435.png?lm=1", "Petkov", 0, null, "Right Winger", 4, 2, 0, 1, 3, 0 },
                    { new Guid("16d57034-b7ac-4ca9-9793-5d153666de03"), null, 0, new DateTime(1992, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amos", 0, "https://img.a.transfermarkt.technology/portrait/header/203540-1624292062.png?lm=1", "Youga", 0, null, "Defensive Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("181f700b-43ff-438e-b4a2-61ee9a0fee0c"), null, 0, new DateTime(1999, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian", 0, "https://img.a.transfermarkt.technology/portrait/header/585356-1689009993.png?lm=1", "Cordoba", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("1f59ac5d-1910-4b6f-898a-8b981b9eec7c"), null, 0, new DateTime(1990, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Igor", 0, "https://img.a.transfermarkt.technology/portrait/header/97335-1629575683.png?lm=1", "Plastun", 0, null, "Center Back", 2, 2, 0, 1, 2, 0 },
                    { new Guid("22011a6a-7ab6-4ba0-981e-69b95149eb7f"), null, 0, new DateTime(1993, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thibaut", 0, "https://img.a.transfermarkt.technology/portrait/header/188501-1624290803.png?lm=1", "Vion", 0, null, "Left Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("241c5605-e77f-45ec-9113-7010bd9c4ab5"), null, 0, new DateTime(1999, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", 0, "https://img.a.transfermarkt.technology/portrait/header/550466-1624290844.png?lm=1", "Turitsov", 0, null, "Right Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("2530050e-9159-4d75-a0e9-261c2a144747"), null, 0, new DateTime(1996, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan", 0, "https://img.a.transfermarkt.technology/portrait/header/234345-1691069138.png?lm=1", "Lindseth", 0, null, "Central Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("2ebb99d4-6a52-4843-965c-88520541655b"), null, 0, new DateTime(1997, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bernard", 0, "https://img.a.transfermarkt.technology/portrait/header/422380-1720984240.png?lm=1", "Tekpetey", 0, null, "Left Winger", 4, 2, 0, 1, 2, 0 },
                    { new Guid("3607da5a-73b5-4aab-bfc5-435a3f025598"), null, 0, new DateTime(1998, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darlan", 0, "https://img.a.transfermarkt.technology/portrait/header/570582-1691301973.png?lm=1", "Cruz", 0, null, "Defensive Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("3aaf8d51-b732-4555-9320-75a6e1a71fec"), null, 0, new DateTime(1996, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 0, "https://img.a.transfermarkt.technology/portrait/header/265481-1718722697.jpg?lm=1", "Estrada", 0, null, "Left Winger", 4, 2, 0, 1, 1, 0 },
                    { new Guid("3eeb8c52-d3c7-4685-99fc-63e77376eeab"), null, 0, new DateTime(1997, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kristian", 0, "https://img.a.transfermarkt.technology/portrait/header/351800-1754077260.png?lm=1", "Dimitrov", 0, null, "Center Back", 2, 1, 0, 1, 3, 0 },
                    { new Guid("41f2b640-9b10-4a55-85a0-18835aa8df21"), null, 0, new DateTime(1993, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurgen", 0, "https://img.a.transfermarkt.technology/portrait/header/188660-1624290573.png?lm=1", "Mattheij", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("4226d958-257c-4a4f-a7bc-6e01b9a1a839"), null, 0, new DateTime(1996, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiril", 0, "https://img.a.transfermarkt.technology/portrait/header/221540-1727967569.png?lm=1", "Despodov", 0, null, "Right Winger", 4, 2, 0, 1, 2, 0 },
                    { new Guid("47ce2080-951c-47a7-9271-8e2d506b46fc"), null, 0, new DateTime(1996, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matías", 0, "https://img.a.transfermarkt.technology/portrait/header/503001-1720984447.png?lm=1", "Tissera", 0, null, "Center Forward", 4, 2, 0, 1, 2, 0 },
                    { new Guid("47fc8ab4-62ce-4a9d-91dd-53f426de9fd3"), null, 0, new DateTime(1994, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duckens", 0, "https://img.a.transfermarkt.technology/portrait/header/345763-1712923993.png?lm=1", "Nazon", 0, null, "Center Forward", 4, 2, 0, 1, 1, 0 },
                    { new Guid("49e1faca-6b57-4438-a23a-95256e2d5031"), null, 0, new DateTime(1993, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", 0, "https://img.a.transfermarkt.technology/portrait/header/239998-1754075190.png?lm=1", "Ohene", 0, null, "Center Forward", 4, 2, 0, 1, 3, 0 },
                    { new Guid("5c8022ef-1734-475d-abc3-39201b52f4e8"), null, 0, new DateTime(1994, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dinis", 0, "https://img.a.transfermarkt.technology/portrait/header/329519-1753810578.png?lm=1", "Almeida", 0, null, "Center Back", 2, 2, 0, 1, 2, 0 },
                    { new Guid("5c8d78cb-dece-4e67-97ec-1800dcac3c82"), null, 0, new DateTime(1994, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Menno", 0, "https://img.a.transfermarkt.technology/portrait/header/182578-1624290727.png?lm=1", "Koch", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("5cee5265-9c12-4663-8b46-88d6b41973e2"), null, 0, new DateTime(2001, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dimitar", 0, "https://img.a.transfermarkt.technology/portrait/header/198418-1624290529.png?lm=1", "Evtimov", 0, null, "Goalkeeper", 1, 2, 0, 1, 1, 0 },
                    { new Guid("66c09598-a7a3-41d5-962e-b7bc8ada67bb"), null, 0, new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iliyan", 0, "https://img.a.transfermarkt.technology/portrait/header/310144-1680123802.png?lm=1", "Stefanov", 0, null, "Attacking Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("68c6f941-0806-4604-8eaa-8010b6563688"), null, 0, new DateTime(1997, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enes", 0, "https://img.a.transfermarkt.technology/portrait/header/329055-1689009945.png?lm=1", "Mahmutovic", 0, null, "Center Back", 2, 2, 0, 1, 1, 0 },
                    { new Guid("71a92a67-f0cd-4824-a70a-e030a6759567"), null, 0, new DateTime(1990, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergio", 0, "https://img.a.transfermarkt.technology/portrait/header/79573-1753810372.png?lm=1", "Padt", 0, null, "Goalkeeper", 1, 2, 0, 1, 2, 0 },
                    { new Guid("90df5116-8e2b-4b0f-8ac7-d27e7de29c1d"), null, 0, new DateTime(2001, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rwan", 0, "https://img.a.transfermarkt.technology/portrait/header/973569-1691005715.png?lm=1", "Seco", 0, null, "Center Forward", 4, 2, 0, 1, 2, 0 },
                    { new Guid("9bca9ba0-f00b-4119-af71-5d2afcf47318"), null, 0, new DateTime(2000, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Filip", 0, "https://img.a.transfermarkt.technology/portrait/header/396230-1753810681.png?lm=1", "Kaloc", 0, null, "Central Midfield", 3, 2, 0, 1, 2, 0 },
                    { new Guid("b5a90a0c-9e53-4761-a76a-e8516fc77fe4"), null, 0, new DateTime(1992, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgi", 0, "https://img.a.transfermarkt.technology/portrait/header/134158-1732263336.png?lm=1", "Milanov", 0, null, "Central Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("baf55755-2ed2-4ef1-a677-1ec3ff28c877"), null, 0, new DateTime(1990, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gustavo", 0, "https://img.a.transfermarkt.technology/portrait/header/136574-1624290491.png?lm=1", "Busatto", 0, null, "Goalkeeper", 1, 2, 0, 1, 1, 0 },
                    { new Guid("be260856-b05c-49f5-8820-ceafcf450505"), null, 0, new DateTime(1990, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgi", 0, "https://img.a.transfermarkt.technology/portrait/header/198816-1754075148.png?lm=1", "Kostadinov", 0, null, "Defensive Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("c19bd113-4ccd-4083-b9e0-a7652fac2232"), null, 0, new DateTime(1999, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcelino", 0, "https://img.a.transfermarkt.technology/portrait/header/572043-1691069387.png?lm=1", "Carreazo", 0, null, "Right Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("c634850c-5687-46d2-8aca-0d943fbb51b8"), null, 0, new DateTime(1995, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rick", 0, "https://img.a.transfermarkt.technology/portrait/header/645955-1720984771.png?lm=1", "Lourenço", 0, null, "Right Winger", 4, 2, 0, 1, 2, 0 },
                    { new Guid("c75bc95d-329f-4df1-a1cb-763e45509b08"), null, 0, new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronaldo", 0, "https://img.a.transfermarkt.technology/portrait/header/328758-1733317063.jpg?lm=1", "Henrique", 0, null, "Right Winger", 4, 2, 0, 1, 3, 0 },
                    { new Guid("d3e493e0-c099-4a34-9eda-a1f907db1838"), null, 0, new DateTime(2002, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanislav", 0, "https://img.a.transfermarkt.technology/portrait/header/486813-1691069350.png?lm=1", "Shopov", 0, null, "Central Midfield", 3, 3, 0, 1, 1, 0 },
                    { new Guid("d550bf8e-0d42-4aea-bfa2-69b6a62f33c1"), null, 0, new DateTime(2000, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christian", 0, "https://img.a.transfermarkt.technology/portrait/header/463667-1754077287.png?lm=1", "Makoun", 0, null, "Center Back", 2, 2, 0, 1, 3, 0 },
                    { new Guid("d6d60379-3fc4-4749-a6ba-885ac345ff77"), null, 0, new DateTime(1994, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claude", 0, "https://img.a.transfermarkt.technology/portrait/header/280178-1721812558.png?lm=1", "Gonçalves", 0, null, "Defensive Midfield", 3, 2, 0, 1, 2, 0 },
                    { new Guid("d8132d92-73aa-41c6-b2f4-85c16d771ba9"), null, 0, new DateTime(1996, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aslak", 0, "https://img.a.transfermarkt.technology/portrait/header/313944-1691003407.png?lm=1", "Fonn Witry", 0, null, "Right Back", 2, 2, 0, 1, 2, 0 },
                    { new Guid("db254800-0c32-4fbf-a0aa-0894b90c0219"), null, 0, new DateTime(1998, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tobias", 0, "https://img.a.transfermarkt.technology/portrait/header/329714-1691069272.png?lm=1", "Heintz", 0, null, "Right Winger", 4, 2, 0, 1, 1, 0 },
                    { new Guid("dbd9abd5-703b-466d-944c-5cce21350568"), null, 0, new DateTime(2001, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Filip", 0, "https://cdn.soccerwiki.org/images/player/104559.png", "Krastev", 0, null, "Central Midfield", 3, 2, 0, 1, 3, 0 },
                    { new Guid("e7220e48-fd30-4f5c-a449-d9a845259209"), null, 0, new DateTime(2000, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominik", 0, "https://img.a.transfermarkt.technology/portrait/header/541287-1740597154.jpg?lm=1", "Yankov", 0, null, "Central Midfield", 3, 2, 0, 1, 2, 0 },
                    { new Guid("ea247199-3602-42f0-b89c-106f9b8b000b"), null, 0, new DateTime(1997, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jakub", 0, "https://img.a.transfermarkt.technology/portrait/header/377243-1691005537.png?lm=1", "Piotrowski", 0, null, "Central Midfield", 3, 2, 0, 1, 2, 0 },
                    { new Guid("f04bc3f7-b0ad-44ef-b474-a1ca98b05964"), null, 0, new DateTime(1997, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welton", 0, "https://img.a.transfermarkt.technology/portrait/header/858213-1680124417.png?lm=1", "Felix", 0, null, "Left Winger", 4, 2, 0, 1, 3, 0 },
                    { new Guid("f5f6bb92-2b1c-4052-8eda-92af3fd5e0be"), null, 0, new DateTime(1998, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brayan", 0, "https://img.a.transfermarkt.technology/portrait/header/778476-1708593480.png?lm=1", "Moreno", 0, null, "Left Midfield", 3, 2, 0, 1, 1, 0 },
                    { new Guid("fb90071e-1efb-4d62-a746-b20c8df50858"), null, 0, new DateTime(1988, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikolay", 0, "https://img.a.transfermarkt.technology/portrait/header/24480-1681658070.png?lm=1", "Mihaylov", 0, null, "Goalkeeper", 1, 2, 0, 1, 3, 0 },
                    { new Guid("ff7121c4-f10e-46e4-9791-373ee116bc3b"), null, 0, new DateTime(2002, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Svetoslav", 0, "https://img.a.transfermarkt.technology/portrait/header/628038-1754077358.png?lm=1", "Vutsov", 0, null, "Goalkeeper", 1, 2, 0, 1, 3, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("0873c249-0017-4769-ad2a-54d031d9731a"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("0a1d9bdf-ec89-41c3-97e1-752a1da2a611"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("0d32ffe0-4cba-466a-b2c6-20176a232a8f"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("0d692beb-72a2-4f13-ab51-8e0501e5335f"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("1335091a-111c-4c5a-8bb1-9426efecba04"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("14101b7e-e0f9-466c-8dcf-2a8d3af2f9b3"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("16d57034-b7ac-4ca9-9793-5d153666de03"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("181f700b-43ff-438e-b4a2-61ee9a0fee0c"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("1f59ac5d-1910-4b6f-898a-8b981b9eec7c"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("22011a6a-7ab6-4ba0-981e-69b95149eb7f"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("241c5605-e77f-45ec-9113-7010bd9c4ab5"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("2530050e-9159-4d75-a0e9-261c2a144747"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("2ebb99d4-6a52-4843-965c-88520541655b"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("3607da5a-73b5-4aab-bfc5-435a3f025598"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("3aaf8d51-b732-4555-9320-75a6e1a71fec"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("3eeb8c52-d3c7-4685-99fc-63e77376eeab"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("41f2b640-9b10-4a55-85a0-18835aa8df21"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("4226d958-257c-4a4f-a7bc-6e01b9a1a839"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("47ce2080-951c-47a7-9271-8e2d506b46fc"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("47fc8ab4-62ce-4a9d-91dd-53f426de9fd3"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("49e1faca-6b57-4438-a23a-95256e2d5031"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("5c8022ef-1734-475d-abc3-39201b52f4e8"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("5c8d78cb-dece-4e67-97ec-1800dcac3c82"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("5cee5265-9c12-4663-8b46-88d6b41973e2"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("66c09598-a7a3-41d5-962e-b7bc8ada67bb"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("68c6f941-0806-4604-8eaa-8010b6563688"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("71a92a67-f0cd-4824-a70a-e030a6759567"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("90df5116-8e2b-4b0f-8ac7-d27e7de29c1d"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("9bca9ba0-f00b-4119-af71-5d2afcf47318"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("b5a90a0c-9e53-4761-a76a-e8516fc77fe4"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("baf55755-2ed2-4ef1-a677-1ec3ff28c877"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("be260856-b05c-49f5-8820-ceafcf450505"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("c19bd113-4ccd-4083-b9e0-a7652fac2232"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("c634850c-5687-46d2-8aca-0d943fbb51b8"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("c75bc95d-329f-4df1-a1cb-763e45509b08"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d3e493e0-c099-4a34-9eda-a1f907db1838"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d550bf8e-0d42-4aea-bfa2-69b6a62f33c1"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d6d60379-3fc4-4749-a6ba-885ac345ff77"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d8132d92-73aa-41c6-b2f4-85c16d771ba9"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("db254800-0c32-4fbf-a0aa-0894b90c0219"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("dbd9abd5-703b-466d-944c-5cce21350568"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e7220e48-fd30-4f5c-a449-d9a845259209"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("ea247199-3602-42f0-b89c-106f9b8b000b"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f04bc3f7-b0ad-44ef-b474-a1ca98b05964"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("f5f6bb92-2b1c-4052-8eda-92af3fd5e0be"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("fb90071e-1efb-4d62-a746-b20c8df50858"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("ff7121c4-f10e-46e4-9791-373ee116bc3b"));
        }
    }
}
