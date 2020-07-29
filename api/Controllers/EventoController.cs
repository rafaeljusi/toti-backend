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

            var listaEventos = dbContext.Eventos;
            
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
            var listaEventos = DB.LerEventosDoArquivo();

            var registroAtualizar = listaEventos.Where(e => e.Id == id).Single();
            registroAtualizar.Titulo = evento.Titulo;
            registroAtualizar.Data = evento.Data;

            DB.SalvarEventosNoArquivo(listaEventos);

            return registroAtualizar;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var listaEventos = DB.LerEventosDoArquivo();

            var novaLista = listaEventos.Where(e => e.Id != id);

            DB.SalvarEventosNoArquivo(novaLista);

            var resultado = listaEventos.Count() != novaLista.Count();

            return resultado;
        }
    }
}
