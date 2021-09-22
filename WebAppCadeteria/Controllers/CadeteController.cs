using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.Model;

namespace WebAppCadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly DBTemporal _DB;

        public CadeteController(ILogger<CadeteController> logger, DBTemporal DB)
        {
            _logger = logger;
            _DB = DB;
        }

        public IActionResult MostrarCadetes()
        {
            return View(_DB.Cadeteria.listaCadetes);
        }

        public IActionResult CargarCadete(string nombre, string apellido, string tel)
        {
            if (nombre is null && apellido is null && tel is null) return View();

             _DB.Cadeteria.listaCadetes.Add(new Cadete(nombre, apellido, tel));
            _DB.SaveCadete(_DB.Cadeteria.listaCadetes);
            return View();
        }
    }
}
