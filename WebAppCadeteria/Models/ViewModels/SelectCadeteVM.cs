using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCadeteria.Models.ViewModels
{
    public class AddCadeteVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool EsActivo { get; set; }
        public int TotalPedidos { get; set; }
    }
}
