using HaritaWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaritaWeb.UI.Controllers
{
    public class MahalleController : Controller
    {
         private readonly IServiceManager _manager;

        public MahalleController(IServiceManager manager)
        {
            _manager = manager;
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
        public IActionResult Index()
        {
            var mahalle = _manager.MahalleService.GetAllMahalle(false).ToList();

            return View(mahalle);
        }
    }
}