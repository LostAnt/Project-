using System;
using System.Collections.Generic;
using System.Data.Entity;
using DomainShop;
using RepositoryShop.Contexts;
using RepositoryShop.IRepositories;

namespace RepositoryShop
{
    public class SqlPropertyRepository : IRepository<Property>
    {
        private readonly dbcontext _db;

        private bool _disposed = false;

        public SqlPropertyRepository(dbcontext context)
        {
           _db = context;
        }

        

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IEnumerable<Property> GetItemList()
        {
            return _db.Properties;
        }

        public Property GetItem(int id)
        {
            return _db.Properties.Find(id);
        }

        public void Create(Property item)
        {
            _db.Properties.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Property property = _db.Properties.Find(id);
            if (property != null)
            {
                _db.Properties.Remove(property);
                _db.SaveChanges();
            }
        }

        public void Update(Property item)
        {
          //  long id =item.PropertyId;
         //   Property property = _db.Properties.Find(id);
            _db.Properties.Remove(item);
            _db.Properties.Add(item);
           //  _db.Entry(item).State = EntityState.Modified; 
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}