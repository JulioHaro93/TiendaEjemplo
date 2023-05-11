using APPTienda.Data;
using APPTienda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Formats.Asn1;
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

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid) 
            {
                List<Categoria> listaCategorias = _context.Categoria.ToList();
                var totalCategorias = listaCategorias.Count();

                categoria.Category_Num = (uint)(totalCategorias + 1);
                categoria.Id_Categoria = (uint)(totalCategorias + 1);
                categoria.Ticket_Num = "1."+categoria.Category_Num.ToString();
                _context.Categoria.Add(categoria);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else 
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Editar(uint? id)
        {
            if(id == null)
            {
                return View();
            }
            else
            {
                var categoria = _context.Categoria.FirstOrDefault(c => c.Id_Categoria == id);
                return View(categoria);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categoria.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(categoria);
            }
        }
    }
}
