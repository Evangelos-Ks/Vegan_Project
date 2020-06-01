using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Vegan.Entities.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);

    }
}
