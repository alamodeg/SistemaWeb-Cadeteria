using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositorio
{
    public class CadeteRepositorio : IRepository<Cadete>
    {
        private readonly string _connectionString;

        public CadeteRepositorio(string conectionString)
        {
            _connectionString = conectionString;
        }

        public List<Cadete> GetEntities()
        {
            List<Cadete> listaCadetes = new();
            string SQLiteQuery = @"SELECT *,count(Pedidos.cadeteId) as numPedidos FROM Cadetes
                                    LEFT JOIN Pedidos ON Cadetes.cadeteID = Pedidos.cadeteId
                                    WHERE esActivo = 1
                                    GROUP BY Cadetes.cadeteID";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        connection.Open();
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Cadete cadete = new Cadete();
                                cadete.Id = Convert.ToInt32(dataReader["cadeteID"]);
                                cadete.Nombre = dataReader["cadeteNombre"].ToString();
                                cadete.Telefono = dataReader["cadeteTelefono"].ToString();
                                cadete.Direccion = dataReader["cadeteDireccion"].ToString();
                                cadete.TotalPedidos = Convert.ToInt32(dataReader["numPedidos"]);
                                listaCadetes.Add(cadete);
                            }
                            dataReader.Close();
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return listaCadetes;
        }

        public Cadete GetEntity(int id)
        {
            string SQLiteQuery = "SELECT * FROM Cadetes WHERE cadeteID = @id";
            Cadete cadete = new();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", id);

                        var DataReader = command.ExecuteReader();
                        DataReader.Read();
                        cadete.Id = Convert.ToInt32(DataReader["cadeteID"]);
                        cadete.Nombre = DataReader["cadeteNombre"].ToString();
                        cadete.Telefono = DataReader["cadeteTelefono"].ToString();
                        cadete.Direccion = DataReader["cadeteDireccion"].ToString();
                        DataReader.Close();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return cadete;
        }

        public void AddEntity(Cadete cadete)
        {
            string SQLiteQuery = @"INSERT INTO Cadetes(cadeteNombre, cadeteDireccion, cadeteTelefono, esActivo)
                                               values(@nombre, @direccion, @telefono, 1)";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", cadete.Nombre);
                        command.Parameters.AddWithValue("@direccion", cadete.Direccion);
                        command.Parameters.AddWithValue("@telefono", cadete.Telefono);
                        command.Parameters.AddWithValue("@1", cadete.EsActivo);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        public void EditEntity(Cadete cadModificar)
        {
            string SQLiteQuery = @"UPDATE Cadetes
                                   SET cadeteNombre = @nombre, cadeteTelefono = @telefono, cadeteDireccion = @direccion
                                   WHERE cadeteID = @id";
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", cadModificar.Id);
                        command.Parameters.AddWithValue("@nombre", cadModificar.Nombre);
                        command.Parameters.AddWithValue("@telefono", cadModificar.Telefono);
                        command.Parameters.AddWithValue("@direccion", cadModificar.Direccion);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        public void DeleteEntity(int id)
        {
            string SQLiteQuery = @"UPDATE Cadetes 
                                      SET esActivo = 0
                                      WHERE cadeteID = @id";
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        private List<Pedido> GetPedidos(int id_pedido)
        {
            List<Pedido> listaPedido = new List<Pedido>();
            string SQLiteQuery = "SELECT * FROM Pedido WHERE pedidoID = @id_pedido";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        connection.Open();
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Pedido pedido = new Pedido()
                                {
                                    Id = Convert.ToInt32(dataReader["pedidoID"]),
                                    Observacion = dataReader["pedidoObs"].ToString(),
                                    /*Cliente = new Cliente() { Apellido = dataReader["clienteNombre"].ToString() },
                                    TODO: falta el inner join de la consulta*/
                                    Estado = (Estado)Convert.ToInt32(dataReader["pedidoEstado"]),
                                };
                                listaPedido.Add(pedido);
                            }
                            dataReader.Close();
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return listaPedido;
        }
    }
}
