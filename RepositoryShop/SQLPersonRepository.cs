using System;
using System.Collections.Generic;
using System.Data.Entity;
using DomainShop;
using RepositoryShop.Contexts;

namespace RepositoryShop
{
    public class SQLPersonRepository : IRepository<Person>
    {

        private PersonContext _db;

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

        public IEnumerable<Person> GetItemList()
        {
            return _db.Persons;
        }

        public Person GetItem(int id)
        {
            return _db.Persons.Find(id);
        }

        public void Create(Person item)
        {
            _db.Persons.Add(item);
        }

        public void Delete(int id)
        {
            Person person = _db.Persons.Find(id);
            if (person != null)
            {
                _db.Persons.Remove(person);
            }
        }

        public void Update(Person item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}