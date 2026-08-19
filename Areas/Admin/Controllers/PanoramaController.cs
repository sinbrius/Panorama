using HaritaWeb.Entities.Dtos;
using HaritaWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaritaWeb.UI.Areas.Admin
{

    [Area("Admin")]
    public class PanoramaController : Controller
    {

        private readonly IServiceManager _manager;

        public PanoramaController(IServiceManager manager)
        {
            _manager = manager;
        }

        private SelectList GetCategorySelectList()
        {
            return new SelectList(_manager.panoramaCatService.GetAllCat(false), "PanoramaKategoriId", "PanoramaKategoriAdı", "1");
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategorySelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] PanoramaDtoForInsertion panoramaDto)
        {

            if (ModelState.IsValid)
            {
                _manager.PanoramaService.CreatePanorama(panoramaDto);

                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Index(string searchTerm)
        {
            var panorama = _manager.PanoramaService.GetAllPanorama(false).ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                panorama = panorama.Where(m => m.PanoramaAd.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.SearchTerm = searchTerm;

            return View(panorama);
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {

            ViewBag.Categories = GetCategorySelectList();
            var model = _manager.PanoramaService.GetOnePanorama(id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] PanoramaDtoForUpdate panoramaDto)
        {
            if (ModelState.IsValid)
            {
            _manager.PanoramaService.UpdatePanorama(panoramaDto);
            return RedirectToAction("Index");
                
            }
            return View();
        }

        public IActionResult Delete([FromRoute(Name ="id")] int id)
        {
            
            _manager.PanoramaService.DeletePanorama(id);

            return RedirectToAction("Index");
        }
    }
}