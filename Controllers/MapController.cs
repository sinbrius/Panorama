using HaritaWeb.Entities.Models;
using HaritaWeb.Repositories;
using HaritaWeb.Repositories.Contracts;
using HaritaWeb.Services.Contracts;
using HaritaWeb.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaritaWeb.UI.Controllers
{
    public class MapController : Controller
    {
        private readonly RepositoryContext _context;
        private readonly IServiceManager _manager;

        public MapController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }
        public IActionResult GetMapByCategoryMahalle(int categoryId, int ilceId, int mahalleId)
        {
            var map = _manager.MapService
                .GetAllMaps(false)
                .FirstOrDefault(m =>
                    m.KategoriId == categoryId &&
                    m.MahalleId == mahalleId &&
                    m.Mahalle.IlceId == ilceId);

            if (map == null)
                return Json(new { success = false, message = "Harita bulunamadı." });

            return Json(new { filePath = map.DosyaYolu });
        }
        public IActionResult Index()
        {
            ViewBag.Ilce = new SelectList(_manager.IlceService.GetAllIlce(false), "IlceId", "IlceAdi", "1");
            var map = _manager.MapService.GetAllMaps(false).ToList();
            var category = _manager.CategoryService.GetAllCategories(false).ToList();

            var viewmodel = new MapCategoryViewModel
            {
                Maps = map,
                Categories = category
            };

            return View(viewmodel);
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            Harita? map = _manager.MapService.GetOneMap(id, false);

            if (map == null)
            {
                return NotFound(); // veya başka bir yönlendirme, hata sayfası vs.
            }

            return View(map);

        }
    }
}