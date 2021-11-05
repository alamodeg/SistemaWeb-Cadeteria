using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
{
    public class Cadete
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public List<Pedido> ListadoPedidos { get; set; }

        public Cadete()
        {
        }

        public Cadete(string nombre, string apellido, string telefono)
        {
            this.Id = Guid.NewGuid();
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            ListadoPedidos = new List<Pedido>();
        }

        public void CargarPedido(Pedido pedido)
        {
            ListadoPedidos.Add(pedido);
        }
    }
}
