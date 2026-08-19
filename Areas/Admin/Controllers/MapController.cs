using HaritaWeb.Entities.Dtos;
using HaritaWeb.Entities.Models;
using HaritaWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaritaWeb.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MapController : Controller
    {
        private readonly IServiceManager _manager;

        public MapController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(string searchTerm)
        {
            var maps = _manager.MapService.GetAllMaps(false).ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                maps = maps.Where(m => m.HaritaAdı.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.SearchTerm = searchTerm;


            return View(maps);
        }
        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.Mahalle = GetMahalleSelectList();
            ViewBag.Ilce = GetIlceSelectList();
            ViewBag.Categories = GetCategoriesSelectList();

            return View();
        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.MapService.DeleteOneMap(id);
            return RedirectToAction("Index");
        }
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "KategoriId", "KategoriAdı", "1");
        }
        private SelectList GetMahalleSelectList()
        {
            return new SelectList(_manager.MahalleService.GetAllMahalle(false), "MahalleId", "MahalleAdi", "1");
        }
        private SelectList GetIlceSelectList()
        {
            return new SelectList(_manager.IlceService.GetAllIlce(false), "IlceId", "IlceAdi", " 1");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] MapDtoForInsertion mapDto)
        {
            if (ModelState.IsValid)
            {
                _manager.MapService.CreateMap(mapDto);

                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Mahalle = GetMahalleSelectList();
            ViewBag.Ilce = GetIlceSelectList();
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.MapService.GetOneMapForUpdate(id, false);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] MapDtoForUpdate map)
        {
            _manager.MapService.UpdateOneMap(map);
            return RedirectToAction("Index");
        }
    }
}