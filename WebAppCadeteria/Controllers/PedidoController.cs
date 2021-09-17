using Cadeteria.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly List<Cadete> _listaCadete;

        public PedidoController(ILogger<PedidoController> logger, List<Cadete> listaCadete)
        {
            _logger = logger;
            _listaCadete = listaCadete;
        }
        public IActionResult AltaPedido(string apellido, string nombre, string tel, string dir, string obs)
        {
            if (apellido is null && dir is null && obs is null && nombre is null && tel is null) return View(_listaCadete);

            Pedido nuevoPed = new Pedido(obs,apellido,dir,tel);
            foreach (var item in _listaCadete)
            {
                {
                    item.CargarPedido(nuevoPed);
                }
            }
            return View(_listaCadete);
        }
    }
}
