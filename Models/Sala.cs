using System;

namespace TP05.Models;

public class Sala
{
    public int numero { get; set; }
    public string nombre { get; set; }
    public string pista { get; set; }
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
}