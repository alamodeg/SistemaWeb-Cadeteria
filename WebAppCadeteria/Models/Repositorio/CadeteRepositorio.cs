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

        public Cadete GetEntity(int id)
        {
            string SQLiteQuery = "SELECT * FROM Cadetes WHERE cadeteID = @id";

            using (var connection = new SQLiteConnection(_connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    var DataReader = command.ExecuteReader();
                    DataReader.Read();

                    Cadete cadete = new Cadete()
                    {
                        Id = Convert.ToInt32(DataReader["cadeteID"]),
                        Nombre = DataReader["cadeteNombre"].ToString(),
                        Telefono = DataReader["cadeteTelefono"].ToString(),
                        Direccion = DataReader["cadeteDireccion"].ToString(),
                    };

                    connection.Close();
                    return cadete;
                }
            }
        }

        public List<Cadete> GetEntities()
        {
            List<Cadete> listaCadetes = new List<Cadete>();
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Cadetes WHERE activo = 1";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();
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
                connection.Close();
            }
            return listaCadetes;
        }

        public void AddEntity(Cadete cadete)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string SQLiteQuery = "INSERT INTO Cadetes(cadeteNombre, cadeteDireccion, cadeteTelefono, activo) values(@nombre, @direccion, @telefono, 1); ";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@nombre", cadete.Nombre);
                command.Parameters.AddWithValue("@direccion", cadete.Direccion);
                command.Parameters.AddWithValue("@telefono", cadete.Telefono);
                command.Parameters.AddWithValue("@true", cadete.EsActivo);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void EditEntity(Cadete cadModificar)
        {
            try
            {
                string SQLiteQuery = @"UPDATE Cadetes 
                                    SET cadeteNombre = @nombre, cadeteTelefono = @telefono, cadeteDireccion = @direccion
                                    WHERE cadeteID = @cadeteID";

                using (var conexion = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@cadeteID", cadModificar.Id);
                        command.Parameters.AddWithValue("@nombre", cadModificar.Nombre);
                        command.Parameters.AddWithValue("@telefono", cadModificar.Telefono);
                        command.Parameters.AddWithValue("@direccion", cadModificar.Direccion);

                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var mje = ex.Message;
            }
        }

        public void DeleteEntity(int id)
        {
            try
            {
                string SQLiteQuery = @"UPDATE Cadetes 
                                    SET activo = 0
                                    WHERE cadeteID = @id";

                using (var conexion = new SQLiteConnection(_connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var mje = ex.Message;
            }
        }
    }
}
