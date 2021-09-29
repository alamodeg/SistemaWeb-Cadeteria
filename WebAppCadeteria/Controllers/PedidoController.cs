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
        private readonly DBTemporal _DB;

        public PedidoController(ILogger<PedidoController> logger,DBTemporal DB)
        {
            _logger = logger;
            _DB = DB;
        }

        public IActionResult MostrarPedidos()
        {
            return View(_DB.Cadeteria.listaPedidos);
        }

        public IActionResult CargarPedido(string apellido, string nombre, string tel, string dir, string obs, Guid id)
        {
            if (apellido is null && dir is null && obs is null && nombre is null && tel is null) return View(_DB.Cadeteria.listaCadetes);

            Pedido nuevoPed = new Pedido(obs,apellido,dir,tel);
            _DB.Cadeteria.listaCadetes.Find(item => item.Id == id).CargarPedido(nuevoPed);
            //foreach (var item in _DB.Cadeteria.listaCadetes)
            //{
            //    if (item.Id == id)
            //    {
            //        item.CargarPedido(nuevoPed);
            //    }
            //}
            _DB.Cadeteria.listaPedidos.Add(nuevoPed); //cargo a DB el nuevo pedido que se muestra
            return View(_DB.Cadeteria.listaCadetes);
        }
    }
}
