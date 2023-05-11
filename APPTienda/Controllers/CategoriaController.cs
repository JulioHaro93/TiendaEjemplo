using APPTienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace APPTienda.Controllers
{
    public class CategoriaController : Controller
    {

        [HttpGet]
        public Task<List<Categoria>> Get() => _conectionContext.Get<List<Categoria>>();

        public IActionResult Index()
        {
            return View();
        }
    }
}
