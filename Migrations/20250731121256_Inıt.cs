using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HaritaWeb.UI.Migrations
{
    /// <inheritdoc />
    public partial class Inıt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    IlceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IlceAdi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.IlceId);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KategoriAdı = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Mahalle",
                columns: table => new
                {
                    MahalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MahalleAdi = table.Column<string>(type: "TEXT", nullable: false),
                    IlceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalle", x => x.MahalleId);
                    table.ForeignKey(
                        name: "FK_Mahalle_Ilce_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilce",
                        principalColumn: "IlceId");
                });

            migrationBuilder.CreateTable(
                name: "PanoramaKategori",
                columns: table => new
                {
                    PanoramaKategoriId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PanoramaKategoriAdı = table.Column<string>(type: "TEXT", nullable: false),
                    IlceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanoramaKategori", x => x.PanoramaKategoriId);
                    table.ForeignKey(
                        name: "FK_PanoramaKategori_Ilce_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilce",
                        principalColumn: "IlceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harita",
                columns: table => new
                {
                    HaritaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HaritaAdı = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true),
                    DosyaYolu = table.Column<string>(type: "TEXT", nullable: false),
                    DosyaTipi = table.Column<string>(type: "TEXT", nullable: false),
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: true),
                    MahalleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harita", x => x.HaritaId);
                    table.ForeignKey(
                        name: "FK_Harita_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId");
                    table.ForeignKey(
                        name: "FK_Harita_Mahalle_MahalleId",
                        column: x => x.MahalleId,
                        principalTable: "Mahalle",
                        principalColumn: "MahalleId");
                });

            migrationBuilder.CreateTable(
                name: "Panorama",
                columns: table => new
                {
                    PanoramaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PanoramaAd = table.Column<string>(type: "TEXT", nullable: false),
                    PanoramaYolu = table.Column<string>(type: "TEXT", nullable: false),
                    PanoramaKategoriId = table.Column<int>(type: "INTEGER", nullable: false),
                    PanoramaResimYolu = table.Column<string>(type: "TEXT", nullable: true),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panorama", x => x.PanoramaId);
                    table.ForeignKey(
                        name: "FK_Panorama_PanoramaKategori_PanoramaKategoriId",
                        column: x => x.PanoramaKategoriId,
                        principalTable: "PanoramaKategori",
                        principalColumn: "PanoramaKategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ilce",
                columns: new[] { "IlceId", "IlceAdi" },
                values: new object[,]
                {
                    { 1, "Sehir Merkezi" },
                    { 2, "Akkışla" },
                    { 3, "Bünyan" },
                    { 4, "Develi" },
                    { 5, "Felahiye" },
                    { 6, "Hacılar" },
                    { 7, "İncesu" },
                    { 8, "Kocasinan" },
                    { 9, "Melikgazi" },
                    { 10, "Özvatan" },
                    { 11, "Pınarbaşı" },
                    { 12, "Sarıoğlan" },
                    { 13, "Sarız" },
                    { 14, "Talas" },
                    { 15, "Tomarza" },
                    { 16, "Yahyalı" },
                    { 17, "Yeşilhisar" }
                });

            migrationBuilder.InsertData(
                table: "Kategori",
                columns: new[] { "KategoriId", "KategoriAdı" },
                values: new object[,]
                {
                    { 1, "Kayseri Büyüksehir Belediye Sınırı" },
                    { 2, "Kayseri İl Sınırı 2020" },
                    { 3, "2025 Yılı Kayseri Kent Merkezi ve Çevresi" }
                });

            migrationBuilder.InsertData(
                table: "Harita",
                columns: new[] { "HaritaId", "Aciklama", "DosyaTipi", "DosyaYolu", "HaritaAdı", "KategoriId", "MahalleId" },
                values: new object[,]
                {
                    { 1, "", ".pdf", "https://cbs.kayseri.bel.tr/PDF/KAYSERI_BUYUKSEHIR_BELEDIYE_SINIRI.pdf", "Kayseri_Buyuksehir_Belediye_Sınırı", 1, null },
                    { 2, "", ".jpg", "https://cbs.kayseri.bel.tr/dosya/cbs/harita/KayseriIlHaritasi2019.jpg", "Kayseri_İl_Sınırı_2020", 2, null },
                    { 3, "", ".pdf", "https://cbs.kayseri.bel.tr/PDF/KENT_REHBERI_1_5000_OLCEKLI_1400X3500_BOYUTLU_2025.PDF", "KENT_REHBERI_1_5000_OLCEKLI_1400X3500_BOYUTLU_2025", 3, null },
                    { 4, "", ".pdf", "https://cbs.kayseri.bel.tr/PDF/KENT_REHBERI_1_7500_OLCEKLI_900X2850_BOYUTLU_GUNEY_2025.PDF", "KENT_REHBERI_1_7500_OLCEKLI_900X2850_BOYUTLU_GUNEY_2025", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Mahalle",
                columns: new[] { "MahalleId", "IlceId", "MahalleAdi" },
                values: new object[,]
                {
                    { 1, 1, "Alevkışla" },
                    { 2, 1, "Akin" },
                    { 3, 1, "Ganişeyh" }
                });

            migrationBuilder.InsertData(
                table: "PanoramaKategori",
                columns: new[] { "PanoramaKategoriId", "IlceId", "PanoramaKategoriAdı" },
                values: new object[,]
                {
                    { 1, 1, "Cumhuriyet Meydanı" },
                    { 2, 1, "Büyükşehir Belediyesi" },
                    { 3, 1, "Bilim Merkezi" },
                    { 4, 7, "İncesu Meydan" }
                });

            migrationBuilder.InsertData(
                table: "Panorama",
                columns: new[] { "PanoramaId", "PanoramaAd", "PanoramaKategoriId", "PanoramaResimYolu", "PanoramaYolu", "Tarih" },
                values: new object[,]
                {
                    { 1, "Cumhuriyet Meydanı", 1, "/img/multires/cumhuriyet_meydanı/cumhuriyetmeydanı.jpg", "/img/multires/cumhuriyet_meydanı/tiles", new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Büyükşehir Belediyesi", 1, "/img/multires/360belediye/buyuksehirbelediye.jpg", "/img/multires/360belediye/tiles", new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Bilim Merkezi", 3, "/img/multires/360_bilim_merkezi/overview_map.jpg", "/img/multires/360_bilim_merkezi/tiles", new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "İncesu Meydan-1", 1, "/img/multires/360_drone_incesu/incesumeydan.jpg", "/img/multires/360_drone_incesu/tiles", new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Ali Dağı", 1, "/img/multires/360_drone_alidagtepe/alidağtepe.jpg", "/img/multires/360_drone_alidagtepe/tiles", new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Harita_KategoriId",
                table: "Harita",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Harita_MahalleId",
                table: "Harita",
                column: "MahalleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mahalle_IlceId",
                table: "Mahalle",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Panorama_PanoramaKategoriId",
                table: "Panorama",
                column: "PanoramaKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_PanoramaKategori_IlceId",
                table: "PanoramaKategori",
                column: "IlceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harita");

            migrationBuilder.DropTable(
                name: "Panorama");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Mahalle");

            migrationBuilder.DropTable(
                name: "PanoramaKategori");

            migrationBuilder.DropTable(
                name: "Ilce");
        }
    }
}
