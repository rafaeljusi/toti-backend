using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var dbContext = new DB();

            var listaEventos = dbContext.Eventos;
            return listaEventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            var dbContext = new DB();

            var listaEventos = dbContext.Eventos.Include(e => e.TipoEvento);
            
            return listaEventos               //coleção/lista de eventos
                .Where(e => e.Id == id)   //filtrando os que tem Id igual ao informado
                .SingleOrDefault();       //Single = registro unico  OrDefault = se nao existir, retorna null
        }

        [HttpPost]
        public Evento Create(Evento evento)
        {
            var dbContext = new DB();

            dbContext.Eventos.Add(evento);

            dbContext.SaveChanges();

            return evento;
        }

        [HttpPut("{id}")]
        public Evento Update(int id, Evento evento)
        {
            var dbContext = new DB();

            var listaEventos = dbContext.Eventos;

            var registroAtualizar = listaEventos.Where(e => e.Id == id).Single();
            registroAtualizar.Titulo = evento.Titulo;
            registroAtualizar.Data = evento.Data;
            registroAtualizar.TipoEventoId = evento.TipoEventoId;

            dbContext.Eventos.Update(registroAtualizar);

            dbContext.SaveChanges();

            return registroAtualizar;
        }

        [HttpDelete("{id}")]
        public Evento Delete(int id)
        {
            var dbContext = new DB();

            var listaEventos = dbContext.Eventos;

            var registroApagar = listaEventos.Where(e => e.Id == id).Single();

            dbContext.Eventos.Remove(registroApagar);

            dbContext.SaveChanges();

            return registroApagar;
        }
    }
}
