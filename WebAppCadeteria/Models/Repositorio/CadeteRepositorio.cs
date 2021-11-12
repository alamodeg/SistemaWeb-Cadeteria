using Cadeteria.Model;
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

        //"default": "Data Source = Cadeteria.db"
        public List<Cadete> getAllEntities()
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
                        Nombre = dataReader["cadeteNombre"].ToString(),
                        Telefono = dataReader["cadeteTelefono"].ToString(),
                        Direccion = dataReader["cadeteTelefono"].ToString()
                    };
                    listaCadetes.Add(cadete);
                }
            }
            return listaCadetes;
        }

        public void Add(Cadete cadete)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string SQLiteQuery = "INSERT INTO Cadetes(cadeteNombre, cadeteDireccion, cadeteTelefono, activo) values(@nombre, @direccion, @telefono, @true); ";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                command.Parameters.AddWithValue("@nombre", cadete.Nombre);
                command.Parameters.AddWithValue("@direccion", cadete.Direccion);
                command.Parameters.AddWithValue("@telefono", cadete.Telefono);
                command.Parameters.AddWithValue("@true", cadete.Activo);
                command.ExecuteNonQuery();
            }
        }
    }
}
