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
            return View(_DB.Cadeteria.ListaPedidos);
        }

        public IActionResult AddPedido(string apellido, string nombre, string tel, string dir, string obs, Guid id)
        {
            if (apellido is null && dir is null && obs is null && nombre is null && tel is null)
            {
                return View(_DB.Cadeteria.ListaCadetes);
            }

            Pedido nuevoPed = new Pedido(obs,apellido,dir,tel);
            _DB.Cadeteria.ListaCadetes.Find(item => item.Id == id).CargarPedido(nuevoPed);
            _DB.Cadeteria.ListaPedidos.Add(nuevoPed);
            _DB.SaveAllCadetes(); //reescribo el archivo cadetes ahora con nuevo pedido
            _DB.SaveAllPedidos(); //guardo todos los pedidos
            return View(_DB.Cadeteria.ListaCadetes);
        }

        public IActionResult DeletePedido(Guid id)
        {
            //_DB.Cadeteria.ListaCadetes.Find(item => item.ListadoPedidos.Find == id); //busca cadete con ese pedido
            foreach (var item in _DB.Cadeteria.ListaCadetes)
            {
                item.ListadoPedidos.RemoveAll(item => item.Id == id);
            }
            _DB.SaveAllCadetes();
            _DB.Cadeteria.ListaPedidos.RemoveAll(x => x.Id == id);
            _DB.SaveAllPedidos();
            return View("MostrarPedidos", _DB.Cadeteria.ListaPedidos);
        }
    }
}
