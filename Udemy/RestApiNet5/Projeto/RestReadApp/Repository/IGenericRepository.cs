using System.Collections.Generic;

namespace RestReadApp.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T FindById<VKey>(VKey id);

        IEnumerable<T> FindAll();

        T Create(T model);

        Vkey Delete<Vkey>(Vkey id);

        T Update<VKey>(VKey id, T model);
    }
}