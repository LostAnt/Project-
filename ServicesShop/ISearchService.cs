using System.Collections.Generic;
using DomainShop;

namespace ServicesShop
{
    public interface ISearchService
    {
        IEnumerable<Property> Search(string query, string minPrice, string maxPrice, string minBeds, string maxBeds, string type);
    }
}