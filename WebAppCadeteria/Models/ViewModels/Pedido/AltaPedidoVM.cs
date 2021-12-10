using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCadeteria.Models.ViewModels
{
    public class AltaPedidoVM
    {
        public AltaPedidoVM()
        {
            listas = new AddPedidoVM();
        }

        [Required]
        public Pedido Pedido { get; set; }
        [Required]
        public int IdCadete { get; set; }
        [Required]
        public int IdCliente { get; set; }

        public AddPedidoVM listas { get; set; }
               
    }
}
