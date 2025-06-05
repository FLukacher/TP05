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
        salas.Add(new Sala(1, "Celda", "Estás encerrado en una celda. Puedes observar una caja fuerte de 4 digitos, y en la pared hay una clave extraña escrita con sangre: 8-6-9-4 *=← ? ", 8271));
        //Sala 2
        salas.Add(new Sala(2, "Pasillo", "Lograste salir, pero el pasillo está lleno de cámaras. Puedes ovservar junto a la puerta un panel con 5 luces, las cuales pueden prenderse y apargarse de manera independiente. Sobre este, se encuntra un papel con un mensaje que dice: 'Son la suma de la cantidad de rendijas que dejan entrar el día y los ojos que nunca parpadean'", 10011));
        //Sala 3
        salas.Add(new Sala(3, "Patio", "Usted ha de atravesar el patio del terror 'No mires atrás. Solo quien capture el presente exacto hallará la salida.'", 0)); //la clave de esta clase es la hora actual, por lo que la valido directo en el metodo 
        //Sala 4
        salas.Add(new Sala(4, "Salida","Lograste abrir la puerta del pasillo. Tu libertad se encuentra al otro lado de esta gran puerta. Frente a vos hay un teclado numérico y una inscripción tallada que dice: " +"'No mires atrás. Solo quien capture el presente exacto hallará la salida.'", 1)); 
    }
}
