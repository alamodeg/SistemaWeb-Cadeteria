using Cadeteria.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Repositorio;
using System;

namespace WebAppCadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly CadeteRepositorio _cadeteRepositorio;

        public CadeteController(ILogger<CadeteController> logger, CadeteRepositorio cadeteRepositorio)
        {
            _logger = logger;
            _cadeteRepositorio = cadeteRepositorio;
        }

        public IActionResult MostrarCadetes()
        {
            return View(_cadeteRepositorio.GetEntities());
        }

        public IActionResult AddCadete(string nombre, string direccion, string tel)
        {
            if (nombre is null && direccion is null && tel is null)
            {
                return View();
            }
            else
            {
                _cadeteRepositorio.AddEntity(new Cadete(nombre, direccion, tel));
                return View("MostrarCadetes",_cadeteRepositorio.GetEntities());
            }
        }

        public IActionResult DeleteCadete(int id_cadete)
        {
            _cadeteRepositorio.DeleteEntity(id_cadete);
            return View("MostrarCadetes",_cadeteRepositorio.GetEntities());
        }

        public IActionResult SelectCadete(int id_cadete)
        {
            var cadeteToEdit = _cadeteRepositorio.GetEntity(id_cadete);
            return View(cadeteToEdit);
        }

        //SE PIERDE EL ID CADETE DESDE LA VISTA A EDIT CADETE
        public IActionResult EditCadete(int id_cadete, string nombre, string direccion, string tel)
        {
            Cadete cadModificar = new Cadete
            {
                Id = id_cadete,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = tel
            };

            _cadeteRepositorio.EditEntity(cadModificar);
            return View("MostrarCadetes", _cadeteRepositorio.GetEntities());
        }
    }
}
