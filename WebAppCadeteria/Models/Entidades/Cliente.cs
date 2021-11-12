using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Cliente(string apellido, string direccion, string telefono)
        {
            this.Id = Guid.NewGuid();
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
    }
}
