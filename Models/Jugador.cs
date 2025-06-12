using System;
using Newtonsoft.Json;


namespace TP05.Models;

public class Jugador
{
    [JsonProperty]
    public string nombre { get; set; }

    public static List<Sala> salas = new List<Sala>();
    public Jugador(string nombre)
    {
        this.nombre = nombre;


    }
}
