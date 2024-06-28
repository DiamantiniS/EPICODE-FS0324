using Microsoft.AspNetCore.Mvc;
using DiamaGyms.Models;
using DiamaGyms.Repositories;

namespace DiamaGyms.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductRepository.GetAllProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = ProductRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
