using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repositorio
{
    public class CadeteRepositorio
    {
        private readonly string _connectionString;

        public CadeteRepositorio(string conectionString)
        {
            _connectionString = conectionString;
        }

        public List<Cadete> getAllCadetes()
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
                        Direccion = dataReader["cadeteDireccion"].ToString()
                    };
                    listaCadetes.Add(cadete);
                }
                connection.Close();
            }
            return listaCadetes;
        }

        public void addCadete(Cadete cadete)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string SQLiteQuery = "INSERT INTO Cadetes(cadeteNombre, cadeteDireccion, cadeteTelefono, activo) values(@nombre, @direccion, @telefono, 1); ";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@nombre", cadete.Nombre);
                command.Parameters.AddWithValue("@direccion", cadete.Direccion);
                command.Parameters.AddWithValue("@telefono", cadete.Telefono);
                command.Parameters.AddWithValue("@true", cadete.Activo);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void editCadete(Cadete cadModificar)
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

        public void deleteCadete(int id)
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
