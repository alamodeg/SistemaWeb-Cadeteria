using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCadeteria.Models.ViewModels
{
    public class EditPedidoVM
    {
        public int Id { get; set; }
        public string Observacion { get; set; }
        public Estado Estado { get; set; }
        public int IdCadete { get; set; }
        public int IdCliente { get; set; }
        public List<Cadete> listaCadetes { get; set; }
        public List<Cliente> listaClientes { get; set; }

        public EditPedidoVM()
        {
        }
    }
}
