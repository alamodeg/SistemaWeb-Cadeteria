using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppCadeteria.Models.ViewModels
{
    public class AddPedidoVM
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Observaciones")]
        public string Obs { get; set; }

        public List<Cadete> listaCadetes { get; set; }
        public List<Cliente> listaClientes { get; set; }

        public AddPedidoVM(List<Cadete> listaCadetes, List<Cliente> listaClientes)
        {
            this.listaCadetes = listaCadetes;
            this.listaClientes = listaClientes;
        }

        public AddPedidoVM()
        {
        }
    }
}
