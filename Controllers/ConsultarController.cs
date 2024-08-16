using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    public class ConsultarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
