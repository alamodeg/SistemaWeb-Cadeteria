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
            PedidoViewModel MostrarPedidosVM = new PedidoViewModel(_DB.Cadeteria.ListaPedidos, _DB.Cadeteria.ListaCadetes);
            return View(MostrarPedidosVM);
        }

        public IActionResult AddPedido(string apellido, string nombre, string tel, string dir, string obs, Guid? id)
        {
            if (apellido is null && dir is null && obs is null && nombre is null && tel is null)
            {
                return View(_DB.Cadeteria.ListaCadetes);
            }

            Pedido nuevoPed = new Pedido(obs,apellido,dir,tel);
            if (id is null) //Si no se asigno el cadete
            {
                _DB.Cadeteria.ListaPedidos.Add(nuevoPed);
                _DB.SaveAllPedidos();
            }
            else
            {
                _DB.Cadeteria.ListaCadetes.Find(item => item.Id == id).CargarPedido(nuevoPed);
                _DB.Cadeteria.ListaPedidos.Add(nuevoPed);
                _DB.SaveAllCadetes(); //reescribo el archivo cadetes ahora con nuevo pedido
                _DB.SaveAllPedidos(); //guardo todos los pedidos
            }
            return View(_DB.Cadeteria.ListaCadetes);
        }

        public IActionResult DeletePedido(Guid id)
        {
            foreach (var item in _DB.Cadeteria.ListaCadetes) //elimino el pedido del cadete
            {
                item.ListadoPedidos.RemoveAll(item => item.Id == id);
            }
            _DB.SaveAllCadetes();
            _DB.Cadeteria.ListaPedidos.RemoveAll(x => x.Id == id);
            _DB.SaveAllPedidos();
            PedidoViewModel MostrarPedidosVM = new PedidoViewModel(_DB.Cadeteria.ListaPedidos, _DB.Cadeteria.ListaCadetes);
            return View("MostrarPedidos", MostrarPedidosVM);
        }
    }
}
