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
        Jugador jugador = new Jugador(nombreJugador, 0);
        ViewBag.JugadorNombre = nombreJugador;
        Juego.Inicializar();
        InicializarViews();
       
        return View("sala1");
    }
    public IActionResult Celda(int claveIngresada)
    {
        InicializarViews();
        ViewBag.intento = claveIngresada;    
        if (Juego.salas[0].ValidarClave(claveIngresada))
        {
            return View("sala2");
        }
        else return View("sala1");
    }


    public IActionResult Pasillo(string clave1, string clave2, string clave3, string clave4, string clave5)
    {

        string[] claveRecibida = {clave1, clave2, clave3, clave4, clave5};
        
        InicializarViews();
        string[] claveEsperada = { "on", null, null, "on", "on" };

        bool respuestaCorrecta = true;
        
        string claveIngresada = "";

        for(int i = 0; i < claveEsperada.Length; i++){
            if(claveRecibida[i] != claveEsperada[i]){

                respuestaCorrecta=false;
            }
        }
 

        if (respuestaCorrecta)
        {
            return View("sala3");
            
        }
        else
        {
            return View("sala2");
        }

    }   


    public IActionResult Patio(int claveIngresada)
    {
        InicializarViews();
       
        ViewBag.intento = claveIngresada;    
        if (Juego.salas[2].ValidarClaveHHmm(claveIngresada))
        {
            return View("sala4");
        }
        else return View("sala3");
    }
    public IActionResult Salida(int claveIngresada)
    {
        InicializarViews();
       
        ViewBag.intento = claveIngresada;    
        if (Juego.salas[3].ValidarClave(claveIngresada))
        {
            return View("sala5");
        }
        else return View("sala4");
    }


    void InicializarViews()
    {  
        ViewBag.nombreSala1 = Juego.salas[0].nombre;
        ViewBag.pista1 = Juego.salas[0].pista;
       
        ViewBag.nombreSala2 = Juego.salas[1].nombre;
        ViewBag.pista2 = Juego.salas[1].pista;


        ViewBag.nombreSala3 = Juego.salas[2].nombre;
        ViewBag.pista3 = Juego.salas[2].pista;


        ViewBag.nombreSala4 = Juego.salas[3].nombre;
        ViewBag.pista4 = Juego.salas[3].pista;
    }
}
   


