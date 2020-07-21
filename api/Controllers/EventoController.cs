using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public Evento[] _eventos = new Evento[]
            {
                new Evento() 
                {
                    Id = 1,
                    Titulo = "Evento no. 1"
                },
                new Evento() 
                {
                    Id = 2,
                    Titulo = "Evento no. 2"
                },
            };


        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _eventos               //coleção/lista de eventos
                .Where(e => e.Id == id)   //filtrando os que tem Id igual ao informado
                .SingleOrDefault();       //Single = registro unico  OrDefault = se nao existir, retorna null
        }

        [HttpPost]
        public Evento Create(Evento evento)
        {
            return evento;
        }

        [HttpPut("{id}")]
        public Evento Update(int id, Evento evento)
        {
            return evento;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return true;
        }
    }
}
