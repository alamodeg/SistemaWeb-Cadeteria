using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
{
    public enum Estado { NoEntregado, Entregado, Encamino, Cancelado }
    public class Pedido
    {
        public int Id { get; set; }
        public string Observacion { get; set; }
        public Cliente Cliente { get; set; }
        public Estado Estado { get; set; }

        public Pedido(string observacion, Cliente cliente, Estado estado)
        {
            this.Observacion = observacion;
            this.Estado = estado;
            this.Cliente = cliente;
            this.Estado = Estado.NoEntregado;
        }

        public Pedido()
            {
            }
    }
}
