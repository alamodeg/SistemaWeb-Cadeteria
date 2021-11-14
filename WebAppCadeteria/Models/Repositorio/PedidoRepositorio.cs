using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Repositorio
{
    public class PedidoRepositorio : IRepository<Pedido>
    {
        private readonly string _connectionString;

        public PedidoRepositorio(string conectionString)
        {
            _connectionString = conectionString;
        }

        public void AddEntity(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void EditEntity(Pedido pedModificar)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> GetEntities()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string SQLiteQuery = "SELECT * FROM Pedidos";
                SQLiteCommand command = new SQLiteCommand(SQLiteQuery, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Pedido ped = new Pedido()
                    {
                        Id = Convert.ToInt32(dataReader["cadeteID"]),
                        Observacion = dataReader["pedidoObs"].ToString(),
                        Estado = (Estado)Convert.ToInt32(dataReader["pedidoEstado"])
                    };
                    listaPedidos.Add(ped);
                }
                connection.Close();
            }
            return listaPedidos;
        }

        public Pedido GetEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}