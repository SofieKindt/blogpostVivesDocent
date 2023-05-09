using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VivesBlog.Ui.Mvc.Core;
using VivesBlog.Ui.Mvc.Models;

namespace VivesBlog.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly VivesBlogDatabase _database;

        public HomeController(VivesBlogDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var articles = _database.Articles;
            return View(articles);
        }

        [HttpGet]
        public IActionResult Read([FromRoute]int id)
        {
            var articles = _database.Articles;
            var article = articles.FirstOrDefault(a => a.Id == id);

            if (article is null)
            {
                return RedirectToAction("Index");
            }

            return View(article);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}