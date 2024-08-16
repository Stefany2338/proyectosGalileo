using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    public class CrearController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
