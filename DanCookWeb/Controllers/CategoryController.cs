using DanCook.Commun;
using DanCook.Donnees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanCook.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            // Crée une commande pour obtenir toutes les categories
            var cmd = new CommandLine("Get-Category");

            // Exécution de la commande en utilisant la couche données
            Data.Execute(cmd);

            //Je crée une liste pour contenir les modèles de vue des catégories
            var categorys = new List<CategoryViewModel>();

            // Itère sur les résultats de la commande et remplit la liste des modèles de vue des catégories
            foreach(var ligne in cmd.Result)
            {
                var category = new CategoryViewModel
                {
                    Id = int.Parse(ligne[0]),
                    Name = ligne[1]
                };
                categorys.Add(category);
            }
            // retourne la liste des catégories à la vue
            return View(categorys);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
