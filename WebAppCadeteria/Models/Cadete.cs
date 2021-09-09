using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
    public class Cadete
    {
        Guid id;
        string nombre;
        string apellido;
        string telefono;
        List<Pedido> listadoPedidos;

        public Cadete(string nombre, string apellido, string telefono)
        {
            this.id = Guid.NewGuid();
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }

        public Guid Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        internal List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public void CargarPedido(Pedido pedido)
        {
            listadoPedidos.Add(pedido);
        }
    }
}
