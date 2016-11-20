using System;
using System.Collections.Generic;
using System.Data.Entity;
using DomainShop;
using RepositoryShop.Contexts;

namespace RepositoryShop
{
    public class SQLPropertyRepository : IRepository<Property>
    {
        private PropertyContext _db;

        public SQLPropertyRepository()
        {
            _db = new PropertyContext();
        }

        private bool _disposed = false;

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
        }

        public void Delete(int id)
        {
            Property property = _db.Properties.Find(id);
            if (property != null)
            {
                _db.Properties.Remove(property);
            }
        }

        public void Update(Property item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}