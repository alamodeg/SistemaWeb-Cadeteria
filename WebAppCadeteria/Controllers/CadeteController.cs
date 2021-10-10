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
            return View(_DB.Cadeteria.ListaCadetes);
        }

        public IActionResult AddCadete(string nombre, string apellido, string tel)
        {
            if (nombre is null && apellido is null && tel is null)
            {
                return View();
            }
            else
            {
                _DB.Cadeteria.ListaCadetes.Add(new Cadete(nombre, apellido, tel));
                _DB.SaveAllCadetes();
                return View();
            }
        }

        public IActionResult DeleteCadete(Guid id_cadete)
        {
            //var DeletedPedidos = _DB.Cadeteria.ListaCadetes.Find(x => x.Id == id).ListadoPedidos; //guardo los pedidos
            _DB.Cadeteria.ListaCadetes.RemoveAll(cad => cad.Id == id_cadete); // elimino al cadete
            _DB.SaveAllCadetes();
            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }

        public IActionResult SelectCadete(Guid id_cadete)
        {
            var cadeteToEdit = _DB.Cadeteria.ListaCadetes.Find(cad => cad.Id == id_cadete);
            return View(cadeteToEdit);
        }

        public IActionResult EditCadete(Guid id_cadete, string nombre, string apellido, string tel)
        {
            Cadete cadADevolver = _DB.Cadeteria.ListaCadetes.Find(cad => cad.Id == id_cadete);
            cadADevolver.Nombre = nombre;
            cadADevolver.Apellido = apellido;
            cadADevolver.Telefono = tel;
            _DB.SaveAllCadetes();
            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }
    }
}
