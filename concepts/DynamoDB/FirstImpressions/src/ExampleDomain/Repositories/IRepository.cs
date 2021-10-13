using System;
using ExampleDomain;

namespace ExampleDomain.Repositories
{
    public interface IRepository<out T, V> where T : IEntity<V>
    {
        T GetAsync(Predicate<T> filter);
        T GetByIndexKeyAsync(V hashKey);
    }
}
