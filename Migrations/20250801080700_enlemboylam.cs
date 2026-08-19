using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class enlemboylam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Panorama",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Panorama",
                type: "REAL",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Panorama");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Panorama");
        }
    }
}
