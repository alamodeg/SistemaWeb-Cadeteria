using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
    class Pedido
    {
        Guid id;
        string observacion;
        Cliente cliente;
        bool estado;

        public Pedido(string observacion, bool estado, string apellido, string dir, string tel)
        {
            this.id = Guid.NewGuid();
            this.observacion = observacion;
            this.estado = estado;
            this.cliente = new Cliente(apellido,dir,tel);
        }

        public Guid Id { get => id; set => id = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public bool Estado { get => estado; set => estado = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }
    }
}
