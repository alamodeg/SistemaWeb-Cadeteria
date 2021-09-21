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
        readonly List<Cadete> _listaCadete;

        public CadeteController(ILogger<CadeteController> logger, List<Cadete> listaCadete)
        {
            _logger = logger;
            _listaCadete = listaCadete;
        }

        public IActionResult CargarCadete(string nombre, string apellido, string tel)
        {
            //si no ingresa nada
            if (nombre is null && apellido is null && tel is null) return View();

            _listaCadete.Add(new Cadete(nombre, apellido, tel));

            return View();
        }
    }
}
