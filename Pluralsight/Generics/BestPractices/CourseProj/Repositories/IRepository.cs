using System.Collections.Generic;

namespace BestPractices
{
    interface IRepository<T>
    {
        IEnumerable<T> List { get; }
        void Add(T obj);
    }
}