using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
{ 
    public class Cadeteria
    {
        public List<Cadete> listaCadetes { get; set; }
        public List<Pedido> listaPedidos { get; set; }


        public Cadeteria()
        {
            listaCadetes = new List<Cadete>();
            listaPedidos = new List<Pedido>();
        }
    }
}
