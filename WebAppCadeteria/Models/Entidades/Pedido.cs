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

        public Pedido(string observacion, string apellido, string dir, string tel)
        {
            this.Observacion = observacion;
            this.Estado = Estado.NoEntregado;
            this.Cliente = new Cliente(apellido, dir, tel);
        }

        /// <summary>
        /// Para el deserealizador que no funciona
        /// </summary>
        public Pedido()
            {
            }
    }
}
