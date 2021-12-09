using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCadeteria.Models.ViewModels
{
    public class SelectCadeteVM
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
    }
}
