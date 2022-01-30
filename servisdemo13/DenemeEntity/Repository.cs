using DYS.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace servisdemo13.DenemeEntity
{
    public class Repository<T> where T :class
    {
        private ModelContext db = new ModelContext();
        private DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = db.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }
        public int Save()
        {
            return db.SaveChanges();
        }
    }
}