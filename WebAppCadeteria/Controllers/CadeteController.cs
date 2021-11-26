using AutoMapper;
using Cadeteria.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Repositorio;
using System;
using System.Collections.Generic;
using WebAppCadeteria.Models.ViewModels;

namespace WebAppCadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly CadeteRepositorio _cadeteRepositorio;
        private readonly IMapper _mapper;

        public CadeteController(ILogger<CadeteController> logger, CadeteRepositorio cadeteRepositorio, IMapper mapper)
        {
            _logger = logger;
            _cadeteRepositorio = cadeteRepositorio;
            _mapper = mapper;
        }

        public IActionResult MostrarCadetes()
        {
            List<Cadete> listaCadetes = _cadeteRepositorio.GetEntities();
            var listaCadetesVM = _mapper.Map<List<MostrarCadetesVM>>(listaCadetes);
            return View(listaCadetesVM);
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
                List<Cadete> listaCadetes = _cadeteRepositorio.GetEntities();
                var listaCadetesVM = _mapper.Map<List<MostrarCadetesVM>>(listaCadetes);
                return View("MostrarCadetes", listaCadetesVM);
            }
        }

        public IActionResult DeleteCadete(int id_cadete)
        {
            _cadeteRepositorio.DeleteEntity(id_cadete);
            List<Cadete> listaCadetes = _cadeteRepositorio.GetEntities();
            var listaCadetesVM = _mapper.Map<List<MostrarCadetesVM>>(listaCadetes);
            return View("MostrarCadetes", listaCadetesVM);
        }

        public IActionResult SelectCadete(int id_cadete)
        {
            var cadeteToEdit = _cadeteRepositorio.GetEntity(id_cadete);
            return View(cadeteToEdit);
        }

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
            List<Cadete> listaCadetes = _cadeteRepositorio.GetEntities();
            var listaCadetesVM = _mapper.Map<List<MostrarCadetesVM>>(listaCadetes);
            return View("MostrarCadetes", listaCadetesVM);
        }
    }
}
