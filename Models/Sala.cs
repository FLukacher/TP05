using System;
using Newtonsoft.Json;
namespace TP05.Models;

public class Sala
{
    [JsonProperty]
    public int numero { get; set; }
    [JsonProperty]
    public string nombre { get; set; }
    [JsonProperty]
    public string pista { get; set; }
    [JsonProperty]
    public int claveCorrecta { get; set; }

    public Sala(int numero, string nombre, string pista, int claveCorrecta)
    {
        this.numero = numero;
        this.nombre = nombre;
        this.pista = pista;
        this.claveCorrecta = claveCorrecta;
    }
    public bool ValidarClave(int claveIngresada)
    {
        return this.claveCorrecta == claveIngresada;
    }
    public bool ValidarClaveHHmm(int claveIngresada)
    {
        return DateTime.Now.Hour * 100 + DateTime.Now.Minute == claveIngresada;
    }
}