using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cadeteria.Model
{
    public class DBTemporal
    {
        public Cadeteria Cadeteria { get; set; }

        string path1 = @"Cadetes.json";
        string path2= @"Pedidos.json";

        public DBTemporal()
        {
            Cadeteria = new Cadeteria();
            if (ReadCadetes() != null)
            {
                Cadeteria.listaCadetes = ReadCadetes();
            }
        }

        /// <summary>
        /// Guarda la instancia global de cadetes
        /// </summary>
        public void SaveAllCadetes()
        {
            try
            {
                string CadeteJson = JsonSerializer.Serialize(Cadeteria.listaCadetes);
                using (FileStream miArchivo = new FileStream(path1, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(miArchivo))
                    {
                        writer.Write(CadeteJson);
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        public List<Cadete> ReadCadetes()
        {
            List<Cadete> CadeteJson = null;
            try
            {
                if (File.Exists(path1))
                {
                    using (FileStream miArchivo = new FileStream(path1, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(miArchivo))
                        {
                            string StrCadetes = reader.ReadToEnd();
                            CadeteJson = JsonSerializer.Deserialize<List<Cadete>>(StrCadetes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return CadeteJson;
        }
    }
}
