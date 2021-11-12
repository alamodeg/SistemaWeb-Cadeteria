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

        public IActionResult AddPedido(string apellido, string nombre, string tel, string dir, string obs, int id_cadete)
        {
            if (apellido is null && dir is null && obs is null && nombre is null && tel is null)
            {
                return View(_DB.Cadeteria.ListaCadetes);
            }

            Pedido nuevoPed = new Pedido(obs,apellido,dir,tel);
            _DB.Cadeteria.ListaPedidos.Add(nuevoPed);
            _DB.Cadeteria.ListaCadetes.Find(cad => cad.Id == id_cadete).CargarPedido(nuevoPed);
            _DB.SaveAllCadetes(); //reescribo el archivo cadetes ahora con nuevo pedido
            _DB.SaveAllPedidos();
            return View(_DB.Cadeteria.ListaCadetes);
        }

        public IActionResult DeletePedido(int id_pedido)
        {
            _DB.Cadeteria.ListaCadetes.ForEach(cad => cad.ListadoPedidos.RemoveAll(ped => ped.Id == id_pedido));
            _DB.Cadeteria.ListaPedidos.RemoveAll(ped => ped.Id == id_pedido);
            _DB.SaveAllCadetes();
            _DB.SaveAllPedidos();
            PedidoViewModel MostrarPedidosVM = new PedidoViewModel(_DB.Cadeteria.ListaPedidos, _DB.Cadeteria.ListaCadetes);
            return View("MostrarPedidos", MostrarPedidosVM);
        }

        public IActionResult ReasingPedido(int id_cadete, int id_pedido)
        {
            PedidoViewModel MostrarPedidosVM = new PedidoViewModel(_DB.Cadeteria.ListaPedidos, _DB.Cadeteria.ListaCadetes);
            var OldPedido = _DB.Cadeteria.ListaPedidos.Find(ped => ped.Id == id_pedido);
            _DB.Cadeteria.ListaCadetes.ForEach(cad => cad.ListadoPedidos.RemoveAll(ped => ped.Id == id_pedido));
            _DB.Cadeteria.ListaCadetes.Find(cad => cad.Id == id_cadete).CargarPedido(OldPedido);
            _DB.SaveAllCadetes();
            return View("MostrarPedidos", MostrarPedidosVM);
        }
    }
}