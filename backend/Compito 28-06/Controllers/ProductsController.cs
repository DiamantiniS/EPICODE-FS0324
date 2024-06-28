using Microsoft.AspNetCore.Mvc;
using DiamaGyms.Models;
using DiamaGyms.Repositories;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace DiamaGyms.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> products = ProductRepository.GetAllProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product product = ProductRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.CoverImageUrl = product.CoverImageUrl;
            ViewBag.AdditionalImageUrl = product.AdditionalImageUrl;

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
                
                if (product.CoverImageFile != null)
                {
                    string fileName = Path.GetFileName(product.CoverImageFile.FileName);
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", fileName);
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        product.CoverImageFile.CopyTo(stream);
                    }
                    product.CoverImageUrl = "/uploads/" + fileName;
                }

                if (product.AdditionalImageFile != null)
                {
                    string fileName = Path.GetFileName(product.AdditionalImageFile.FileName);
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", fileName);
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        product.AdditionalImageFile.CopyTo(stream);
                    }
                    product.AdditionalImageUrl = "/uploads/" + fileName;
                }

                ProductRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
