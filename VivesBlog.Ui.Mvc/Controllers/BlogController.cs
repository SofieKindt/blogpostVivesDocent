using Microsoft.AspNetCore.Mvc;
using VivesBlog.Ui.Mvc.Core;
using VivesBlog.Ui.Mvc.Models;

namespace VivesBlog.Ui.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly VivesBlogDatabase _database;

        public BlogController(VivesBlogDatabase database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            var articles = _database.Articles;
            return View(articles);
        }
        
    }
}