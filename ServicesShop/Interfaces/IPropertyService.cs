using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainShop;
using RepositoryShop.IRepositories;

namespace ServicesShop.Interfaces
{
   public interface IPropertyService
    {
        IEnumerable<Property> GetItemList();

        Property GetItem(int id);


        void Create(Property item);


        void Delete(int id);


        void Update(Property item);


        void Save();
    }
}
