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
        HttpContext.Session.SetString("salaActual", "CELDA");
        string salaActual = HttpContext.Session.GetString("salaActual");

        ViewBag.Sala = salaActual;
        ViewBag.JugadorNombre = nombreJugador;

        HttpContext.Session.SetString("inicio", DateTime.Now.ToString());
        Juego.Inicializar();
        
        return View("sala1");
    }
    public IActionResult Celda(string claveIngresada)
    {
        ViewBag.Sala = HttpContext.Session.GetString("salaActual");
        ViewBag.JugadorNombre = HttpContext.Session.GetString("jugador");

        if (Juego.salas[0].ValidarClaveCelda(claveIngresada))
        {
            HttpContext.Session.SetString("salaActual", "PASILLO");
            ViewBag.Sala = HttpContext.Session.GetString("salaActual");
            return View("sala2");
        }
        else
        {
            Jugador.intentosFallidos++;
            HttpContext.Session.SetString("salaActual", "CELDA");
            return View("sala1");
        }
    }


    public IActionResult Pasillo(string clave1, string clave2, string clave3, string clave4, string clave5)
    {

        ViewBag.Sala = HttpContext.Session.GetString("salaActual");
        ViewBag.JugadorNombre = HttpContext.Session.GetString("jugador");

        if (Juego.salas[1].ValidarPatronPasillo(clave1, clave2, clave3, clave4, clave5))
        {
            HttpContext.Session.SetString("salaActual", "PATIO");
            ViewBag.Sala = HttpContext.Session.GetString("salaActual");
            return View("sala3");
        }
        else
        {
            HttpContext.Session.SetString("salaActual", "PASILLO");
            return View("sala2");
        }
    }


    public IActionResult Patio(string claveIngresada)
    {
        ViewBag.Sala = HttpContext.Session.GetString("salaActual");
        ViewBag.JugadorNombre = HttpContext.Session.GetString("jugador");

        if (Juego.salas[2].ValidarClaveHoraPatio(claveIngresada))
        {
            HttpContext.Session.SetString("salaActual", "SALIDA");
            ViewBag.Sala = HttpContext.Session.GetString("salaActual");

            return View("sala4");
        }
        else
        {
            Jugador.intentosFallidos++;
            HttpContext.Session.SetString("salaActual", "PATIO");
            return View("sala3");
        }
    }
    public IActionResult Salida()
    {           
        ViewBag.Sala = HttpContext.Session.GetString("salaActual");
        ViewBag.JugadorNombre = HttpContext.Session.GetString("jugador");

        return View("sala4oculta");

    }
    public IActionResult SalidaSalaOculta(string claveIngresada)
    {
        ViewBag.JugadorNombre = HttpContext.Session.GetString("jugador");
        ViewBag.intentosFallidos = Jugador.intentosFallidos;
        if (Juego.salas[3].ValidarClaveSalida(claveIngresada))
        {
            DateTime tiempoInicial = DateTime.Parse(HttpContext.Session.GetString("inicio"));
            ViewBag.TiempoFinal = Jugador.calcularTiempoFinal(tiempoInicial, DateTime.Now).ToString(@"mm\:ss");
            HttpContext.Session.SetString("estadoJuego", "ganaste");
            return View("ganaste");
        }
        else
        {
            Jugador.intentosFallidos++;
            ViewBag.intentosFallidos = Jugador.intentosFallidos;
            HttpContext.Session.SetString("salaActual", "sala4oculta");
            return View("sala4oculta");
        }
    }

   
}
   


