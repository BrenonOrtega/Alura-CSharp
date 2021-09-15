using System;

namespace ArraysAndCollection.Models.Shared
{
    public interface IRepository<T>
    {
        T[] Get(Func<T, bool> filter = null);
        T GetSingle(Func<T, bool> filter = null);
        bool Add(T entity);
        bool Remove(Func<T, bool> filter = null);
        bool Update(T entity, Func<T, bool> filter = null);
    }
}