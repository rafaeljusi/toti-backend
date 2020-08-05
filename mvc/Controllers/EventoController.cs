using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;

namespace mvc.Controllers
{
    public class EventoController : Controller
    {
        private readonly ILogger<EventoController> _logger;

        public EventoController(ILogger<EventoController> logger)
        {
            _logger = logger;
        }

        //http://localhost:5000/evento
        public IActionResult Index()
        {
            return View();
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
