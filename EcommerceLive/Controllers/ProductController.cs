using EcommerceLive.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceLive.Controllers
{
    // per certificare che le informazioni provengono dal sistema
    // per evitare furto di dati all'invio del post tramite azioni malevoli
    [AutoValidateAntiforgeryToken]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = Guid.Parse("6628bc9c-4168-44fb-8f88-b8b75ccc1970"),
                Name = "Pc",
                Description = "A powerful pc",
                Category = "Electronics",
                Price = 1000,
            },
            new Product()
            {
                Id = Guid.Parse("993b12fd-9965-4600-9e6a-c78c578f8544"),
                Name = "TV",
                Description = "A powerful Tv",
                Category = "Electronics",
                Price = 700,
            },
            new Product()
            {
                Id = Guid.Parse("d73c6b22-edd2-4c3b-836e-604f86782cb9"),
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

        // Action metod per la navigazione verso la vista identificata dal file Add.cshtml
        public IActionResult Add()
        {
            return View();
        }

        // attributo
        [HttpPost]
        public IActionResult Add(AddProductModel addProductModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add");
            }

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

        [HttpGet("product/edit/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            // cerco l'oggetto tramite id nella lista statica dei prodotti
            var existingProduct = products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return RedirectToAction("Index");
            }

            var editProduct = new EditProduct()
            {
                Id = existingProduct.Id,
                Name = existingProduct.Name,
                Description = existingProduct.Description,
                Category = existingProduct.Category,
                Price = existingProduct.Price,
            };

            return View(editProduct);
        }

        [HttpPost("product/edit/save/{id:guid}")]
        public IActionResult SaveEdit(Guid id, EditProduct editProduct)
        {
            // cerco l'oggetto tramite id nella lista statica dei prodotti
            var existingProduct = products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return RedirectToAction("Index");
            }

            existingProduct.Name = editProduct.Name;
            existingProduct.Description = editProduct.Description;
            existingProduct.Category = editProduct.Category;
            existingProduct.Price = editProduct.Price;

            return RedirectToAction("Index");
        }

        [Route("product/delete/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            // cerco l'oggetto tramite id nella lista statica dei prodotti
            var existingProduct = products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return RedirectToAction("Index");
            }

            // il metodo Remove() delle liste restituisce un booleano che indica l'esito dell'operazione
            var isRemovedSuccessful = products.Remove(existingProduct);

            if (!isRemovedSuccessful)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
