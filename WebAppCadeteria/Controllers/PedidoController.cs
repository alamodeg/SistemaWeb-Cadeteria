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
        private readonly List<Pedido> _listaPedido;

        public PedidoController(ILogger<PedidoController> logger, List<Cadete> listaCadete, List<Pedido> listaPedido)
        {
            _logger = logger;
            _listaCadete = listaCadete;
            _listaPedido = listaPedido;
        }

        public IActionResult MostrarPedidos()
        {
            return View(_listaPedido);
        }
        public IActionResult CargarPedido(string apellido, string nombre, string tel, string dir, string obs)
        {
            if (apellido is null && dir is null && obs is null && nombre is null && tel is null) return View(_listaCadete);

            Pedido nuevoPed = new Pedido(obs,apellido,dir,tel);
            foreach (var item in _listaCadete)
            {
                {
                    item.CargarPedido(nuevoPed); //agrego el pedido al cadete
                    _listaPedido.Add(nuevoPed); //lista de pedidos externa al cadete
                }
            }
            return View(_listaCadete);
        }
    }
}
