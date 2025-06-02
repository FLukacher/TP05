using System;

namespace TP05.Models;

public class Jugador
{
    public string nombre { get; set; }

    public DateTime tiempoFinal { get; set; }
    public Jugador(string nombre, DateTime tiempoFinal)
    {
        this.nombre = nombre;
        this.tiempoFinal = tiempoFinal;
    }
}
