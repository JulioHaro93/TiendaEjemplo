using APPTienda.Data;
using APPTienda.Models;
using APPTienda.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
                List<SubCategoria> listaSubById = _context.SubCategoria
                    .Where(t => t.Id_Categoria == subCategoria.Id_Categoria)
                    .ToList();


                //string substring = listaSub[listaSub.Count()-1].Ticket_Num;

                subCategoria.SubCategoria_Num = (uint)(listaSubById.Count()+1);
                subCategoria.Ticket_NumSub =  "1." + 
                    subCategoria.Id_Categoria.ToString() + "."+
                    subCategoria.SubCategoria_Num.ToString();


                /*
                
                List<Categoria> listaNueva = new List<Categoria>();
                Console.WriteLine(listaCategorias.Count());
                for(int i =0;  i < listaCategorias.Count(); i++)
                {
                    if (listaCategorias[i].Id_Categoria == subCategoria.Id_Categoria)
                    {
                        listaNueva.Add(listaCategorias[i]);
                    }
                }int totalSubCat = (contador + 1);
                Console.WriteLine(totalSubCat.ToString()); 
                subCategoria.SubCategoria_Num= (uint) totalSubCat;
                
                for (int i = 0; i < listaCategorias.Count(); i++)
                {
                    Console.WriteLine(listaCategorias[i]);
                    if (listaCategorias[i].Id_Categoria == subCategoria.Id_Categoria)
                    {
                        subCategoria.Ticket_NumSub = listaCategorias[i].Ticket_Num.ToString() +"."+
                            subCategoria.SubCategoria_Num.ToString();
                    }
                }

                for (int i = 0; i < listaSub.Count(); i++)
                {
                    if (subCategoria.Ticket_NumSub == listaSub[i].Ticket_Num)
                    {
                        subCategoria.SubCategoria_Num = listaSub[totalSubCat - 1].Id_SubCategoria + 1;
                        subCategoria.Id_SubCategoria = listaSub[totalSubCat - 1].Id_SubCategoria + 1;
                        subCategoria.Ticket_NumSub = subCategoria.Categoria.Ticket_Num+ "." + subCategoria.SubCategoria_Num.ToString();
                    }
                }*/
                _context.SubCategoria.Add(subCategoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int? id)
        {
            if( id == null)
            {
                return View();
            }
            else
            {
                CategoriaSubCategoriaViewModel categoriaSubCategorias = new CategoriaSubCategoriaViewModel();
                categoriaSubCategorias.ListadeCategorias = _context.Categoria.Select(i => new SelectListItem
                {
                    Text = i.Nombre,
                    Value = i.Id_Categoria.ToString()

                });
                categoriaSubCategorias.SubCategoria = _context.SubCategoria.FirstOrDefault(s => s.Id_SubCategoria == id);
                if(categoriaSubCategorias == null)
                {
                    return View();
                }
                return View(categoriaSubCategorias);
            }
        }
        
    }
}

