using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using WebAppCadeteria.Models.Entidades;

namespace WebAppCadeteria.Models.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateUsuario(Usuario usuario)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    string SQLiteQuery = @"INSERT INTO Usuarios (usuario, password)
                                        VALUES (@nombre, @password);";

                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@password", usuario.Password);

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

        public int GetUsuarioID(string nombre, string password)
        {
            int usuarioID = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    string SQLiteQuery = @"SELECT usuarioID FROM Usuarios
                                    WHERE usuario = @nombre AND password = @password;";

                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@password", password);

                        connection.Open();

                        using (SQLiteDataReader DataReader = command.ExecuteReader())
                        {
                            DataReader.Read();
                            usuarioID = Convert.ToInt32(DataReader["usuarioID"]);
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return usuarioID;
        }

        public bool identidicadorValido(int id)
        {
            bool esValido = false;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    string SQLiteQuery = @"SELECT usuarioID FROM Usuarios WHERE usuarioID = @id;";

                    using (SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();

                        using (SQLiteDataReader DataReader = command.ExecuteReader())
                        {
                            DataReader.Read();
                            int idUsuario = Convert.ToInt32(DataReader["usuarioID"]);
                            connection.Close();

                            if (id == idUsuario)
                            {
                                esValido = true;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return esValido;
        }

    }
}