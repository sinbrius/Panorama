let viewer;
function panoramaLoad(id) {
  fetch("/Panorama/GetAllPanoramas")
    .then((res) => res.json())
    .then((panoramas) => {
      if (!panoramas || panoramas.length === 0) {
        console.error("Hiç panorama gelmedi.");
        return;
      }

      let scenes = {};

      panoramas.forEach((p) => {
        scenes[p.panoramaId] = {
          title: p.panoramaAd,
          type: "multires",
          multiRes: {
            basePath: p.panoramaYolu,
            path: "/%l/%s%y_%x",
            fallbackPath: "/fallback/%s",
            extension: "jpg",
            tileResolution: 512,
            maxLevel: 4,
            cubeResolution: 2600,
          },
          hotSpots: [],
        };
      });

      fetch("/Panorama/GetHotspotsAll")
        .then((res) => res.json())
        .then((hotspots) => {
          hotspots.forEach((h) => {
            if (scenes[h.panoramaId]) {
              const targetId = h.targetPanoramaId
                ? h.targetPanoramaId.toString()
                : undefined;

              scenes[h.panoramaId].hotSpots.push({
                pitch: h.pitch,
                yaw: h.yaw,
                type: h.type || "info",
                text: h.text || "",
                sceneId: targetId,
              });
            }
          });
          console.log("İlk panorama:", panoramas[0]);

          if (viewer) {
            viewer.destroy();
          }

          viewer = pannellum.viewer("panorama", {
            default: {
              firstScene: id.toString(),
              sceneFadeDuration: 1000,
              pitch: -12,
              hfov: 180,
              autoLoad: true,
              autoRotate: 3,
              showControls: false,
            },
            scenes: scenes,
          });
          viewer.on("scenechange", function (sceneId) {
            const pano = panoramas.find(
              (p) => p.panoramaId.toString() === sceneId
            );
            if (pano) {
              loadImages(pano.panoramaCategory);
            }
          });
          setUpControl();
          closeSidebar();
        });
    });
}

function closeSidebar() {
  const sidebar = document.getElementById("panorama-sidebar");
  const menuBtn = document.getElementById("menu-btn");

  sidebar.classList.remove("active");
  menuBtn.classList.remove("shifted");
}

document.addEventListener("DOMContentLoaded", function () {
  panoramaLoad(1);
});
function setUpControl() {
  const overviewmenu = document.getElementById("overviewmenu");

  document.getElementById("pan-up")?.addEventListener("click", function () {
    viewer.setPitch(viewer.getPitch() + 10);
  });
  document.getElementById("pan-down")?.addEventListener("click", function () {
    viewer.setPitch(viewer.getPitch() - 10);
  });
  document.getElementById("pan-left")?.addEventListener("click", function () {
    viewer.setYaw(viewer.getYaw() - 10);
  });
  document.getElementById("pan-right")?.addEventListener("click", function () {
    viewer.setYaw(viewer.getYaw() + 10);
  });
  document.getElementById("zoom-in")?.addEventListener("click", function () {
    viewer.setHfov(viewer.getHfov() - 10);
  });
  document.getElementById("zoom-out")?.addEventListener("click", function () {
    viewer.setHfov(viewer.getHfov() + 10);
  });
  document.getElementById("fullscreen")?.addEventListener("click", function () {
    viewer.toggleFullscreen();
  });
}
document.getElementById("img-btn")?.addEventListener("click", function () {
  const overviewmenu = document.getElementById("controls");
  overviewmenu.classList.toggle("hidden");
});

function toggleSidebar() {
  const sidebar = document.getElementById("panorama-sidebar");
  const menubtn = document.getElementById("menu-btn");
  sidebar.classList.toggle("active");
  menubtn.classList.toggle("shifted");
}

function toggleMap() {
  const map = document.getElementById("map");
  const mapbtn = document.getElementById("map-btn");
  map.classList.toggle("active");
  mapbtn.classList.toggle("shifted");
}

document.querySelectorAll(".ilce-label").forEach((label) => {
  label.addEventListener("click", function () {
    const kategoriListesi = this.nextElementSibling;

    // Tüm açık alt listeleri kapat
    document.querySelectorAll(".kategori-listesi").forEach((ul) => {
      if (ul !== kategoriListesi) {
        ul.style.display = "none";
      }
    });

    // Tıklanan listeyi aç/kapat
    if (
      kategoriListesi.style.display === "none" ||
      kategoriListesi.style.display === ""
    ) {
      kategoriListesi.style.display = "block";
    } else {
      kategoriListesi.style.display = "none";
    }
  });
});
