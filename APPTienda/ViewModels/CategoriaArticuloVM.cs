using APPTienda.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPTienda.ViewModels
{
    public class CategoriaArticuloVM
    {
        public Categoria SubCategoria { get; set; }

        public IEnumerable<SelectListItem> ListadeCategorias { get; set; }
        
        public List<Articulo> FiltrarPorCategoría (Categoria categoria, List<Articulo> articulos)
        {
            List<Articulo> articulosPorCategorias = new List<Articulo>();

            string subString = categoria.Ticket_Num;

            for(int i = 0; i<articulos.Count(); i++)
            {
                if (articulos[i].Categoria.Substring(0, 3).Equals(categoria.Ticket_Num))
                {
                    articulosPorCategorias.Add(articulos[i]);
                }

            }
            return articulosPorCategorias;

        }
    }

}
