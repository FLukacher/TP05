using System;
using Newtonsoft.Json;


namespace TP05.Models;

public class Jugador
{
    [JsonProperty]
    public string nombre { get; set; }
    [JsonProperty]
    public DateTime tiempoFinal {get; set;}

    public static List<Sala> salas = new List<Sala>();
    public Jugador(string nombre, DateTime tiempoFinal)
    {
        this.nombre = nombre;   
        this.tiempoFinal = tiempoFinal;

    }
}
