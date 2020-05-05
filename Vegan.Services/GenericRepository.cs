﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vegan.Entities.Interfaces;

namespace Vegan.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        //========================================= Fields =================================================================
        protected readonly DbContext Context;

        //========================================= Constructor ============================================================
        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        //========================================= Methods ================================================================
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Edit(TEntity entity) //I implemented it by my self. I don't know if it works. Evangelos
        {
            Context.Set<TEntity>();
            Context.Entry(entity).State = EntityState.Modified;
            //Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

    }
}
