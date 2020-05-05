using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        // This method was not in the videos, but I thought it would be useful to add.
        //TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        //void AddRange(IEnumerable<TEntity> entities);

        //void RemoveRange(IEnumerable<TEntity> entities);
    }
}
