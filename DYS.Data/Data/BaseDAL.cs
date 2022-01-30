using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DYS.Common.VO;

namespace DYS.Data.Data
{
    public abstract class BaseDAL<TEntity> where TEntity : BaseEntity
    {
        private ModelContext _db;
        protected virtual ModelContext Db
        {
            get
            {
                return _db ?? (_db = new ModelContext());
            }
        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>>[] predicates)
        {
            var queryable = Db.Set<TEntity>().AsQueryable();

            queryable = predicates.Aggregate(queryable, (current, predicate) => current.Where(predicate));

            return queryable.ToList();
        }
	
        public virtual IEnumerable<TEntity> SelectOrderedPaged<TEntity, TKey>(List<Expression<Func<TEntity, bool>>> predicates, Expression<Func<TEntity, TKey>>[] keySelectors, bool asc) where TEntity : class
        {
            IQueryable<TEntity> queryable = Db.Set<TEntity>().AsQueryable();

            if (predicates != null)
                queryable = predicates.Aggregate(queryable, (current, predicate) => current.Where(predicate));

            if (keySelectors != null)
            {
                queryable = asc ? keySelectors.Aggregate(queryable, (current, keySelector) => current.OrderBy(keySelector)) : keySelectors.Aggregate(queryable, (current, keySelector) => current.OrderByDescending(keySelector));
            }

            IEnumerable<TEntity> entities = queryable.ToList();

            return entities;
        }

        public virtual TEntity SelectWithId(object key)
        {
            TEntity entity = Db.Set<TEntity>().Find(key);
            return entity;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            Db.GetValidationErrors();
            Db.SaveChanges();

            return entity;
        }

        public virtual TEntity Update(object key, TEntity entity)
        {
            var tmp = Db.Set<TEntity>().Find(key);

            if (tmp == null)
                return null;

            Db.Entry(tmp).State = EntityState.Modified;
            Db.Entry(tmp).CurrentValues.SetValues(entity);

            Db.SaveChanges();

            return entity;
        }

        public virtual bool Delete(object key)
        {
            bool b;
            try
            {
                var item = Db.Set<TEntity>().Find(key);
                Db.Entry(item).State = EntityState.Deleted;
                Db.SaveChanges();
                b = true;
            }
            catch
            {
                b = false;
            }
            finally
            {
                Db.Dispose();
            }

            return b;
        }
    }
}
