﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //http://localhost:5000/home/index
        public IActionResult Index()
        {
            return View();
        }

        //http://localhost:5000/home/privacy
        public IActionResult Privacy()
        {
            return View();
        }

        //http://localhost:5000/home/help
        public IActionResult Help()
        {
            ViewData["horaAtual"] = DateTime.Now.ToString("HH:mm:ss");
            
            return View();
        }

        //http://localhost:5000/home/error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
