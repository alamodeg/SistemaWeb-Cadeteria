using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCadeteria.Models.Repositorio;

namespace WebAppCadeteria.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(UsuarioRepositorio usuarioRepositorio, ILogger<UsuarioController> logger)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
        }


        public IActionResult Login(string username, string password)
        {
            int id = _usuarioRepositorio.GetUsuarioID(username, password);
            if (id != 0)
            {
                HttpContext.Session.SetInt32("idUsuario", id);
                return RedirectToAction("Usuario", "Usuario");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
