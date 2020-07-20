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
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            var eventos = new Evento[]
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

            return eventos;
        }
    }
}
