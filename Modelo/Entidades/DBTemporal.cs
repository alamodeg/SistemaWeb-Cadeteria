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

        readonly string pathCadetes = @"Cadetes.json";
        readonly string pathPedidos = @"Pedidos.json";

        public DBTemporal()
        {
            Cadeteria = new Cadeteria();
            if (ReadCadetes() != null)
            {
                Cadeteria.ListaCadetes = ReadCadetes();
            }
            if (ReadPedidos() != null)
            {
                Cadeteria.ListaPedidos = ReadPedidos();
            }
        }

        /// <summary>
        /// Guarda la instancia global de cadetes, se debe especificar el path de guardado
        /// </summary>
        public void SaveAllCadetes()
        {
            try
            {
                string CadeteJson = JsonSerializer.Serialize(Cadeteria.ListaCadetes);
                using (FileStream miArchivo = new FileStream(pathCadetes, FileMode.Create))
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

        /// <summary>
        /// Guarda la instancia global de pedidos, se debe especificar el path de guardado
        /// </summary>
        public void SaveAllPedidos()
        {
            try
            {
                string PedidoJson = JsonSerializer.Serialize(Cadeteria.ListaPedidos);
                using (FileStream miArchivo = new FileStream(pathPedidos, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(miArchivo))
                    {
                        writer.Write(PedidoJson);
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

        private List<Pedido> ReadPedidos()
        {
            List<Pedido> PedidoJson = null;
            try
            {
                if (File.Exists(pathPedidos))
                {
                    using (FileStream miArchivo = new FileStream(pathPedidos, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(miArchivo))
                        {
                            string StrPedidos = reader.ReadToEnd();
                            PedidoJson = JsonSerializer.Deserialize<List<Pedido>>(StrPedidos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return PedidoJson;
        }

        /// <summary>
        /// Se ejecuta unicamente al abrir la webapp
        /// </summary>
        /// <returns></returns>
        private List<Cadete> ReadCadetes()
        {
            List<Cadete> CadeteJson = null;
            try
            {
                if (File.Exists(pathCadetes))
                {
                    using (FileStream miArchivo = new FileStream(pathCadetes, FileMode.Open))
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