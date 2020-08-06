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
            return View();
        }

        //http://localhost:5000/evento/editar/{id}
        public IActionResult Editar(int id)
        {
            ViewData["id"] = id;

            return View();
        }
    }
}
