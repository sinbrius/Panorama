using HaritaWeb.Entities.Dtos;
using HaritaWeb.Repositories;
using HaritaWeb.Services;
using HaritaWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaritaWeb.UI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class PanoramaCategoryController : Controller
    {

        private readonly IServiceManager _manager;


        public PanoramaCategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        private SelectList GetIlceList()
        {
            return new SelectList(_manager.IlceService.GetAllIlce(false),"IlceId", "IlceAdi", " 1");
        }

        public IActionResult Index()
        {
            ViewBag.Ilce = GetIlceList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] PanoramaCatDtoForInsertion panoramaCat)
        {

            if (ModelState.IsValid)
            {
                _manager.panoramaCatService.CreatePanoramaCat(panoramaCat);
                return RedirectToAction("Create", "Panorama");
            }

            return View();
        }
    }
}