using Microsoft.AspNetCore.Mvc;
using PaginationMasPartial.Models;
using PaginationMasPartial.Repositories;

namespace PaginationMasPartial.Controllers
{
    public class UsuariosController : Controller
    {
        private RepositoryArticulos repo;

        public UsuariosController(RepositoryArticulos repo)
        {
            this.repo = repo;
        }

        public IActionResult ConsultaPaginado()
        {
            ViewData["TOTAL"] = this.repo.TotalArticulos();
            return View();
        }

        [HttpPost("Usuarios/ConsultaPaginado")]
        [HttpGet("Usuarios/ConsultaPaginado/{posicion}/{registrospagina}")]
        public IActionResult ConsultaPaginado(int registrospagina, int? posicion)
        {
            if (posicion == null)
            {
                posicion = 1;
            }

            ViewData["TOTAL"] = this.repo.TotalArticulos();
            ViewData["REGISTROPAGINA"] = registrospagina;

            List<Articulo> articulosxpagina = this.repo.ListaArticulos(registrospagina, posicion.Value);
            return View(articulosxpagina);
        }
    }
}
