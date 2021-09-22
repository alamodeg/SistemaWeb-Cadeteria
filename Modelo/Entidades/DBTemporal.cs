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

        public DBTemporal()
        {
            Cadeteria = new Cadeteria();
            if (ReadCadetes() != null)
            {
                Cadeteria.listaCadetes = ReadCadetes();
            }
        }

        public void SaveCadete(List<Cadete> cadetes)
        {
            try
            {
                string CadeteJson = JsonSerializer.Serialize(cadetes);
                string path = @"Cadetes.json";
                {
                    using (FileStream miArchivo = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter writer = new StreamWriter(miArchivo))
                        {
                            writer.Write(CadeteJson);
                        }
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
                string path = @"Cadetes.json";
                if (File.Exists(path))
                {
                    {
                        using (FileStream miArchivo = new FileStream(path, FileMode.Open))
                        {
                            using (StreamReader reader = new StreamReader(miArchivo))
                            {
                                string StrCadetes = reader.ReadToEnd();
                                CadeteJson = JsonSerializer.Deserialize<List<Cadete>>(StrCadetes);
                            }
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
