using Cadeteria.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
            return View(_DB.ReadCadetes());
        }

        public IActionResult AddCadete(string nombre, string apellido, string tel)
        {
            if (nombre is null && apellido is null && tel is null)
            {
                return View();
            }
            else
            {
                _DB.Cadeteria.listaCadetes.Add(new Cadete(nombre, apellido, tel));
                _DB.SaveAllCadetes();
                return View();
            }
        }

        public IActionResult DeleteCadete(Guid id)
        {
            _DB.Cadeteria.listaCadetes.RemoveAll(x => x.Id == id);
            _DB.SaveAllCadetes();
            return View("MostrarCadetes", _DB.Cadeteria.listaCadetes);
        }

        public IActionResult SelectCadete(Guid id)
        {
            var cadeteToEdit = _DB.Cadeteria.listaCadetes.Find(x => x.Id == id);
            return View(cadeteToEdit);
        }

        public IActionResult EditCadete(Guid id, string nombre, string apellido, string tel)
        {
            Cadete cadADevolver = _DB.Cadeteria.listaCadetes.Find(x => x.Id == id);
            cadADevolver.Nombre = nombre;
            cadADevolver.Apellido = apellido;
            cadADevolver.Telefono = tel;
            _DB.SaveAllCadetes();
            return View("MostrarCadetes", _DB.Cadeteria.listaCadetes);
        }
    }
}
