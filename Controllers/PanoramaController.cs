using HaritaWeb.Entities.Models;
using HaritaWeb.Services;
using HaritaWeb.Services.Contracts;
using HaritaWeb.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaritaWeb.UI.Controllers
{
    public class PanoramaController : Controller
    {
        private readonly IServiceManager _manager;
        public PanoramaController(IServiceManager manager)
        {
            _manager = manager;
        }




        public IActionResult GetOnePanorama(int panoramaId)
        {
            try
            {
                var panorama = _manager.PanoramaService.GetPanoramabyId(panoramaId, false);

                if (panorama == null)
                    return Json(new { success = false, message = "Panorama bulunamadı" });

                // İlişkili hotspotları çek
                var hotspots = _manager.HotspotsService.GetHotspotsbyPanoramaId(panoramaId, false);

                return Json(new
                {
                    success = true,
                    filepath = panorama.PanoramaYolu,
                    filename = panorama.PanoramaAd,
                    filedate = panorama.Tarih,
                    hotspots = hotspots.Select(h => new
                    {
                        h.Id,
                        h.Pitch,
                        h.Yaw,
                        h.Type,
                        h.Text,
                        h.TargetPanoramaId
                    })
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        public IActionResult GetCatByIlceId(int ilceId)
        {
            var catList = _manager.panoramaCatService.GetCatbyIlceId(ilceId, false).ToList()
                .Select(m => new SelectListItem
                {
                    Value = m.PanoramaKategoriId.ToString(),
                    Text = m.PanoramaKategoriAdı
                }).ToList();

            return Json(catList);
        }

        [HttpGet]
        public IActionResult GetAllPanoramas()
        {
            var panoramas = _manager.PanoramaService.GetAllPanorama(false); // Burada false lazy loading veya tracking'i kontrol eder

            var data = panoramas.Select(p => new
            {
                PanoramaId = p.PanoramaId,
                PanoramaCategory=p.PanoramaKategoriId,
                PanoramaAd = p.PanoramaAd,
                PanoramaYolu = p.PanoramaYolu,
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                PanoramaKategoriId = p.PanoramaKategoriId,
                // İstersen Tarih vs ekleyebilirsin
            }).ToList();

            return Json(data);
        }

        public IActionResult GetHotspotsAll()
        {
            var hotspots = _manager.HotspotsService.GetHotspotsAll(false);
            var data = hotspots.Select(h => new
            {
                h.Id,
                h.PanoramaId,
                h.Pitch,
                h.Yaw,
                h.Type,
                h.Text,
                h.TargetPanoramaId
            });
            return Json(data);
        }

        public IActionResult Index()
        {
            var ılce = _manager.IlceService.GetAllIlce(false).ToList();
            var panorama = _manager.PanoramaService.GetAllPanorama(false).ToList();
            var category = _manager.panoramaCatService.GetAllCat(false).ToList();

            var viewmodel = new IlcePanoramaViewModel
            {
                Categories = category,
                Panorama = panorama,
                Ilce = ılce
            };

            return View(viewmodel);
        }
    }
}