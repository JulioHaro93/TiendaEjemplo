using APPTienda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace APPTienda.ViewModels
{
    public class SubCategoriaArticuloVM
    {

        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem> ListaSubCategorias { get; set; }

        public List<SubCategoria> ListaSub { get; set; }
        

    }
}
