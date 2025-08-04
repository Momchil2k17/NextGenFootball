using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoaches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "ImageUrl", "LastName", "PhoneNumber", "Role", "TeamId" },
                values: new object[,]
                {
                    { new Guid("5e8c2a51-8d6f-4013-bd8f-3fae16b2a803"), null, "Alex", "https://img.a.transfermarkt.technology/portrait/header/_1344344740.jpg?lm=1", "Ferguson", "+359888555666", 1, 3 },
                    { new Guid("b2fa78d3-0e5d-46e2-bc2e-2a9f0d8f5c02"), null, "José", "https://img.a.transfermarkt.technology/portrait/header/781-1717168225.jpg?lm=1", "Mourinho", "+359888333444", 1, 2 },
                    { new Guid("e6b7a0b8-9f40-4c26-9a9d-1a1e6b2f1a01"), null, "Jürgen", "https://img.a.transfermarkt.technology/portrait/big/118-1736865351.jpg?lm=1", "Klopp", "+359888111222", 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: new Guid("5e8c2a51-8d6f-4013-bd8f-3fae16b2a803"));

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: new Guid("b2fa78d3-0e5d-46e2-bc2e-2a9f0d8f5c02"));

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: new Guid("e6b7a0b8-9f40-4c26-9a9d-1a1e6b2f1a01"));
        }
    }
}
