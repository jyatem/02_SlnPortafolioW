using System.Diagnostics;
using _02_Portafolio.Models;
using _02_Portafolio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace _02_Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
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

            _logger.LogTrace("Este es un mensaje de trace");
            _logger.LogDebug("Este es un mensaje de debug");
            _logger.LogInformation("Este es un mensaje de information");
            _logger.LogWarning("Este es un mensaje de warning");
            _logger.LogError("Este es un mensaje de error");
            _logger.LogCritical("Este es un mensaje de critical");

            var listadoProyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();            
            var homeIndexViewModel = new HomeIndexViewModel() { Proyectos = listadoProyectos };

            return View(homeIndexViewModel);
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
