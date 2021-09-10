using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria.Model
{ 
    public class Sucursal
    {
        string nombre;
        List<Cadete> listadoCadetes;

        public Sucursal(string nombre, List<Cadete> listadoCadetes)
        {
            this.Nombre = nombre;
            this.ListadoCadetes = listadoCadetes;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public void AgregarCadete(Cadete cad)
        {
            listadoCadetes.Add(cad);
        }
    }
}
