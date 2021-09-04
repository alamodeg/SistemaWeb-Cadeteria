using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
    class Cliente
    {
        Guid id;
        string apellido;
        string direccion;
        string telefono;

        public Cliente(string apellido, string direccion, string telefono)
        {
            this.Id = Guid.NewGuid();
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public Guid Id { get => id; set => id = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
