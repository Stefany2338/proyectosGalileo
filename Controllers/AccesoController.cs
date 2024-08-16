using Microsoft.AspNetCore.Mvc;
using Test.Models;


namespace Test.Controllers
{
    public class AccesoController : Controller
    {

        private static Usuario _usuario = new Usuario();

        //para que muestre la vista del inicio de sesion 
        public IActionResult Index()
        {
            return View("view");
        }

        //para mostrar la vista del registro
        public IActionResult Registrar()
        {
            return View("view1");
        }

        public IActionResult Inicio()
        {
            return View("Home.Index");
        }


        //-----------formulario

        //formulario de registro
        [HttpPost]

        public IActionResult Registrar(Usuario oUsuario)
        {
            if (oUsuario.Clave == oUsuario.ConfirmarClave)
            {
                _usuario.Nombre = oUsuario.Nombre;
                _usuario.Clave = oUsuario.Clave;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Mensaje"] = "Las claves que ingresaste no son correctas";
                return View("view1");
            }
        }

        //formulario de inicio de sesion
        [HttpPost]

        public IActionResult Login(Usuario oUsuario)
        {
            if (_usuario.Nombre == oUsuario.Nombre && _usuario.Clave == oUsuario.Clave)
            {
                ViewData["Mensaje"] = "Inicio de sesion exioso:)";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "La clave o el nombre son incorrectos, ingresalos de nuevo";
                return View("view");
            }
        }
    }
}
