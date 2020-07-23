﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            var listaEventos = DB.LerEventosDoArquivo();
            return listaEventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            var listaEventos = DB.LerEventosDoArquivo();
            return listaEventos               //coleção/lista de eventos
                .Where(e => e.Id == id)   //filtrando os que tem Id igual ao informado
                .SingleOrDefault();       //Single = registro unico  OrDefault = se nao existir, retorna null
        }

        [HttpPost]
        public Evento Create(Evento evento)
        {
            var listaEventos = DB.LerEventosDoArquivo();

            var novaLista = listaEventos.Append(evento);
            
            DB.SalvarEventosNoArquivo(novaLista);

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
