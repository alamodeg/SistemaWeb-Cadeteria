using Cadeteria.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modelo.Repositorio;
using System;

namespace WebAppCadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly DBTemporal _DB;
        private readonly CadeteRepositorio _cadeteRepositorio;

        public CadeteController(ILogger<CadeteController> logger, DBTemporal DB, CadeteRepositorio cadeteRepositorio)
        {
            _logger = logger;
            _DB = DB;
            _cadeteRepositorio = cadeteRepositorio;

        }

        public IActionResult MostrarCadetes()
        {
            return View(_cadeteRepositorio.getAllEntities());
        }

        public IActionResult AddCadete(string nombre, string direccion, string tel)
        {
            if (nombre is null && direccion is null && tel is null)
            {
                return View();
            }
            else
            {
                _cadeteRepositorio.Add(new Cadete(nombre, direccion, tel));
                //_DB.Cadeteria.ListaCadetes.Add(new Cadete(nombre, direccion, tel));
                //_DB.SaveAllCadetes();
                return View();
            }
        }

        public IActionResult DeleteCadete(int id_cadete)
        {
            //var DeletedPedidos = _DB.Cadeteria.ListaCadetes.Find(x => x.Id == id).ListadoPedidos; //guardo los pedidos
            _DB.Cadeteria.ListaCadetes.RemoveAll(cad => cad.Id == id_cadete); // elimino al cadete
            _DB.SaveAllCadetes();
            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }

        public IActionResult SelectCadete(int id_cadete)
        {
            var cadeteToEdit = _DB.Cadeteria.ListaCadetes.Find(cad => cad.Id == id_cadete);
            return View(cadeteToEdit);
        }

        public IActionResult EditCadete(int id_cadete, string nombre, string direccion, string tel)
        {
            Cadete cadADevolver = _DB.Cadeteria.ListaCadetes.Find(cad => cad.Id == id_cadete);
            cadADevolver.Nombre = nombre;
            cadADevolver.Direccion = direccion;
            cadADevolver.Telefono = tel;
            _DB.SaveAllCadetes();
            return View("MostrarCadetes", _DB.Cadeteria.ListaCadetes);
        }
    }
}
