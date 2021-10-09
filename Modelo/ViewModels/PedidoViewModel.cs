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

        public List<Pedido> ListaPedidos { get; set; }
        public List<Cadete> ListaCadetes { get; set; }

        public PedidoViewModel(List<Pedido> listaPedidos, List<Cadete> listaCadetes)
        {
            ListaPedidos = listaPedidos;
            ListaCadetes = listaCadetes;
        }
    }
}
