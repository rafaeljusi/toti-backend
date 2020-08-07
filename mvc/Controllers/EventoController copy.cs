using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace mvc.Controllers
{
    public class EventoController : Controller
    {
        private readonly DB _dbInterno;
        private readonly ILogger<EventoController> _logger;

        public EventoController(ILogger<EventoController> logger , DB dbviaParametro)
        {
        
            _dbInterno = dbviaParametro;
            _dbInterno.Database.Migrate();
            _logger = logger;

        }

        public IActionResult Index()
        {
            var listaEventos = _dbInterno.Eventos.ToList();
        
            return View(listaEventos);
        }

        public IActionResult Novo()
        {
            
            return View();
        }


        public IActionResult Editar(int id)
        {
            ViewData["id"] = id;
            return View();
        }

       
    }
}
