using System;
using Newtonsoft.Json;


namespace TP05.Models;

public class Jugador
{
    [JsonProperty]
    public string nombre { get; set; }
    [JsonProperty]
    public int tiempoFinal { get; set; }
    public Jugador(string nombre, int tiempoFinal)
    {
        this.nombre = nombre;
        this.tiempoFinal = tiempoFinal;
    }
}
