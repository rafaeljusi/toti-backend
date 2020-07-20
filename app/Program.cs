using System;
using System.Text.Json;
using data;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var evento = new Evento()
            {
                Id = 1,
                Data = new DateTime(2020, 07, 15),
                Titulo = "aniversario Mutu"
            };

            var json = JsonSerializer.Serialize(evento);         

            var jsonEvento2 = json;

            var evento2 = JsonSerializer.Deserialize<Evento>(jsonEvento2);
            
            Console.WriteLine(evento2);
        }
    }
}
