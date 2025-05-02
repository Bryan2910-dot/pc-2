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
    public class MascotaController : Controller
    {
        private readonly ILogger<MascotaController> _logger;
private readonly ApplicationDbContext _context;

        public MascotaController(ILogger<MascotaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Mascotas mascota)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.DbSetMascotas.Add(mascota);
                    _context.SaveChanges();
                    _logger.LogInformation("Se registró la mascota");
                    ViewData["Message"] = "Se registró la mascota";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al registrar la mascota");
                    ViewData["Message"] = "Error al registrar la mascota: " + ex.Message;
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