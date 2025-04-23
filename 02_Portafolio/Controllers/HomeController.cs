using System.Diagnostics;
using _02_Portafolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            #region Codigo Comentado
            //ViewBag.Nombre = "Jairo Yesid Yate";
            //ViewBag.Edad = 44;
            //return View("Index", "Jairo Yate Martinez");

            //var persona = new Persona()
            //{
            //    Nombre = "Lina Mora",
            //    Edad = 14
            //};

            //return View(persona); 
            #endregion

            var listadoProyectos = ObtenerProyectos().Take(3).ToList();
            
            var homeIndexViewModel = new HomeIndexViewModel() { Proyectos = listadoProyectos };

            return View(homeIndexViewModel);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            #region Agregando elementos a una lista con el método Add
            //var listadoProyecto = new List<Proyecto>();

            //listadoProyecto.Add(new Proyecto()
            //{
            //    Titulo = "Amazon",
            //    Descripcion = "E-Commerce realizado en ASP.NET Core",
            //    Link = "https://amazon.com",
            //    ImageURL = ""
            //}); 
            #endregion

            var listadoProyecto = new List<Proyecto>()
            {
                new Proyecto()
                {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.NET Core",
                    Link = "https://amazon.com",
                    ImageURL = "/imagenes/amazon.png"
                },
                new Proyecto()
                {
                    Titulo = "New York Times",
                    Descripcion = "Página de noticias en React",
                    Link = "https://nytimes.com",
                    ImageURL = "/imagenes/nyt.png"
                },
                new Proyecto()
                {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    Link = "https://reddit.com",
                    ImageURL = "/imagenes/reddit.png"
                },
                new Proyecto()
                {
                    Titulo = "Steam",
                    Descripcion = "Tienda en línea para comprar videojuegos",
                    Link = "https://store.steampowered.com",
                    ImageURL = "/imagenes/steam.png"
                },
            };

            return listadoProyecto;
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
