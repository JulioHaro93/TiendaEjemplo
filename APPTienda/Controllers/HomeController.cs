using APPTienda.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Linq.Expressions;

namespace APPTienda.Controllers
{
    public class HomeController : Controller
    {
        public readonly string connectionString;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) 
            {
            _logger = logger;
            connectionString = "server=localhost;Port=3306;DataBase=store;Uid=root;pwd =sasa;";
            }

        public bool ArticuloController(int id)
        {
 
            MySqlConnection conexion = new MySqlConnection(connectionString);
            {
                conexion.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select * from articulo where id = ?sku";
                comando.Parameters.Add("?sku", MySqlDbType.Int32).Value = id;



                using (var reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {

                    }
                }
            }
            return true;
        }

        
        

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}