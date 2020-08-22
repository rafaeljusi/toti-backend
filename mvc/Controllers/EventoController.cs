using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mvc.Models;

namespace mvc.Controllers
{
    public class EventoController : Controller
    {
        private readonly DB _dbInterno;

        public EventoController(DB dbViaParametro)
        {
            _dbInterno = dbViaParametro;
        }

        //http://localhost:5000/evento
        public IActionResult Index()
        {
            var listaEventos = _dbInterno.Eventos.ToList();

            return View(listaEventos);
        }

        //http://localhost:5000/evento/novo
        public IActionResult Novo()
        {
            var eventoDTO = new EventoDTO();

            return View("Cadastro", eventoDTO);
        }

        //http://localhost:5000/evento/editar/{id}
        public IActionResult Editar(int id)
        {
            var evento = _dbInterno.Eventos.SingleOrDefault(e => e.Id == id);

            var eventoDTO = new EventoDTO
            {
                Id = evento.Id,
                Titulo = evento.Titulo,
                Data = evento.Data
            };

            return View("Cadastro", eventoDTO);
        }

        [HttpPost]
        public IActionResult Salvar(EventoDTO eventoFormulario)
        {
            if (eventoFormulario.Id == 0)
            {
                //Registro novo
                var eventoBD = new Evento();

                eventoBD.Titulo = eventoFormulario.Titulo;
                eventoBD.Data = eventoFormulario.Data;

                _dbInterno.Add(eventoBD);
            }
            else
            {
                //Registro atualizado
                var eventoBD = _dbInterno.Eventos.SingleOrDefault(e => e.Id == eventoFormulario.Id);

                eventoBD.Titulo = eventoFormulario.Titulo;
                eventoBD.Data = eventoFormulario.Data;

                _dbInterno.Update(eventoBD);
            }

            _dbInterno.SaveChanges();

            return RedirectToAction("Index");
        }

        //http://localhost:5000/evento/apagar/{id}
        public IActionResult Apagar(int id)
        {
            var evento = _dbInterno.Eventos.SingleOrDefault(e => e.Id == id);

            _dbInterno.Remove(evento);

            _dbInterno.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
