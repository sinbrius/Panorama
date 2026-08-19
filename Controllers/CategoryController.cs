using HaritaWeb.Repositories;
using HaritaWeb.Repositories.Contracts;
using HaritaWeb.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HaritaWeb.UI.Controllers
{
    public class CategoryController:Controller
    {
        private readonly RepositoryContext _context;
         private readonly IServiceManager _manager;

        public CategoryController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }



        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetAllCategories(false).ToList();
            return View(model);
            
        } 

    }
}