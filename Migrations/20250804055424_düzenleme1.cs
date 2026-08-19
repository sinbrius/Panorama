using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class düzenleme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -2.05f, 163.5426f });

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { 4.74f, -132.89f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -5.9475f, 164.5426f });

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { 1.45f, -135.15f });
        }
    }
}
