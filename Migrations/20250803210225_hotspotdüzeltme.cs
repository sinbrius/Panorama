using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class hotspotdüzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -12f, -103.43359f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -25.05315f, -158.54025f });
        }
    }
}
