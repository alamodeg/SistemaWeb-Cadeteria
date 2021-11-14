using Cadeteria.Model;
using System.Collections.Generic;

namespace Models.Repositorio
{
    public interface IRepository<T> where T : class
    {
        void AddEntity(T entity);
        void DeleteEntity(int id);
        void EditEntity(T entity);
        List<T> GetEntities();
        T GetEntity(int id);
    }
}