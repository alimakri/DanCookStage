using DanCookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DanCookWeb.Controllers
{
    public class ThiernoController : Controller
    {
        public string Index()
        {
            return "Hello world";
        }
        public IActionResult Index3()
        {
            var p1 = new Personne { Id = 1, Name = "Thierno"};
            return View(p1);
        }
        public IActionResult Index2()
        {
            var contenu = new ContentResult();
            contenu.ContentType = "text/html";
            contenu.Content = "<html><body><h1>Salam Aleykoum</h1></body></html>";
            return contenu;
        }
    }
}
