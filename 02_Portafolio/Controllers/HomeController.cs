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
        private readonly IConfiguration configuration;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IConfiguration configuration, IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.configuration = configuration;
            this.servicioEmail = servicioEmail;
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

            #region Manejo de Logs y variables de configuración
            //var apellido = configuration.GetValue<string>("Apellido");
            //_logger.LogTrace("Este es un mensaje de trace");
            //_logger.LogDebug("Este es un mensaje de debug");
            //_logger.LogInformation("Este es un mensaje de information");
            //_logger.LogWarning("Este es un mensaje de warning");
            //_logger.LogError("Este es un mensaje de error");
            //_logger.LogCritical("Este es un mensaje de critical " + apellido); 
            #endregion

            var listadoProyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();            
            var homeIndexViewModel = new HomeIndexViewModel() { Proyectos = listadoProyectos };

            return View(homeIndexViewModel);
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("MensajeExitoso");
        }

        public IActionResult MensajeExitoso()
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
