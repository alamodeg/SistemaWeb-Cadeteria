using AutoMapper;
using Cadeteria.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCadeteria.Models.Repositorio;
using WebAppCadeteria.Models.ViewModels;

namespace WebAppCadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IMapper _mapper;
        private readonly PedidoRepositorio _pedidoRepositorio;
        private readonly CadeteRepositorio _cadeteRepositorio;
        private readonly ClienteRepositorio _clienteRepositorio;

        public PedidoController(ILogger<PedidoController> logger, IMapper mapper, PedidoRepositorio pedidoRepositorio, CadeteRepositorio cadeteRepositorio, ClienteRepositorio clienteRepositorio)
        {
            _logger = logger;
            _mapper = mapper;
            _pedidoRepositorio = pedidoRepositorio;
            _cadeteRepositorio = cadeteRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult MostrarPedidos()
        {
            MostrarPedidosVM pedidosYcadetes = new MostrarPedidosVM(_cadeteRepositorio.GetEntities(), _pedidoRepositorio.GetEntities());
            return View(pedidosYcadetes);
        }
         
        public IActionResult AltaPedido()
        {
            AltaPedidoVM model = new AltaPedidoVM();
            
            model.listas.listaCadetes = _cadeteRepositorio.GetEntities();
            model.listas.listaClientes = _clienteRepositorio.GetEntities();

            return View(model);
        }

        public IActionResult AddPedido(AltaPedidoVM model)
        {
            model.Pedido.Estado = Estado.NoEntregado;
            _pedidoRepositorio.AddEntity(model.Pedido,model.IdCadete,model.IdCliente);
            return Redirect("MostrarPedidos");

        }
        public IActionResult SelectPedido(int id_pedido)
        {
            var pedidoToEdit = _pedidoRepositorio.GetEntity(id_pedido);
            var pedidoVM = _mapper.Map<EditPedidoVM>(pedidoToEdit);
            pedidoVM.listaCadetes = _cadeteRepositorio.GetEntities();
            pedidoVM.listaClientes = _clienteRepositorio.GetEntities();

            return View(pedidoVM);
        }

        public IActionResult EditPedido(EditPedidoVM pedidoVM)
        {
            Pedido pedModificar = new Pedido
            {
                Id = pedidoVM.Id,
                Observacion = pedidoVM.Observacion,
                Estado = pedidoVM.Estado,
            };

            _pedidoRepositorio.EditEntity(pedModificar,pedidoVM.IdCadete,pedidoVM.IdCliente);
            return Redirect("MostrarPedidos");
        }

        public IActionResult DeletePedido(int id_pedido)
        {
            _pedidoRepositorio.DeleteEntity(id_pedido);
            MostrarPedidosVM pedidosYcadetes = new MostrarPedidosVM(_cadeteRepositorio.GetEntities(), _pedidoRepositorio.GetEntities());
            return View(pedidosYcadetes);
        }
    }
}