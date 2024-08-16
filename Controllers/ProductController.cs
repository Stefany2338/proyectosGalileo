using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers
{
    public class ProductController : Controller
    {

        private static List<ProductModel> products = new List<ProductModel>
        {
            new ProductModel { id=01, name="Red watch", description="Very nice", existencia=10, precio=1000 },
            new ProductModel { id=02, name="Green watch", description="Super cute", existencia=7, precio=1500 },
            new ProductModel { id=03, name="Blue watch", description="So pretty", existencia=5, precio=2000 }

        };


        [HttpGet]
        public IActionResult Index()
        {
            return View(products);
        }

        /*
        public IActionResult Index()
        {
            return View();
        }

        */


        [HttpPost]

        public IActionResult Product(ProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                products.Add(newProduct);
                return RedirectToAction("Index");
            }
            return View(products);
        }


    }
}
