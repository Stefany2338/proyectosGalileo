using Microsoft.AspNetCore.Mvc;
using ApiDemoAdvanced.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiDemoAdvanced.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductsV2Controller : Controller // Cambiar de ControllerBase a Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Product A", Price = 10.00M, Description = "First Product" },
            new Product { ProductId = 2, Name = "Product B", Price = 20.00M, Description = "Second Product" }
        };

        // Agrega la acción para ejecutar la vista Index.cshtml
        [HttpGet("/ViewV2/Index")]
        public IActionResult Index()
        {
            return View(); // Renderiza la vista Index.cshtml en Views/ProductsV2
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts(string filter = null, string sortBy = null, int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1)
            {
                throw new Exception("Page number must be greater than or equal to 1.");
            }

            var query = _products.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(p => p.Name.Contains(filter));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortBy switch
                {
                    "name" => query.OrderBy(p => p.Name),
                    "price" => query.OrderBy(p => p.Price),
                    _ => query.OrderBy(p => p.ProductId)
                };
            }

            var pagedProducts = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
            product.ProductId = _products.Max(p => p.ProductId) + 1;
            _products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);
            return NoContent();
        }
    }
}
