using Microsoft.AspNetCore.Mvc;
using Testing.Models;
using Testing.Models.Data;

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo; // replace this with _repo
        public ProductController(IProductRepository repo)
        {
            this.repo = repo; // can replace this.repo with _repo
        }

        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);
            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }
    }
}
