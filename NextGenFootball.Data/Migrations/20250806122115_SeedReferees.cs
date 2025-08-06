using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedReferees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Referees",
                columns: new[] { "Id", "ApplicationUserId", "Email", "FirstName", "ImageUrl", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("5d9f7f6a-3f8a-4e65-bf97-1c5a2f1e2a10"), null, "georgi.kabakov@ref.bg", "Georgi", null, "Kabakov", "0889123456" },
                    { new Guid("a2c8e7f9-6e5d-4b4a-8c3e-5f7d9f6b4e54"), null, "dimitar.mihaylov@ref.bg", "Dimitar", null, "Mihaylov", "0897123456" },
                    { new Guid("b3e9e6b0-8f4c-4a6c-8d7e-4f9e8e7c3d43"), null, "petar.krastev@ref.bg", "Petar", null, "Krastev", "0888123456" },
                    { new Guid("cc5a9e88-d7f4-4c6e-9e8b-3e7f9f8d2b32"), null, "nikola.popov@ref.bg", "Nikola", null, "Popov", "0877123456" },
                    { new Guid("f2b7e3d0-4c2a-4b31-9e7a-2d4f7e6b8c21"), null, "ivan.stoyanov@ref.bg", "Ivan", null, "Stoyanov", "0898123456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: new Guid("5d9f7f6a-3f8a-4e65-bf97-1c5a2f1e2a10"));

            migrationBuilder.DeleteData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: new Guid("a2c8e7f9-6e5d-4b4a-8c3e-5f7d9f6b4e54"));

            migrationBuilder.DeleteData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: new Guid("b3e9e6b0-8f4c-4a6c-8d7e-4f9e8e7c3d43"));

            migrationBuilder.DeleteData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: new Guid("cc5a9e88-d7f4-4c6e-9e8b-3e7f9f8d2b32"));

            migrationBuilder.DeleteData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: new Guid("f2b7e3d0-4c2a-4b31-9e7a-2d4f7e6b8c21"));
        }
    }
}
