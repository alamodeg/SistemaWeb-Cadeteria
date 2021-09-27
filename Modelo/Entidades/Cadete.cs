using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
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
            this.Id = Guid.NewGuid();
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            listadoPedidos = new List<Pedido>();
        }

        public Guid Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public void CargarPedido(Pedido pedido)
        {
            ListadoPedidos.Add(pedido);
        }
    }
}
