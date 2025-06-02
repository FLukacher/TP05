using System.Diagnostics;
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
        Jugador jugador = new Jugador(nombreJugador, 0);
        ViewBag.JugadorNombre = nombreJugador;
            Juego.Inicializar();
        
        return View("sala1");
    }
    public IActionResult Celda()
    {
        ViewBag.nombreSala = Juego.salas[0].nombre;
        return View("sala2");
    }
    }

