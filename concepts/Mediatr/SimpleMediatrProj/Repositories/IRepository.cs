using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleMediatrProj.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Func<T, bool> filter);
        IEnumerable<T> Get(Func<T, int, bool> filter);
        void Save(T model);
    }
}