using System;
using System.Collections.Generic;
using System.Data.Entity;
using DomainShop;
using RepositoryShop.Contexts;
using RepositoryShop.IRepositories;

namespace RepositoryShop
{
    public class SqlPersonRepository : IPersonRepository
    {

        private readonly dbcontext _db;

        private bool _disposed = false;

        public SqlPersonRepository(dbcontext context)
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

        public IEnumerable<Person> GetItemList()
        {
            return _db.Persons;
        }

        public Person GetItem(string id)
        {
            // if (_db.Persons.Find(id) == null) return null;
            foreach (var s in _db.Persons)
                if (s.Login == id || s.Email == id)
                    return s;
                return null;            
        }

        public Person GetItem(long id)
        {
            // if (_db.Persons.Find(id) == null) return null;
            return _db.Persons.Find(id);
                     
        }

        public void Create(Person item)
        {
            _db.Persons.Add(item);
            _db.SaveChanges();
        }

        public void Delete(long id)
        { 
                _db.Persons.Remove(GetItem(id));
                _db.SaveChanges();
        }

        public void Delete(string id)
        {
            _db.Persons.Remove(GetItem(id));
            _db.SaveChanges();
        }

        public void Update(Person item)
        {
            //   _db.Entry(item).State = EntityState.Modified;
            Delete(item.Id);
            Create(item);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}