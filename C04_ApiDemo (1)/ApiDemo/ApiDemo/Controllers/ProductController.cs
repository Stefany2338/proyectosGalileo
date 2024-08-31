using ApiDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MyApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Product A", Price = 10.00M },
            new Product { ProductId = 2, Name = "Product B", Price = 20.00M }
        };

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_products);
        }

        // GET: api/products/1
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

        // POST: api/products
        [HttpPost]
        [Authorize]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
            product.ProductId = _products.Max(p => p.ProductId) + 1;
            _products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            return NoContent();
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        [Authorize]
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