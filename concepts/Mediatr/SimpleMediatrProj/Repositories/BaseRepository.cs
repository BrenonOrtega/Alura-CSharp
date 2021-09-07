using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleMediatrProj.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected abstract List<T> Models { get; } 

        public IEnumerable<T> Get(Func<T, bool> filter)
        {
            return Models.Where(filter);
        }

        public IEnumerable<T> Get(Func<T, int, bool> filter)
        {
            return Models.Where(filter);
        }

        public void Save(T model)
        {
            Models.Add(model);
        }
    }
}