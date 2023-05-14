using APPTienda.Data;
using APPTienda.Models;
using APPTienda.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace APPTienda.Controllers
{
    public class ArticuloController : Controller
    {
        public readonly TiendaDbContext _context;

        public ArticuloController(TiendaDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        { 
            List<Articulo> listaArticulos = _context.Articulo.ToList();
            return View(listaArticulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {

            SubCategoriaArticuloVM articuloSubCategorias = new SubCategoriaArticuloVM();
            articuloSubCategorias.ListaSubCategorias = _context.SubCategoria.
                Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i.Nombre,
                    Value = i.Id_SubCategoria.ToString()
                }).ToList();
            articuloSubCategorias.ListaSub = _context.SubCategoria.ToList();

            List<SelectListItem> items = articuloSubCategorias.ListaSub.ConvertAll(d =>
            {
                return new SelectListItem() { 
                    Text = d.Nombre, Value = d.Id_SubCategoria.ToString() 
                };
            }).ToList();
            
            return View(articuloSubCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Articulo articulo)
        {
            if (ModelState.IsValid) 
            {
               
                List<SubCategoria> listaSubCategorias = _context.SubCategoria.ToList();
                List<Articulo> listaSub = _context.Articulo.ToList();
                List<SubCategoria> listaSubById = _context.SubCategoria
                    .Where(t => t.Id_Categoria == articulo.Id_SubCategoria)
                    .ToList();

                articulo.ArticuloNum = (uint)((int)listaSubById.Count() + 1);
                articulo.Categoria =
                    listaSubById[0].Ticket_NumSub.ToString() + "." +
                    articulo.ArticuloNum.ToString();


                _context.Articulo.Add(articulo);
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
        [HttpGet]
        public IActionResult Borrar(uint? id)
        {
            var articulo = _context.Articulo.FirstOrDefault(a => a.Sku == id);

            if (articulo != null)
            {
                
                _context.Articulo.Remove(articulo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult VerPorCategoria(uint? id)
        {
            var categoria = _context.Categoria.FirstOrDefault(a => a.Id_Categoria == id);

            List<Articulo> articulos = _context.Articulo.Where(a =>
                a.Categoria.Substring(0, 3).Equals(categoria.Ticket_Num)
                ).ToList();
            return View(articulos);
        }

        public IActionResult VerPorSubCategoria(uint? catId, uint? subId)
        {
            string substring = "1."+ catId + "." + subId;
            List<Articulo> articulos = _context.Articulo.Where(a =>
                a.Categoria.Substring(0, 5).Equals(substring)
                ).ToList();
            

            return View(articulos);
        }
        [HttpGet]
        public IActionResult VerPorInventario(uint? inventario)
        {
            List<Articulo> articulos = _context.Articulo.Where(a =>
            a.Inventario <= inventario
            ).ToList();
            return View(articulos);
        }
        [HttpGet]
        public IActionResult VerPorInventarioIntervalo(uint? x, uint? y)
        {
            List<Articulo> articulos = _context.Articulo.Where(a =>
            a.Inventario >=x && a.Inventario <=y
            ).ToList();
            return View(articulos);
        }
    }
    
}



