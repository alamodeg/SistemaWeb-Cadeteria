using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Model
{
    public class MostrarCadetesVM
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public bool EsActivo { get; set; }

        public int TotalPedidos { get; set; }
       
        public MostrarCadetesVM()
        {
        }
    }

}
