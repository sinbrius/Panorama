using HaritaWeb.Entities.Dtos;
using HaritaWeb.Services;
using HaritaWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaritaWeb.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MahalleController : Controller
    {
        private readonly IServiceManager _manager;

        public MahalleController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var mahalle = _manager.MahalleService.GetAllMahalle(false).ToList();
            return View(mahalle);
        }
        public IActionResult GetMahalleByIlceId(int ilceId)
        {
            var mahalleList = _manager.MahalleService.GetMahalleByIlceId(ilceId, trackChanges: false)
                .Select(m => new SelectListItem
                {
                    Value = m.MahalleId.ToString(),
                    Text = m.MahalleAdi
                }).ToList();

            return Json(mahalleList);
        }

        public IActionResult Create()
        {
            ViewBag.Ilce = new SelectList(_manager.IlceService.GetAllIlce(false), "IlceId", "IlceAdi", "1");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] MahalleDtoForInsertion mahalleDto)
        {
            if (ModelState.IsValid)
            {
                _manager.MahalleService.CreateMahalle(mahalleDto);

                return RedirectToAction("Create");

            }
            return View();
        }
    }
}