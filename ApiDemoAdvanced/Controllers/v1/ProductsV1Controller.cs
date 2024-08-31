using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemoAdvanced.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoAdvanced.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductsV1Controller : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Product A", Price = 10.00M },
            new Product { ProductId = 2, Name = "Product B", Price = 20.00M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts(int pageNumber = 1, int pageSize = 10)
        {
            var pagedProducts = _products.Skip((pageNumber - 1) * pageSize).Take(pageSize);
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

