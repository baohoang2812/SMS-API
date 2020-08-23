using Microsoft.EntityFrameworkCore;
using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudentManagement.Data.Repository
{
    public interface IBaseRepository<E, K>
    {
        IQueryable<E> Get();
        E Update(E entity);
        E Remove(E entity);
        E Create(E entity);
        E FindByKey(K key);       
        int SaveChanges();
        void CreateRange(IEnumerable<E> entityList);
        E Attach(E entity);
        int Count();
    }
    public abstract class BaseRepository<E, K> : IBaseRepository<E, K> where E : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<E> dbSet;

        public BaseRepository(DbContext dbContext)
        {
            context = dbContext;
            dbSet = context.Set<E>();
        }

        public virtual E Create(E entity)
        {
            context.Add(entity);
            return entity;
        }

        public virtual E Remove(E entity)
        {
            context.Remove(entity);
            return entity;
        }

        public virtual int SaveChanges()
        {
            return context.SaveChanges();
        }

        public virtual E Update(E entity)
        {
            context.Update(entity);
            return entity;
        }

        public virtual IQueryable<E> Get()
        {
            throw new NotImplementedException();
        }

        public virtual E FindByKey(K key)
        {
            var entity = context.Find<E>(key);
            return entity;
        }

        public void CreateRange(IEnumerable<E> entityList)
        {
            context.AddRange(entityList);
        }

        public E Attach(E entity)
        {
            return context.Attach(entity).Entity;
        }

        public int Count()
        {
            return dbSet.Count();
        }       
    }
}
