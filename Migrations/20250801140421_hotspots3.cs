using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class hotspots3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotspots",
                columns: new[] { "Id", "PanoramaId", "Pitch", "TargetPanoramaId", "Text", "Type", "Yaw" },
                values: new object[,]
                {
                    { 3, 1, -25.05315f, null, "Erciyes Dağı", "info", -158.54025f },
                    { 4, 2, -11.672229f, 1, "Cumhuriyet Meydanı", "scene", 166.3353f },
                    { 5, 2, -25.8596f, 5, "Ali Dağı", "scene", -100.236f },
                    { 6, 2, -9.5238f, null, "Erciyes Dağı", "info", -83.9893f },
                    { 7, 2, -48.3187f, null, "Forum Alışveriş merkezi", "info", -97.8008f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotspots",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
