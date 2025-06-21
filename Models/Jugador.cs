using System;
using Newtonsoft.Json;


namespace TP05.Models;

public static class Jugador
{
    [JsonProperty]
    public static string nombre { get; set; }
    [JsonProperty]
    public static DateTime tiempoFinal { get; set; }
    [JsonProperty]
    public static int intentosFallidos { get; set; }
    [JsonProperty]
    public static List<Sala> salas = new List<Sala>();
    public static TimeSpan calcularTiempoFinal(DateTime tiempo1, DateTime tiempo2)
    {
        return tiempo1 - tiempo2;
    }

}
