using APPTienda.Data;
using APPTienda.Models;
using APPTienda.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APPTienda.Controllers
{
    public class SubCategoriaController : Controller
    {
        public readonly TiendaDbContext _context;
        public SubCategoriaController(TiendaDbContext contexto)
        {
            _context = contexto;
        }
        public IActionResult Index()
        {
            List<SubCategoria> listaSubCategorias = _context.SubCategoria.ToList();
            return View(listaSubCategorias);
        }

        public IActionResult Crear()
        {
            CategoriaSubCategoriaViewModel articuloCategorias = new CategoriaSubCategoriaViewModel();
            articuloCategorias.ListadeCategorias = _context.Categoria.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = i.Nombre,
                Value = i.Id_Categoria.ToString()
            });

            return View(articuloCategorias);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(SubCategoria subCategoria)
        {
            if (ModelState.IsValid)
            {
                List<Categoria> listaCategorias = _context.Categoria.ToList();
                List<SubCategoria> listaSub = _context.SubCategoria.ToList();

                var totalSubCat = listaSub.Count();
                subCategoria.SubCategoria_Num = (uint?)(totalSubCat + 1);
                //subCategoria.Ticket_Num = subCategoria.Categoria.Ticket_Num + "." + subCategoria.Ticket_Num.ToString();

                for (int i = 0; i < listaCategorias.Count(); i++)
                {
                    if (listaCategorias[i].Id_Categoria == subCategoria.Id_Categoria)
                    {
                        subCategoria.Ticket_NumSub = listaCategorias[i].Ticket_Num.ToString() +"."+
                            subCategoria.SubCategoria_Num.ToString();
                    }
                }

                for (int i = 0; i < totalSubCat; i++)
                {
                    if (subCategoria.Ticket_NumSub == listaSub[i].Ticket_Num)
                    {
                        subCategoria.SubCategoria_Num = listaSub[totalSubCat - 1].Id_SubCategoria + 1;
                        subCategoria.Id_SubCategoria = listaSub[totalSubCat - 1].Id_SubCategoria + 1;
                        subCategoria.Ticket_NumSub = subCategoria.Categoria.Ticket_Num+ "." + subCategoria.SubCategoria_Num.ToString();
                    }
                }
                _context.SubCategoria.Add(subCategoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
            }
            else
            {
                return View();
            }
        }
    }
}
