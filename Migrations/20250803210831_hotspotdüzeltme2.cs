using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class hotspotdüzeltme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { 1.45f, -135.15f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -12f, -103.43359f });
        }
    }
}
