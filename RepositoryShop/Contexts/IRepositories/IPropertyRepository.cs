using System;
using System.Collections.Generic;
using DomainShop;

namespace RepositoryShop.IRepositories
{
    public interface IPropertyRepository : IDisposable
    {
        IEnumerable<Property> GetItemList();
        Property GetItem(int id);
        void Create(Property item);
        void Delete(int id);
        void Update(Property item);
        void Save();
    }
}