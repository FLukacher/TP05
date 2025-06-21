using System;
using Newtonsoft.Json;
namespace TP05.Models;

public class Sala
{

    [JsonProperty]
    public string claveCorrecta { get; set; }
    public Sala(string claveCorrecta)
    {
        this.claveCorrecta = claveCorrecta;
    }
    public bool ValidarClaveCelda(string claveIngresada)
    {
        return this.claveCorrecta == claveIngresada;
    }
    public bool ValidarClaveSalida(string claveIngresada)
    {
        return this.claveCorrecta.ToUpper() == claveIngresada.ToUpper();
    }
    
    public bool ValidarPatronPasillo(string clave1, string clave2, string clave3, string clave4, string clave5)
    {
        bool respuestaCorrecta = true;
        string[] claveRecibida = { clave1, clave2, clave3, clave4, clave5 };
        string[] claveEsperada = { "on", null, null, "on", "on"}; //10011

        for (int i = 0; i < claveEsperada.Length; i++)
        {
            if (claveRecibida[i] != claveEsperada[i])
            {
                respuestaCorrecta = false;
            }
        }
        return respuestaCorrecta;
    }
    public bool ValidarClaveHoraPatio(string claveIngresada)
    {
        return (DateTime.Now.Hour * 100 + DateTime.Now.Minute).ToString() == claveIngresada;
    }
   
}