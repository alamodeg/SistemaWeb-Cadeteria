using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCadeteria.Models.Repositorio
{
    public class ClienteRepositorio
    {
        private readonly string _connectionString;

        public ClienteRepositorio(string conectionString)
        {
            _connectionString = conectionString;
        }

        public List<Cliente> GetEntities()
        {
            List<Cliente> listacliente = new();
            string SQLiteQuery = @"SELECT * from Clientes";
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
                                Cliente cliente = new Cliente();
                                cliente.Id = Convert.ToInt32(dataReader["clienteID"]);
                                cliente.Apellido = dataReader["clienteNombre"].ToString();
                                cliente.Telefono = dataReader["clienteTelefono"].ToString();
                                cliente.Direccion = dataReader["clienteDireccion"].ToString();
                                listacliente.Add(cliente);
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
            return listacliente;
        }

        public void AddEntity(Cliente cliente)
        {
            string SQLiteQuery = @"INSERT INTO Clientes(clienteNombre, clienteDireccion, clienteTelefono)
                                               values(@apellido, @direccion, @telefono);";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@apellido", cliente.Apellido);
                        command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                        command.Parameters.AddWithValue("@telefono", cliente.Telefono);
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
    }
}
