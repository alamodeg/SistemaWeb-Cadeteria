using Cadeteria;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppCadeteria.Models;

namespace WebAppCadeteria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly List<Cadete> _listaCadete = new List<Cadete>();

        public HomeController(ILogger<HomeController> logger,List<Cadete> listaCadete)
        {
            _logger = logger;
            _listaCadete = listaCadete;
        }

        public IActionResult Index()
        {
            return View(_listaCadete);
        }

        public IActionResult AltaPedido()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
