using System;
using System.Linq;
using System.Linq.Expressions;

namespace Identity.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        TEntity GetById(int id);

        void Save(TEntity entity);

        void Update<TData>(int id, TData updatedData);

        void Delete(int id);
    }
}