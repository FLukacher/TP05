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
        Jugador jugador = new Jugador(nombreJugador);
        HttpContext.Session.SetString("jugador",Objeto.ObjectToString(jugador));
        ViewBag.JugadorNombre = nombreJugador;
        Sala salaActual = new Sala(1, "Celda", "0180" );
        HttpContext.Session.SetString("Sala",Objeto.ObjectToString(salaActual));
        ViewBag.nombreSala1 = salaActual.nombre;       

        InicializarViews();
       
        return View("sala1");
    }
    public IActionResult Celda(string claveIngresada)
    {
        InicializarViews();
        if (Juego.salas[0].ValidarClaveCelda(claveIngresada))
        {
            return View("sala2");
        }
        else return View("sala1");
    }


    public IActionResult Pasillo(string clave1, string clave2, string clave3, string clave4, string clave5)
    {
        InicializarViews();
        if (Juego.salas[1].ValidarPatronPasillo(clave1, clave2, clave3, clave4, clave5))
        {
            return View("sala3");
            
        }
        else return View("sala2");
    }   


    public IActionResult Patio(string claveIngresada)
    {
        InicializarViews();    
        if (Juego.salas[2].ValidarClaveHoraPatio(claveIngresada))
        {
            claveIngresada = (DateTime.Now.Hour * 100 + DateTime.Now.Minute).ToString(); //para que no se actualice y vuelvas al patio
            return View("sala4");
        }
        else return View("sala3");
    }
    public IActionResult Salida()
    {
        InicializarViews();   
        return View("sala4oculta");  

    }
    public IActionResult SalidaSalaOculta(string claveIngresada)
    {
        InicializarViews();   
        if (Juego.salas[3].ValidarClaveSalida(claveIngresada))
        { 
            return View("ganaste");
        }
        else return View("sala4oculta");
    }
    void InicializarViews()
    {  
        ViewBag.nombreSala1 = Juego.salas[0].nombre;       
        ViewBag.nombreSala2 = Juego.salas[1].nombre;
        ViewBag.nombreSala3 = Juego.salas[2].nombre;
        ViewBag.nombreSala4 = Juego.salas[3].nombre;
    }
}
   


