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

        //"default": "Data Source = Cadeteria.db"
        public List<Cadete> getAll()
        {
            List<Cadete> listaCadetes = new List<Cadete>();
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Cadetes";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Cadete cadete = new Cadete()
                    {
                        Nombre = dataReader["cadeteNombre"].ToString(),
                        Telefono = dataReader["cadeteTelefono"].ToString()
                    };
                    listaCadetes.Add(cadete);
                }
            }
            return listaCadetes;
        }
    }
}
