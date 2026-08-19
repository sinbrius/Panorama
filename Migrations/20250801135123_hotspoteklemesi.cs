using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class hotspoteklemesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SceneId",
                table: "Panorama",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hotspots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PanoramaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TargetPanoramaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Pitch = table.Column<float>(type: "REAL", nullable: false),
                    Yaw = table.Column<float>(type: "REAL", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotspots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotspots_Panorama_PanoramaId",
                        column: x => x.PanoramaId,
                        principalTable: "Panorama",
                        principalColumn: "PanoramaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotspots_Panorama_TargetPanoramaId",
                        column: x => x.TargetPanoramaId,
                        principalTable: "Panorama",
                        principalColumn: "PanoramaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Hotspots",
                columns: new[] { "Id", "PanoramaId", "Pitch", "TargetPanoramaId", "Text", "Type", "Yaw" },
                values: new object[,]
                {
                    { 1, 1, -2.0277f, 2, "Büyükşehir Belediyesi", "scene", 98.4969f },
                    { 2, 1, -5.9475f, 5, "Ali Dağı", "scene", 164.5426f },
                    { 3, 1, -25.05315f, 0, "Erciyes Dağı", "info", -158.54025f },
                    { 4, 2, -11.672229f, 1, "Cumhuriyet Meydanı", "scene", 166.3353f },
                    { 5, 2, -25.8596f, 5, "Ali Dağı", "scene", -100.236f },
                    { 6, 2, -9.5238f, 0, "Erciyes Dağı", "info", -83.9893f },
                    { 7, 2, -48.3187f, 0, "Forum Alışveriş merkezi", "info", -97.8008f }
                });

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 1,
                column: "SceneId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 2,
                column: "SceneId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 3,
                column: "SceneId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 4,
                column: "SceneId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Panorama",
                keyColumn: "PanoramaId",
                keyValue: 5,
                column: "SceneId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Hotspots_PanoramaId",
                table: "Hotspots",
                column: "PanoramaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotspots_TargetPanoramaId",
                table: "Hotspots",
                column: "TargetPanoramaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotspots");

            migrationBuilder.DropColumn(
                name: "SceneId",
                table: "Panorama");
        }
    }
}
