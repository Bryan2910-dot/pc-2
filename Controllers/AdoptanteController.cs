using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pc_2.Data;
using pc_2.Models;

namespace pc_2.Controllers
{
    [Route("[controller]")]
    public class AdoptanteController : Controller
    {
        private readonly ILogger<AdoptanteController> _logger;
        private readonly ApplicationDbContext _context;

        public AdoptanteController(ILogger<AdoptanteController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(Adoptantes adoptante)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.DbSetAdoptantes.Add(adoptante);
                    _context.SaveChanges();
                    _logger.LogInformation("Se registró el adoptante");
                    ViewData["Message"] = "Se registró el adoptante";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al registrar el adoptante");
                    ViewData["Message"] = "Error al registrar el adoptante: " + ex.Message;
                }
            }
            else
            {
                ViewData["Message"] = "Datos de entrada no válidos";
            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}