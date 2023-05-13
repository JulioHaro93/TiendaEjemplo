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
                /*List<Articulo> listaArticulos = _context.Articulo.ToList();
                var totalCategorias = listaArticulos.Count();

                articulo.ArticuloNum= (uint)(totalCategorias + 1);
                //articulo.Id_SubCategoria = (uint)(totalCategorias + 1);
                articulo.Categoria = "1."+articulo.ArticuloNum.ToString();
                for (int i = 0; i < totalCategorias; i++)
                {
                    if (listaArticulos[i].Categoria == articulo.Categoria)
                    {
                        articulo.ArticuloNum = listaArticulos[totalCategorias-1].Id_SubCategoria+1;
                        //articulo.Id_SubCategoria = listaArticulos[totalCategorias-1].Id_SubCategoria + 1;
                        articulo.Categoria = "1."+ articulo.ArticuloNum.ToString();
                    }
                }*/
                List<SubCategoria> listaSubCategorias = _context.SubCategoria.ToList();
                List<Articulo> listaSub = _context.Articulo.ToList();
                List<SubCategoria> listaSubById = _context.SubCategoria
                    .Where(t => t.Id_Categoria == articulo.Id_SubCategoria)
                    .ToList();


                //string substring = listaSub[listaSub.Count()-1].Ticket_Num;

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
        public IActionResult VerPorCategoria(Categoria categoria)
        {
            List<Articulo> articulos = _context.Articulo.Where(a =>
                a.Categoria.Substring(0, 3).Equals(categoria.Ticket_Num)
                ).ToList();
            return View(articulos);
        }

        public IActionResult VerPorSubCategoria(SubCategoria subCategoria)
        {
            List<Articulo> articulos = _context.Articulo.Where(a =>
                a.Categoria.Substring(0, 5).Equals(subCategoria.Ticket_NumSub)
                ).ToList();
            return View(articulos);
        }
    }


}
