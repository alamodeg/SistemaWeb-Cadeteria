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

        public IActionResult DeleteCadete(Guid id)
        {
            var DeletedPedidos = _DB.Cadeteria.ListaCadetes.Find(x => x.Id == id).ListadoPedidos; //guardo los pedidos
            _DB.Cadeteria.ListaCadetes.RemoveAll(x => x.Id == id); // elimino al cadete
            _DB.SaveAllCadetes();
            //poder reasignar los pedidos a otro cadete pedido y list de cadetes

            //foreach (var ped in _DB.Cadeteria.ListaPedidos)
            //{
            //    foreach (var x in DeletedPedidos)
            //    {
            //        if (ped.Id != x.Id)
            //        {
            //            _DB.Cadeteria.ListaPedidos.Add(x);
            //        }
            //    }    
            //}
            //_DB.SaveAllPedidos();
            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }

        public IActionResult SelectCadete(Guid id)
        {
            var cadeteToEdit = _DB.Cadeteria.ListaCadetes.Find(x => x.Id == id);
            return View(cadeteToEdit);
        }

        public IActionResult EditCadete(Guid id, string nombre, string apellido, string tel)
        {
            Cadete cadADevolver = _DB.Cadeteria.ListaCadetes.Find(x => x.Id == id);
            cadADevolver.Nombre = nombre;
            cadADevolver.Apellido = apellido;
            cadADevolver.Telefono = tel;
            _DB.SaveAllCadetes();
            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }
    }
}
