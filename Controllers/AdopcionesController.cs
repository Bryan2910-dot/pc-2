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
   
    public class AdopcionesController : Controller
    {
        private readonly ILogger<AdopcionesController> _logger;
        private readonly ApplicationDbContext _context;

        public AdopcionesController(ILogger<AdopcionesController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }
            public IActionResult Index()
        {
            var adopciones = _context.DbSetAdopciones
                .Select(a => new
                {
                    MascotaNombre = a.Mascota.Nombre,
                    AdoptanteNombre = a.Adoptante.Nombre
                })
                .ToList();

            // Pasar los datos al View
            return View(adopciones);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}