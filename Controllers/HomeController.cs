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
        if (string.IsNullOrWhiteSpace(nombreJugador))
        {
            ViewBag.Error = "Por favor ingresá un nombre válido.";
            return View("Index");
        }

        // Guardar el nombre en TempData (podés usar Session si preferís)
        TempData["JugadorNombre"] = nombreJugador;

        // Redirigir a la primera sala del juego
        return RedirectToAction("Sala", "Juego", new { id = 1 });
    }
}

