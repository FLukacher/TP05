using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using TP05.Models;


namespace TP05.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]

    public IActionResult IniciarJuego(string nombreJugador)
    {  
        HttpContext.Session.SetString("jugador", nombreJugador);
        HttpContext.Session.SetString("salaActual", "Celda");
        string salaActual = HttpContext.Session.GetString("salaActual");
        ViewBag.nombreSala1 = salaActual;
        ViewBag.JugadorNombre = nombreJugador;
        HttpContext.Session.SetString("inicio", DateTime.Now.ToString());
        Juego.Inicializar();
        

        return View("sala1");
    }
   public IActionResult Celda(string claveIngresada)
{
    string salaActual = HttpContext.Session.GetString("salaActual");

    if (Juego.salas[0].ValidarClaveCelda(claveIngresada))
    {
        HttpContext.Session.SetString("salaActual", "sala2");
        return View("sala2");
    }
    else
    {
        HttpContext.Session.SetString("salaActual", "sala1");
        return View("sala1");
    }
}


    public IActionResult Pasillo(string clave1, string clave2, string clave3, string clave4, string clave5)
{
    string salaActual = HttpContext.Session.GetString("salaActual");

    if (Juego.salas[1].ValidarPatronPasillo(clave1, clave2, clave3, clave4, clave5))
    {
        HttpContext.Session.SetString("salaActual", "sala3");
        return View("sala3");
    }
    else
    {
        HttpContext.Session.SetString("salaActual", "sala2");
        return View("sala2");
    }
}


    public IActionResult Patio(string claveIngresada)
    {
        string salaActual = HttpContext.Session.GetString("salaActual");

    if (Juego.salas[2].ValidarClaveHoraPatio(claveIngresada))
    {
        HttpContext.Session.SetString("salaActual", "Salida"); // Cambia a la siguiente sala
        return View("sala4");
    }
    else
    {
        HttpContext.Session.SetString("salaActual", "Patio");
        return View("sala3");
    }
    }
    public IActionResult Salida()
    {           
        string salaActual = HttpContext.Session.GetString("salaActual");
        return View("sala4oculta");

    }
    public IActionResult SalidaSalaOculta(string claveIngresada)
    {
        if (Juego.salas[3].ValidarClaveSalida(claveIngresada))
        {
            string inicioStr = HttpContext.Session.GetString("inicio");
            DateTime inicio = DateTime.Parse(inicioStr);
            DateTime fin = DateTime.Now;

            TimeSpan duracion = fin - inicio;
            ViewBag.TiempoFinal = duracion.ToString(@"mm\:ss");

            HttpContext.Session.SetString("estadoJuego", "ganaste");
            return View("ganaste");
        }
        else
        {
            HttpContext.Session.SetString("salaActual", "sala4oculta");
            return View("sala4oculta");
        }
    }

   
}
   


