using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositorio
{
    public class PedidoRepositorio
    {
        private readonly string _connectionString;

        public PedidoRepositorio(string conectionString)
        {
            _connectionString = conectionString;
        }

        public void AddEntity(Pedido pedido,int idcadete,int idcliente)
        {
            string SQLiteQuery = @"INSERT INTO Pedidos(pedidoObs,clienteId,cadeteId,pedidoEstado)
                                               values(@obs, @idcliente, @idcadete,1);";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@obs", pedido.Observacion);
                        command.Parameters.AddWithValue("@idcliente", idcliente);
                        command.Parameters.AddWithValue("@idcadete", idcadete);
                        command.Parameters.AddWithValue("1", pedido.Estado);
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

        public void DeleteEntity(int id)
        {
            string SQLiteQuery = @"UPDATE Pedidos 
                                      SET esActivo = 0
                                      WHERE pedidoID = @id";
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

        public void EditEntity(Pedido pediModificado,int IdCadete,int IdCliente)
        {
            string SQLiteQuery = @"UPDATE Pedidos 
                                    SET pedidoObs = @observacion,clienteId = @idcliente,cadeteId = @idcadete,pedidoEstado=@estado
                                    WHERE pedidoID = @id;";
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", pediModificado.Id);
                        command.Parameters.AddWithValue("@observacion", pediModificado.Observacion);
                        command.Parameters.AddWithValue("@estado", pediModificado.Estado);
                        command.Parameters.AddWithValue("@idcadete", IdCadete);
                        command.Parameters.AddWithValue("@idcliente", IdCliente);
                        var testo = pediModificado;
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

        public List<Pedido> GetEntities()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            String SQLiteQuery = @"SELECT * FROM Pedidos 
                                        INNER JOIN Cadetes ON Cadetes.cadeteId = Pedidos.CadeteID
                                        INNER JOIN Clientes ON Pedidos.clienteId = Clientes.clienteID";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                {
                    connection.Open();
                    using (SQLiteDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Pedido ped = new Pedido
                            {
                                Id = Convert.ToInt32(dataReader["pedidoID"]),
                                Observacion = dataReader["pedidoObs"].ToString(),
                                Estado = (Estado)Convert.ToInt32(dataReader["pedidoEstado"]),
                                Cliente = new Cliente() { Apellido = dataReader["clienteNombre"].ToString() }
                            };
                            listaPedidos.Add(ped);
                        }
                        connection.Close();
                    }
                }
            }
            return listaPedidos;
        }

        public Pedido GetEntity(int id)
        {
            string SQLiteQuery = @"SELECT * FROM Pedidos 
                                    INNER JOIN Clientes on Pedidos.clienteId = Clientes.clienteID
                                    INNER JOIN Cadetes on Pedidos.cadeteId = Cadetes.cadeteID
                                    where Pedidos.pedidoID = @id; ";
            Pedido pedido = new();

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
                        Cliente cliente = new Cliente(DataReader["clienteNombre"].ToString(), DataReader["clienteDireccion"].ToString(), DataReader["clienteTelefono"].ToString());
                        pedido = new Pedido(Convert.ToInt32(DataReader["pedidoID"]), DataReader["pedidoObs"].ToString(), cliente, (Estado)Convert.ToInt32(DataReader["pedidoEstado"]));
                        //pedido.Estado = (Estado)Convert.ToInt32(DataReader["pedidoEstado"]);
                        
                        DataReader.Close();

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return pedido;
        }
    }
}