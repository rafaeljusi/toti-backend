using System;

namespace data
{
    public class Evento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public bool Cancelado { get; set; }
    }
}
