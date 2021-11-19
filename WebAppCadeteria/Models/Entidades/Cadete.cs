using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
{
    public class Cadete
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool EsActivo { get; set; }
        public List<Pedido> ListadoPedidos { get; set; }

        public Cadete()
        {
        }

        public Cadete(string nombre, string direcion, string telefono)
        {
            this.Nombre = nombre;
            this.Direccion = direcion;
            this.Telefono = telefono;
            this.EsActivo = true;
            ListadoPedidos = new List<Pedido>();
        }

        public void CargarPedido(Pedido pedido)
        {
            ListadoPedidos.Add(pedido);
        }

        public int TotalPedidos()
        {
            if (ListadoPedidos is not null)
            {
                return ListadoPedidos.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
