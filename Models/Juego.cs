 using System;
using Newtonsoft.Json;


namespace TP05.Models;

public static class Juego
{
    [JsonProperty]
    public static List<Sala> salas = new List<Sala>();
    public static void Inicializar()
    {
        //Sala 1
        salas.Add(new Sala("0180"));
        //Sala 2    
        salas.Add(new Sala("10011"));
        //Sala 3
        salas.Add(new Sala("0")); 
        //Sala 4
        salas.Add(new Sala("plan"));
    }
    
}
