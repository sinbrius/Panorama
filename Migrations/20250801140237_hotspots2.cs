using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class hotspots2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "TargetPanoramaId",
                table: "Hotspots",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PanoramaId",
                table: "Hotspots",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TargetPanoramaId",
                table: "Hotspots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PanoramaId",
                table: "Hotspots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Hotspots",
                columns: new[] { "Id", "PanoramaId", "Pitch", "TargetPanoramaId", "Text", "Type", "Yaw" },
                values: new object[,]
                {
                    { 3, 1, -25.05315f, 0, "Erciyes Dağı", "info", -158.54025f },
                    { 4, 2, -11.672229f, 1, "Cumhuriyet Meydanı", "scene", 166.3353f },
                    { 5, 2, -25.8596f, 5, "Ali Dağı", "scene", -100.236f },
                    { 6, 2, -9.5238f, 0, "Erciyes Dağı", "info", -83.9893f },
                    { 7, 2, -48.3187f, 0, "Forum Alışveriş merkezi", "info", -97.8008f }
                });
        }
    }
}
