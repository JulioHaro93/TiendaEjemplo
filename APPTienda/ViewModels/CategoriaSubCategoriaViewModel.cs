using APPTienda.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPTienda.ViewModels
{
    public class CategoriaSubCategoriaViewModel
    {
        public SubCategoria SubCategoria { get; set; }

        public IEnumerable<SelectListItem> ListadeCategorias { get; set; }
    }
}
