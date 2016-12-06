using System;
using System.Collections.Generic;
using DomainShop;

namespace RepositoryShop.IRepositories
{
    public interface IPersonRepository : IDisposable
    {
        IEnumerable<Person> GetItemList();
        Person GetItem(int id);
        void Create(Person item);
        void Delete(int id);
        void Update(Person item);
        void Save();
    }
}