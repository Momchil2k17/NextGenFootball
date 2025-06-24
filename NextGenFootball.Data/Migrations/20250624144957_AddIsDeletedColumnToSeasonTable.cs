using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextGenFootball.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedColumnToSeasonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Seasons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Seasons");
        }
    }
}
