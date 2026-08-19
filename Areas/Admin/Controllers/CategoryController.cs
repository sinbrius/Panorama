using HaritaWeb.Entities.Dtos;
using HaritaWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HaritaWeb.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetAllCategories(false).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] CategoryDtoForInsertion categoryDto)
        {
            if (ModelState.IsValid)
            {
                _manager.CategoryService.CreateCategory(categoryDto);

                return RedirectToAction("Index");

            }
            return View();
        }
    }
}