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
            string SQLiteQuery = "SELECT * FROM Cadetes WHERE esActivo = 1";

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
                                Cadete cadete = new Cadete()
                                {
                                    Id = Convert.ToInt32(dataReader["cadeteID"]),
                                    Nombre = dataReader["cadeteNombre"].ToString(),
                                    Telefono = dataReader["cadeteTelefono"].ToString(),
                                    Direccion = dataReader["cadeteDireccion"].ToString(),
                                };
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
                        command.Parameters.AddWithValue("@true", cadete.EsActivo);
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
                                      SET activo = 0
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
    }
}
