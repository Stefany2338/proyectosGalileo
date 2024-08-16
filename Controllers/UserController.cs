using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    public class UserController : Controller
    {
        private static List<UserModel> users = new List<UserModel> {
            new UserModel { id = 1, userName = "Joaquin", password = "123456" },
            new UserModel { id = 2, userName = "Cindy", password = "123456" },
            new UserModel { id = 3, userName = "Jorge", password = "123456" },
            new UserModel { id = 4, userName = "Filomena", password = "123456" },
            new UserModel { id = 5, userName = "Panfilo", password = "123456" }
        };

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View(users);
        }

        //POST:
        [HttpPost]
        public IActionResult Index(UserModel newUser) {
            if (ModelState.IsValid) {
                users.Add(newUser);
                return RedirectToAction("Index");
            }
            return View(users);
        }

        
    }
}

