using System.Collections.Generic;

namespace C_RestApiNet5.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T GetBy<V>(string propertyName, V PropertyValue);

        bool Create(T entity);

        bool Update(T entity);

        bool Delete(int id);
    }
}