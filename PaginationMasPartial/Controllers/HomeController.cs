using Microsoft.AspNetCore.Mvc;
using PaginationMasPartial.Extensions;
using PaginationMasPartial.Models;
using PaginationMasPartial.Repositories;
using System.Diagnostics;

namespace PaginationMasPartial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryUsuarios repo;

        public HomeController(ILogger<HomeController> logger, RepositoryUsuarios repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string nombre, string contrasenia)
        {
            Usuario user = this.repo.HacerLogin(nombre, contrasenia);

            if (user == null)
            {
                ViewData["ERROR"] = "bLA";
                return View();
            }
            else
            {
                HttpContext.Session.SetObject("USUARIO", user);
                ViewData["CONECTADO"] = "Estas conectado";
                return View();
                /*return RedirectToAction("ConsultaPaginado","Usuarios");*/
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}