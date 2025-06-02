using System;

namespace TP05.Models;

public class Jugador
{
    public string nombre { get; set; }

    public int tiempoFinal { get; set; }
    public Jugador(string nombre, int tiempoFinal)
    {
        this.nombre = nombre;
        this.tiempoFinal = tiempoFinal;
    }
}
