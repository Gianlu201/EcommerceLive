using EcommerceLive.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceLive.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Pc",
                Description = "A powerful pc",
                Category = "Electronics",
                Price = 1000,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "TV",
                Description = "A powerful Tv",
                Category = "Electronics",
                Price = 700,
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Book",
                Description = "A nice book",
                Category = "Literature",
                Price = 20,
            },
        };

        public IActionResult Index()
        {
            var productsList = new ProductsViewModel() { Products = products };
            return View(productsList);
        }

        public IActionResult Add()
        {
            return View();
        }

        // attributo
        [HttpPost]
        public IActionResult Add(AddProductModel addProductModel)
        {
            var newProduct = new Product()
            {
                Id = Guid.NewGuid(),
                Name = addProductModel.Name,
                Description = addProductModel.Description,
                Category = addProductModel.Category,
                Price = addProductModel.Price,
            };

            products.Add(newProduct);

            // Il controller non viene passato perché è già il presente
            return RedirectToAction("Index");
        }
    }
}
