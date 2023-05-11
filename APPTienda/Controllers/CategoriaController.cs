using APPTienda.Data;
using APPTienda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APPTienda.Controllers
{
    public class CategoriaController : Controller
    {
        public readonly TiendaDbContext _context;

        public CategoriaController (TiendaDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        { 
            List<Categoria> listaCategorias = _context.Categoria.ToList();
            return View(listaCategorias);
        }
    }
}
