using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
{
    public class PedidoViewModel
    {
        public List<Cadete> ListaCadetes { get; set; }
        public List<Pedido> ListaPedidos { get; set; }

        public PedidoViewModel(List<Cadete> listaCadetes, List<Pedido> listaPedidos)
        {
            ListaPedidos = listaPedidos;
            ListaCadetes = listaCadetes;
        }
    }
}
