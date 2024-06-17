using DanCook.Commun;
using DanCook.Donnees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DanCookWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        // Action pour lister tous les produits
        public ActionResult Index()
        {
            // Crée une commande pour obtenir tous les produits
            var cmd = new CommandLine("Get_Product");

            // Exécute la commande en utilisant la couche de données
            Data.Execute(cmd);

            // Crée une liste pour contenir les modèles de vue des produits
            var products = new List<ProductViewModel>();

            // Itère sur les résultats de la commande et remplit la liste des modèles de vue des produits
            foreach (var ligne in cmd.Result)
            {
                var product = new ProductViewModel
                {
                    Id = int.Parse(ligne[0]),
                    Name = ligne[1],
                    ListPrice = decimal.Parse(ligne[2]),
                    SubCategory = ligne[3],
                    Category = ligne[4]
                };
                products.Add(product);
            }

            // Passe la liste des produits à la vue
            return View(products);
        }

        // GET: ProductController/Details/5
        // Action pour afficher les détails d'un produit spécifique par id
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        // Action pour afficher le formulaire de création d'un produit
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        // Action pour gérer la soumission du formulaire de création d'un nouveau produit
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

        // GET: ProductController/Edit/5
        // Action pour afficher le formulaire d'édition d'un produit
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        // Action pour gérer la soumission du formulaire d'édition d'un produit
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

        // GET: ProductController/Delete/5
        // Action pour afficher la confirmation de suppression d'un produit
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        // Action pour gérer la soumission du formulaire de suppression d'un produit
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

    // ViewModel pour représenter les données des produits dans la vue
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }
        public string SubCategory { get; set; }
        public string Category { get; set; }
    }
}
