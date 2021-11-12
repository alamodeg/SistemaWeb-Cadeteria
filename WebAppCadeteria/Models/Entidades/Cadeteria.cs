using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
{ 
    public class Cadeteria
    {
        public List<Cadete> ListaCadetes { get; set; }
        public List<Pedido> ListaPedidos { get; set; }

        public Cadeteria()
        {
            ListaCadetes = new List<Cadete>();
            ListaPedidos = new List<Pedido>();
        }
    }
}
