using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class düzenleme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -2.51f, 169.85f });

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { 0.3f, -138.69f });

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -8.9f, -182.96f });

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -2.1f, -108.71f });

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { 0.3f, -67.73f });

            migrationBuilder.InsertData(
                table: "Hotspots",
                columns: new[] { "Id", "PanoramaId", "Pitch", "TargetPanoramaId", "Text", "Type", "Yaw" },
                values: new object[] { 8, 1, -29.45f, null, "Cumhuriyet Meydanı", "info", -135.12f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 8);

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

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -11.672229f, 166.3353f });

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -25.8596f, -100.236f });

            migrationBuilder.UpdateData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Pitch", "Yaw" },
                values: new object[] { -9.5238f, -83.9893f });
        }
    }
}
